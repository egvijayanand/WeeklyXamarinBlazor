using WeeklyXamarin.Core.Helpers;

namespace BlazorApp
{
    public partial class App : Application
    {
        internal const string Title = "Weekly Xamarin";

        public App(IServiceProvider services)
        {
            InitializeComponent();
            RegisterRoutes();
            Services = services;
            MainPage = new AppShell();
            //MainPage = new AppNavPage(new MainPage());
        }

        private static void RegisterRoutes()
        {
            Routing.RegisterRoute(Paths.Article, typeof(WebPage));
            Routing.RegisterRoute(Paths.Web, typeof(WebPage));
        }

        public static App? Instance => Current as App;

        public IServiceProvider Services { get; }
    }
}
