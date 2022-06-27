using WeeklyXamarin.Core.Models;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.Services
{
    public class BrowserNavigationService : INavigationService
    {
        private readonly IBrowser browser;
        private readonly IDataStore dataStore;

        public BrowserNavigationService(IBrowser browser, IDataStore dataStore)
        {
            this.browser = browser;
            this.dataStore = dataStore;
        }

        public Task GoToAsync(string route)
        {
            throw new NotImplementedException();
        }

        public async Task GoToAsync(string route, string name, object value)
        {
            if (value is not null)
            {
                if (route == Paths.Web && name == WebLink)
                {
                    await browser.OpenAsync(value.ToString());
                }
                else if (route == Paths.Article && name == ArticleId)
                {
                    dataStore.UpdateNetworkStatus(Connectivity.NetworkAccess == NetworkAccess.Internet);
                    var article = await dataStore.GetArticleAsync(Article.GetEditionId(value.ToString()), value.ToString(), true, false);

                    if (article is not null)
                    {
                        await browser.OpenAsync(article.Url);
                    }
                }
            }
        }

        public async Task GoToAsync(string route, IDictionary<string, object> routeParameters)
        {
            if (routeParameters.ContainsKey(ArticleId))
            {
                var articleId = routeParameters[ArticleId].ToString();
                dataStore.UpdateNetworkStatus(Connectivity.NetworkAccess == NetworkAccess.Internet);
                var article = await dataStore.GetArticleAsync(Article.GetEditionId(articleId), articleId, true, false);

                if (article is not null)
                {
                    await browser.OpenAsync(article.Url);
                }
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
