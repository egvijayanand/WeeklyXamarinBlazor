using BlazorApp.Services;
using Microsoft.Maui.Essentials;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Models;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.ViewModels
{
    public class WebViewModel : ViewModelBase
    {
        private string url;

        public WebViewModel(IDataStore dataStore) : base(dataStore)
        {
            Title = "Please wait ...";
        }

        public string Url
        {
            get => url;
            set => SetProperty(ref url, value);
        }

        public override async Task InitializeAsync(IDictionary<string, object> parameters)
        {
            await base.InitializeAsync(parameters);
            DataStore.UpdateNetworkStatus(Connectivity.NetworkAccess == NetworkAccess.Internet);
            var articleId = parameters[Constants.Navigation.ParameterNames.ArticleId].ToString();
            var article = await DataStore.GetArticleAsync(Article.GetEditionId(articleId), articleId, true, false);
            Url = $"{article.Url}?utm_source=app&utm_medium=windows&utm_content={parameters[Constants.Analytics.ParameterNames.Content]}";
            Title = article.Title;
            System.Diagnostics.Debug.WriteLine(Title);
        }
    }
}
