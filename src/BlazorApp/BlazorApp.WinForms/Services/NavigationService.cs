namespace BlazorApp.WinForms.Services
{
    public class NavigationService : INavigationService
    {
        public Task GoToAsync(string uri)
        {
            throw new NotImplementedException();
        }

        public Task GoToAsync(string uri, string key, object value)
        {
            if (uri == Paths.Web && value is not null)
            {
                WebForm.Instance.WebView.CoreWebView2.Navigate(value.ToString());
                WebForm.Instance.Show();
                WebForm.Instance.BringToFront();
            }
            else if (uri == Paths.Article && Program.Routes[uri] is WebForm webForm)
            {
                _ = webForm.Navigate(value.ToString());
            }

            return Task.FromResult(0);
        }

        public async Task GoToAsync(string uri, IDictionary<string, object> parameters)
        {
            if (uri == Paths.Article && Program.Routes[uri] is WebForm webForm)
            {
                await webForm.Navigate(parameters[ParameterNames.ArticleId].ToString());
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
