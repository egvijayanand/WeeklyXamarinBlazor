using WeeklyXamarin.Core.Models;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.ViewModels
{
    public partial class WebViewModel : DataViewModel
    {
        [ObservableProperty]
        private string url = string.Empty;

        public WebViewModel(IDataStore dataStore) : base(dataStore)
        {
            Title = "Loading ...";
        }

        public override async Task InitializeAsync(IDictionary<string, object>? parameters)
        {
            await base.InitializeAsync(parameters);

            DataStore.UpdateNetworkStatus(Connectivity.NetworkAccess == NetworkAccess.Internet);

            if (parameters is not null && parameters.ContainsKey(ArticleId))
            {
                var articleId = parameters[ArticleId].ToString();
                var article = await DataStore.GetArticleAsync(Article.GetEditionId(articleId), articleId, true, false);
                Url = article.Url;
                Title = article.Title;
            }
        }
    }
}
