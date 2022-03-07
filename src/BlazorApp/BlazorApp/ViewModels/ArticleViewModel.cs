using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Models;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.ViewModels
{
    public class ArticleViewModel : ViewModelBase
    {
        private Article article;

        public ArticleViewModel(IDataStore dataStore) : base(dataStore)
        {

        }

        public Article Article
        {
            get => article;
            set => SetProperty(ref article, value);
        }

        public override async Task InitializeAsync(IDictionary<string, object> parameters)
        {
            await base.InitializeAsync(parameters);
            var articleId = parameters[Constants.Navigation.ParameterNames.ArticleId].ToString();
            Article = await DataStore.GetArticleAsync(Article.GetEditionId(articleId), articleId, true, false);
        }
    }
}
