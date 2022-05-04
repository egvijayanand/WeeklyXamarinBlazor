using WeeklyXamarin.Core.Models;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.ViewModels
{
    public partial class ArticleViewModel : DataViewModel
    {
        [ObservableProperty]
        private Article? article;

        public ArticleViewModel(IDataStore dataStore) : base(dataStore)
        {

        }

        public override async Task InitializeAsync(IDictionary<string, object>? parameters)
        {
            await base.InitializeAsync(parameters);

            if (parameters is not null && parameters.ContainsKey(ArticleId))
            {
                var articleId = parameters[ArticleId].ToString();
                Article = await DataStore.GetArticleAsync(Article.GetEditionId(articleId), articleId, true, false);
            }
        }
    }
}
