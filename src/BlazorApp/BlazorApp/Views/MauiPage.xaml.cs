namespace BlazorApp.Views
{
    public partial class MauiPage : ContentPage
    {
        public MauiPage()
        {
            InitializeComponent();
        }

        public BaseViewModel? ViewModel { get; set; }

        private void OnThemePopupTapped(object sender, EventArgs e)
        {

        }
    }
}
