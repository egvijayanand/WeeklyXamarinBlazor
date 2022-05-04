namespace BlazorApp.Views
{
    public partial class WebPage : MauiPage, IQueryAttributable
    {
        private readonly IDictionary<string, object>? dict;

        public WebPage()
        {
            InitializeComponent();
        }

        public WebPage(IDictionary<string, object> dict) : this()
        {
            this.dict = dict;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel is not null && dict is not null)
            {
                if (dict.ContainsKey(ArticleId))
                {
                    await ViewModel.InitializeAsync(dict);
                }
                else if (dict.ContainsKey(WebLink))
                {
                    ((WebViewModel)ViewModel).Url = dict[WebLink].ToString();
                }
            }
        }

        async void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (ViewModel is not null)
            {
                if (query.ContainsKey(ArticleId))
                {
                    await ViewModel.InitializeAsync(query);
                }
                else if (query.ContainsKey(WebLink))
                {
                    ((WebViewModel)ViewModel).Url = query[WebLink].ToString();
                }
            }
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            //await DisplayAlert("Weekly Xamarin", e.Url, "OK");
        }

        private async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (e.Result == WebNavigationResult.Success)
            {
                if (ViewModel is not null)
                {
                    ViewModel.Title = await (sender as WebView)?.EvaluateJavaScriptAsync("document.title");
                }
            }
            else if (e.Result == WebNavigationResult.Failure)
            {
                await DisplayAlert("Weekly Xamarin", "Article failed to load, please try later.", "OK");
            }
        }
    }
}
