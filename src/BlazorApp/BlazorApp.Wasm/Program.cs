using BlazorApp.Wasm.Services;
using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using VijayAnand.MauiToolkit.Core.Services;
using WeeklyXamarin.Core;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = WebAssemblyHostBuilder.CreateDefault(args);
            host.RootComponents.Add<Main>("#app");

            host.Services.AddBlazoredModal();
            host.Services.AddBlazoredLocalStorage();

            //host.Services.AddSingleton(sp => (IJSInProcessRuntime)sp.GetRequiredService<IJSRuntime>());
            //host.Services.AddSingleton(sp => (IJSUnmarshalledRuntime)sp.GetRequiredService<IJSRuntime>());

            host.Services.AddScoped<AppState>();
            host.Services.AddScoped<IDataStore, GitHubDataStore>();
            host.Services.AddScoped<IDialogService, DialogService>();
            host.Services.AddScoped<INavigationService, NavigationService>();
            host.Services.AddScoped<IShareService, ShareService>();

            host.Services.AddHttpClient(Constants.DataStore.GitHub, client =>
            {
                // GitHub Raw URLs not working
                //client.BaseAddress = new Uri("https://raw.githubusercontent.com/weeklyxamarin/WeeklyXamarin.content/master/content/");
                // Since everything is JSON file content, making use of the direct URLs
                client.BaseAddress = new Uri("https://github.com/weeklyxamarin/WeeklyXamarin.content/blob/master/content/");
                client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "https://egvijayanand.github.io/");
            });

            await host.Build().RunAsync();
        }
    }
}
