using BlazorApp.Views;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using Application = Microsoft.Maui.Controls.Application;

namespace BlazorApp
{
    public partial class App : Application
    {
        public App(IServiceProvider services)
        {
            InitializeComponent();
            Instance = this;
            Services = services;
#if WINDOWS || ANDROID
            MainPage = new AppShell();
#else
            MainPage = new NavigationPage(new MainPage());
#endif
        }

        public static App Instance { get; private set; }

        public IServiceProvider Services { get; }
    }
}
