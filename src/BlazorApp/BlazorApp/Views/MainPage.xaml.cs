﻿using CommunityToolkit.Maui.Views;

namespace BlazorApp.Views
{
    public partial class MainPage : MauiPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnThemePopupTapped(object sender, EventArgs e)
        {
            var appTheme = AppService.GetService<AppThemePopup>();

            if (appTheme is not null)
            {
                this.ShowPopup(appTheme);
            }
        }
    }
}
