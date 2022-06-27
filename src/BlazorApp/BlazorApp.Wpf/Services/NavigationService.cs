namespace BlazorApp.Wpf.Services
{
    public class NavigationService : INavigationService
    {
        public Task GoToAsync(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task GoToAsync(string uri, string key, object value)
        {
            if (uri == Paths.Article && App.Routes[uri] is WebWindow window && value is not null)
            {
                await window.Navigate(value.ToString());
            }
            else if (uri == Paths.Web && key == ParameterNames.WebLink && value is not null)
            {
                WebWindow.Instance.WebView.Source = new Uri(value.ToString());
                WebWindow.Instance.Show();
                WebWindow.Instance.BringIntoView();
            }
        }

        public async Task GoToAsync(string uri, IDictionary<string, object> parameters)
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

        public Task GoToAsync(string route, params (string key, object value)[] routeParameters)
        {
            throw new NotImplementedException();
        }

        public Task GoBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task GoBackAsync(string key, object value)
        {
            throw new NotImplementedException();
        }

        public Task GoBackAsync(IDictionary<string, object> routeParameters)
        {
            throw new NotImplementedException();
        }

        public Task GoBackAsync(params (string key, object value)[] routeParameters)
        {
            throw new NotImplementedException();
        }
    }
}
