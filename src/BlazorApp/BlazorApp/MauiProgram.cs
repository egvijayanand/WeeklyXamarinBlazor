using BlazorApp.ViewModels;
using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebView.Maui;
using VijayAnand.MauiToolkit;
using WeeklyXamarin.Core;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Services;

#nullable enable

namespace BlazorApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.RegisterBlazorMauiWebView()
                   .UseMauiApp<App>()
                   .UseVijayAnandMauiToolkit()
                   .ConfigureFonts(fonts =>
                   {
                       fonts.AddFont("OpenSans-Regular.ttf", "OSR");
                       fonts.AddFont("fa-brands-400.ttf", "FAB");
                       fonts.AddFont("fa-regular-400.ttf", "FAR");
                       fonts.AddFont("fa-solid-900.ttf", "FAS");
                   })
                   .ConfigureServices(services =>
                   {
                       services.AddBlazorWebView();
                       services.AddBlazoredModal();
                       services.AddBlazoredLocalStorage();

                       services.AddSingleton<AppState>();

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
