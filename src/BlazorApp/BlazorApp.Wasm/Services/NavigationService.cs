using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using VijayAnand.MauiToolkit.Core.Services;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Models;
using WeeklyXamarin.Core.Services;

using static WeeklyXamarin.Core.Helpers.Constants.Navigation.ParameterNames;

namespace BlazorApp.Wasm.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IDataStore dataStore;
        //private readonly IJSInProcessRuntime jsRuntime;
        private readonly IJSRuntime jsRuntime;
        private readonly NavigationManager navigator;

        public NavigationService(NavigationManager navigator, IJSRuntime jsRuntime, IDataStore dataStore)
        {
            this.navigator = navigator;
            this.jsRuntime = jsRuntime;
            this.dataStore = dataStore;
        }

        public Task GoBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task GoToAsync(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task GoToAsync(string uri, string key, string value)
        {
            if (uri == Constants.Navigation.Paths.Article)
            {
                var article = await dataStore.GetArticleAsync(Article.GetEditionId(value), value);
                _ = await jsRuntime.InvokeAsync<object>("window.open", article.Url, "_blank");
            }
            else if (uri == Constants.Navigation.Paths.Web)
            {
                _ = await jsRuntime.InvokeAsync<object>("window.open", value, "_blank");
            }
        }

        public async Task GoToAsync(string uri, IDictionary<string, object> parameters)
        {
            if (uri == Constants.Navigation.Paths.Article)
            {
                var article = await dataStore.GetArticleAsync(Article.GetEditionId(parameters[ArticleId].ToString()), parameters[Constants.Navigation.ParameterNames.ArticleId].ToString());
                _ = await jsRuntime.InvokeAsync<object>("window.open", article.Url, "_blank");
            }
            else if (uri == Constants.Navigation.Paths.Web)
            {
                _ = await jsRuntime.InvokeAsync<object>("window.open", parameters[WebLink], "_blank");
            }
        }
    }
}
