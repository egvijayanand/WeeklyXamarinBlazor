using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WeeklyXamarin.Core.Helpers;
using static BlazorApp.Wpf.Startup;

namespace BlazorApp.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal readonly static Dictionary<string, Window> Routes = new();

        public App()
        {
            Init();
            var window = Wpf.Startup.Services.GetService<WebWindow>();
            Routes.Add(Paths.Article, window);
            Routes.Add(Paths.Web, window);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if (Current.Windows.Count > 0)
            {

            }
        }
    }
}
