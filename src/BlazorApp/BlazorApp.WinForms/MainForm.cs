using BlazorApp.WinForms.Services;
using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using WeeklyXamarin.Core;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            /*var services = new ServiceCollection();
            services.AddBlazorWebView();
            services.AddBlazoredModal();
            services.AddBlazoredLocalStorage();
            services.AddSingleton<AppState>();
            services.AddScoped<IDataStore, GitHubDataStore>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddHttpClient(Constants.DataStore.GitHub, client =>
            {
                client.BaseAddress = new Uri("https://raw.githubusercontent.com/weeklyxamarin/WeeklyXamarin.content/master/content/");
            });*/

            var blazor = new BlazorWebView()
            {
                Dock = DockStyle.Fill,
                HostPage = "wwwroot/index.html",
                Services = Startup.Services
            };

            blazor.RootComponents.Add<Main>("#app");
            Controls.Add(blazor);
        }

    }
}
