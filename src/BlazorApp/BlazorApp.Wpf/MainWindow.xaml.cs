using System;
using System.ComponentModel;
using System.Windows;

namespace BlazorApp.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Resources.Add("services", Startup.Services);
            InitializeComponent();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            WebWindow.Instance.ApplicationExit = true;
            WebWindow.Instance.Close();
        }
    }
}
