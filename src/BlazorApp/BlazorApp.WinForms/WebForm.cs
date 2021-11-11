using BlazorApp.WinForms.Helpers;
using BlazorApp.WinForms.Properties;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeeklyXamarin.Core.Models;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.WinForms
{
    public partial class WebForm : Form
    {
        private bool firstRun = true;
        private readonly IDataStore dataStore;
        private readonly WebView2 webView;

        private static readonly object locker = new();

        public WebForm(IDataStore dataStore)
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
            webView = new WebView2()
            {
                Dock = DockStyle.Fill
            };

            webView.NavigationStarting += (_, _) =>
            {
                container.BringToFront();
            };

            webView.NavigationCompleted += (_, e) =>
            {
                container.SendToBack();

                if (e.IsSuccess)
                {
                    Text = webView.CoreWebView2.DocumentTitle;
                }
            };

            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            Controls.Add(webView);
            ShowSplashPanel();
        }

        public static WebForm Instance { get; private set; }

        public WebView2 WebView => webView;

        public bool Initialized { get; private set; }

        public async Task Navigate(string articleId)
        {
            if (!Initialized)
            {
                throw new InvalidOperationException("Navigate can be called only after initialization is completed.");
            }

            _ = PInvoke.InternetGetConnectedState(out int flags, 0);
            dataStore.UpdateNetworkStatus(flags != (int)InternetGetConnectedState.Offline);
            var article = await dataStore.GetArticleAsync(Article.GetEditionId(articleId), articleId, true, false);

            if (article != null && !string.IsNullOrEmpty(article.Url))
            {
                webView.CoreWebView2.Navigate(article.Url);
                Text = article.Title;
                Show();
                BringToFront();
            }
        }

        private void ShowSplashPanel()
        {
            CenterImage();
            img.Visible = true;
            container.Visible = true;
            container.BorderStyle = BorderStyle.FixedSingle;
            FormBorderStyle = FormBorderStyle.None;
        }

        private void HideSplashPanel()
        {
            img.Image = Resources.Loading;
            container.SendToBack();

            ControlBox = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender,
                                                                 CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                Initialized = true;
                Hide();
                HideSplashPanel();
            }
        }

        private async void WebForm_Load(object sender, EventArgs e)
        {
            if (firstRun)
            {
                firstRun = false;
                await webView.EnsureCoreWebView2Async();
            }
        }

        private void WebForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            webView.CoreWebView2.Navigate(Path.Combine(Application.StartupPath, "wwwroot", "blank.html"));
            Hide();
            e.Cancel = true;
        }

        private void WebForm_Resize(object sender, EventArgs e)
        {
            CenterImage();
        }

        private void CenterImage()
        {
            int left = ClientSize.Width / 2 - img.Width / 2;
            int top = ClientSize.Height / 2 - img.Height / 2;
            img.Location = new Point(left, top);
        }
    }
}
