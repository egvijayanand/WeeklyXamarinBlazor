using BlazorApp.Wpf.Helpers;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using WeeklyXamarin.Core.Models;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.Wpf
{
    /// <summary>
    /// Interaction logic for WebWindow.xaml
    /// </summary>
    public partial class WebWindow : Window
    {
        private static readonly object locker = new();

        private readonly IDataStore dataStore;

        public WebWindow(IDataStore dataStore)
        {
            if (Instance == null)
            {
                lock (locker)
                {
                    if (Instance == null)
                    {
                        Instance = this;
                    }
                }
            }

            this.dataStore = dataStore;
            InitializeComponent();
            webView.NavigationCompleted += (_, e) =>
            {
                if (e.IsSuccess)
                {
                    Title = webView.CoreWebView2.DocumentTitle;
                }
            };
        }

        public static WebWindow Instance { get; private set; }

        public WebView2 WebView => webView;

        public bool ApplicationExit { get; set; }

        public async Task Navigate(string articleId)
        {
            _ = PInvoke.InternetGetConnectedState(out int flags, 0);
            dataStore.UpdateNetworkStatus(flags != (int)InternetGetConnectedState.Offline);
            var article = await dataStore.GetArticleAsync(Article.GetEditionId(articleId), articleId, true, false);

            if (article != null && !string.IsNullOrEmpty(article.Url))
            {
                webView.Source = new Uri(article.Url);
                Title = article.Title;
                Show();
                BringIntoView();
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!ApplicationExit)
            {
                webView.CoreWebView2.Navigate(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "blank.html"));
                Hide();
                e.Cancel = true;
            }
        }
    }
}
