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

        public Task GoBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task GoToAsync(string route)
        {
            throw new NotImplementedException();
        }

        public async Task GoToAsync(string route, string name, string value)
        {
            if (name == WebLink)
            {
                await browser.OpenAsync(value);
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
    }
}
