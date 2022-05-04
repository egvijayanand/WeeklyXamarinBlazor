using Blazored.LocalStorage;
using Blazored.Modal;
using CommunityToolkit.Maui;
using VijayAnand.MauiToolkit;
using WeeklyXamarin.Core;
using WeeklyXamarin.Core.Services;

namespace BlazorApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            //var components = ServiceRegistrations.All & ~ServiceRegistrations.Navigation;

            builder.UseMauiApp<App>()
                   .UseMauiCommunityToolkit()
                   .UseVijayAnandMauiToolkit(/*components*/)
                   .ConfigureFonts(fonts =>
                   {
                       fonts.AddFont("OpenSans-Regular.ttf", "OSR");
                       fonts.AddFont("fa-brands-400.ttf", "FAB");
                       fonts.AddFont("fa-regular-400.ttf", "FAR");
                       fonts.AddFont("fa-solid-900.ttf", "FAS");
                   })
                   .ConfigureServices(services =>
                   {
                       services.AddMauiBlazorWebView();
#if DEBUG
                       services.AddBlazorWebViewDeveloperTools();
#endif
                       services.AddBlazoredModal();
                       services.AddBlazoredLocalStorage();

                       services.AddSingleton<AppState>();
                       services.AddSingleton<MainViewModel>();
                       services.AddSingleton<MainPage>();

                       services.AddSingleton(AppInfo.Current);
                       services.AddSingleton(Browser.Default);
                       //services.AddSingleton<INavigationService, BrowserNavigationService>();

                       services.AddScoped<IDataStore, GitHubDataStore>();
                       services.AddHttpClient(DataStore.GitHub, client =>
                       {
                           client.BaseAddress = new Uri("https://raw.githubusercontent.com/weeklyxamarin/WeeklyXamarin.content/master/content/");
                       });

                       services.AddTransient<ArticleViewModel>();
                       services.AddTransient<WebViewModel>();

                       services.AddTransient<AppThemeViewModel>();
                       services.AddTransient<AppThemePopup>();
                   });

            return builder.Build();
        }
    }
}
