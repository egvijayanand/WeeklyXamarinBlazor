using CommunityToolkit.Maui.Views;

namespace BlazorApp
{
    public partial class AppNavPage : NavigationPage
    {
        public AppNavPage()
        {
            InitializeComponent();
        }

        public AppNavPage(Page startPage) : base(startPage)
        {
            InitializeComponent();
        }

        private void OnThemePopupTapped(object sender, EventArgs e)
        {
            var appTheme = AppService.GetService<AppThemePopup>();

            if (appTheme is not null)
            {
                Application.Current?.MainPage?.ShowPopup(appTheme);
            }
        }
    }
}
