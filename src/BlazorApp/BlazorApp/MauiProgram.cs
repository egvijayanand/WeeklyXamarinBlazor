using BlazorApp.Services;
using BlazorApp.ViewModels;
using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using System;
using WeeklyXamarin.Core;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Services;

namespace BlazorApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.RegisterBlazorMauiWebView()
                   .UseMauiApp<App>()
                   .ConfigureFonts(fonts =>
                   {
                       fonts.AddFont("OpenSans-Regular.ttf", "OSR");
                       fonts.AddFont("fa-brands-400.ttf", "FAB");
                       fonts.AddFont("fa-regular-400.ttf", "FAR");
                       fonts.AddFont("fa-solid-900.ttf", "FAS");
                   })
                   .UseMauiApp<App>()
                   .ConfigureServices(services =>
                   {
                       services.AddBlazorWebView();
                       services.AddBlazoredModal();
                       services.AddBlazoredLocalStorage();

                       services.AddSingleton<AppState>();
                       services.AddSingleton<IDialogService, DialogService>();
                       services.AddSingleton<INavigationService, NavigationService>();
                       services.AddSingleton<IShareService, ShareService>();

                       services.AddScoped<IDataStore, GitHubDataStore>();
                       services.AddHttpClient(Constants.DataStore.GitHub, client =>
                       {
                           client.BaseAddress = new Uri("https://raw.githubusercontent.com/weeklyxamarin/WeeklyXamarin.content/master/content/");
                       });

                       services.AddTransient<ArticleViewModel>();
                       services.AddTransient<MainViewModel>();
                       services.AddTransient<WebViewModel>();
                   });

            return builder.Build();
        }

        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder,
                                                       Action<IServiceCollection>? configureDelegate)
        {
            configureDelegate?.Invoke(builder.Services);
            return builder;
        }
    }
}
