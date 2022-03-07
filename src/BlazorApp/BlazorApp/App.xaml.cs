namespace BlazorApp
{
    public partial class App : Application
    {
        internal const string Title = "Weekly Xamarin";

        public App(IServiceProvider services)
        {
            InitializeComponent();
            Instance = this;
            Services = services;
            MainPage = new AppShell();
        }

        public static App Instance { get; private set; }

        public IServiceProvider Services { get; }
    }
}
