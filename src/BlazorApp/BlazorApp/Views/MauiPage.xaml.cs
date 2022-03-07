using BlazorApp.ViewModels;

namespace BlazorApp.Views
{
    public partial class MauiPage : ContentPage
    {
        public MauiPage()
        {
            InitializeComponent();
        }

        public ViewModelBase ViewModel { get; set; }
    }
}
