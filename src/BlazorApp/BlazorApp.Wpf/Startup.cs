using BlazorApp.Wpf.Extensions;
using BlazorApp.Wpf.Services;
using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeeklyXamarin.Core;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.Wpf
{
    public class Startup
    {
        public static IServiceProvider Services { get; private set; }

        public static void Init()
        {
            var host = Host.CreateDefaultBuilder()
                           .ConfigureEssentials()
                           .ConfigureServices(WireupServices)
                           .Build();
            Services = host.Services;
        }

        private static void WireupServices(IServiceCollection services)
        {
            services.AddWpfBlazorWebView();
#if DEBUG
            services.AddBlazorWebViewDeveloperTools();
#endif
            services.AddBlazoredModal();
            services.AddBlazoredLocalStorage();

            services.AddSingleton<AppState>();
            services.AddSingleton<WebWindow>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IShareService, ShareService>();

            services.AddScoped<IDataStore, GitHubDataStore>();

            services.AddHttpClient(Constants.DataStore.GitHub, client =>
            {
                client.BaseAddress = new Uri("https://raw.githubusercontent.com/weeklyxamarin/WeeklyXamarin.content/master/content/");
            });
        }
    }
}
