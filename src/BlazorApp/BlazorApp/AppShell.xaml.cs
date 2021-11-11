using BlazorApp.Views;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using WeeklyXamarin.Core.Helpers;

namespace BlazorApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(Constants.Navigation.Paths.Article, typeof(WebPage));
            Routing.RegisterRoute(Constants.Navigation.Paths.Web, typeof(WebPage));
        }
    }
}
