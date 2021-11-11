using BlazorApp.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

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
