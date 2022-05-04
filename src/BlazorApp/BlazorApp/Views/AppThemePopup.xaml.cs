using CommunityToolkit.Maui.Views;

namespace BlazorApp.Views
{
    public partial class AppThemePopup : Popup
    {
        public AppThemePopup(AppThemeViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void OnCloseClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
