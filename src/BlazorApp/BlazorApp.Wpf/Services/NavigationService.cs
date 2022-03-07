namespace BlazorApp.Wpf.Services
{
    public class NavigationService : INavigationService
    {
        public Task GoBackAsync(bool modal = false)
        {
            throw new NotImplementedException();
        }

        public Task GoToAsync(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task GoToAsync(string uri, string key, string value)
        {
            if (uri == Paths.Article && App.Routes[uri] is WebWindow window)
            {
                await window.Navigate(value);
            }
            else if (uri == Paths.Web && key == ParameterNames.WebLink)
            {
                WebWindow.Instance.WebView.Source = new Uri(value);
                WebWindow.Instance.Show();
                WebWindow.Instance.BringIntoView();
            }
        }

        public async Task GoToAsync(string uri, Dictionary<string, object> parameters)
        {
            if (uri == Paths.Article && parameters.ContainsKey(ParameterNames.ArticleId)
                && App.Routes[uri] is WebWindow window)
            {
                await window.Navigate(parameters[ParameterNames.ArticleId].ToString());
            }
            else if (uri == Paths.Web && parameters.ContainsKey(ParameterNames.WebLink))
            {
                WebWindow.Instance.WebView.Source = new Uri(parameters[ParameterNames.WebLink].ToString());
                WebWindow.Instance.Show();
                WebWindow.Instance.BringIntoView();
            }
        }
    }
}
