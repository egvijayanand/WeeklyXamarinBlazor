namespace BlazorApp.WinForms.Services
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

        public Task GoToAsync(string uri, string key, string value)
        {
            if (uri == Paths.Web)
            {
                WebForm.Instance.WebView.CoreWebView2.Navigate(value);
                WebForm.Instance.Show();
                WebForm.Instance.BringToFront();
            }

            return Task.FromResult(0);
        }

        public async Task GoToAsync(string uri, Dictionary<string, object> parameters)
        {
            if (uri == Paths.Article && Program.Routes[uri] is WebForm webForm)
            {
                await webForm.Navigate(parameters[ParameterNames.ArticleId].ToString());
            }
        }
    }
}
