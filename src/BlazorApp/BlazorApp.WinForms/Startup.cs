using BlazorApp.WinForms.Extensions;
using BlazorApp.WinForms.Services;
using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeeklyXamarin.Core;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.WinForms
{
    public class Startup
    {
        public static IServiceProvider Services { get; private set; }

        public static void Init()
        {
            var host = Host.CreateDefaultBuilder()
                           .ConfigureEssentials()
                           .ConfigureServices((_, x) => WireupServices(x))
                           .Build();
            Services = host.Services;
        }

        private static void WireupServices(IServiceCollection services)
        {
            services.AddWindowsFormsBlazorWebView();
#if DEBUG
            services.AddBlazorWebViewDeveloperTools();
#endif
            services.AddBlazoredModal();
            services.AddBlazoredLocalStorage();
            services.AddSingleton<WebForm>();
            services.AddSingleton<AppState>();
            services.AddScoped<IDataStore, GitHubDataStore>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IShareService, ShareService>();
            services.AddHttpClient(Constants.DataStore.GitHub, client =>
            {
                client.BaseAddress = new Uri("https://raw.githubusercontent.com/weeklyxamarin/WeeklyXamarin.content/master/content/");
            });
        }
    }
}