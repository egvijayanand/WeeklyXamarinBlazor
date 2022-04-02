using BlazorApp.ViewModels;
using WeeklyXamarin.Core.Helpers;

namespace BlazorApp.Views
{
    public partial class WebPage : MauiPage, IQueryAttributable
    {
        private readonly IDictionary<string, object> dict;

        public WebPage()
        {
            InitializeComponent();
        }

        public WebPage(Dictionary<string, object> dict) : this()
        {
            this.dict = dict;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (dict != null)
            {
                if (dict.ContainsKey(Constants.Navigation.ParameterNames.ArticleId))
                {
                    await ViewModel.InitializeAsync(dict);
                }
                else if (dict.ContainsKey(Constants.Navigation.ParameterNames.WebLink))
                {
                    ((WebViewModel)ViewModel).Url = dict[Constants.Navigation.ParameterNames.WebLink].ToString();
                }
            }
        }

        async void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey(Constants.Navigation.ParameterNames.ArticleId))
            {
                await ViewModel.InitializeAsync(query);
            }
            else if (query.ContainsKey(Constants.Navigation.ParameterNames.WebLink))
            {
                ((WebViewModel)ViewModel).Url = query[Constants.Navigation.ParameterNames.WebLink].ToString();
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
                ViewModel.Title = await (sender as WebView)?.EvaluateJavaScriptAsync("document.title");
            }
            else if (e.Result == WebNavigationResult.Failure)
            {
                await DisplayAlert("Weekly Xamarin", "Article failed to load, please try later.", "OK");
            }
        }
    }
}
