using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using VijayAnand.MauiToolkit.Core.Services;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Models;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.Server.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IDataStore dataStore;
        private readonly IJSRuntime jSRuntime;
        private readonly NavigationManager navigator;

        public NavigationService(NavigationManager navigator, IJSRuntime jSRuntime, IDataStore dataStore)
        {
            this.navigator = navigator;
            this.jSRuntime = jSRuntime;
            this.dataStore = dataStore;
        }

        public Task GoToAsync(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task GoToAsync(string uri, string key, object value)
        {
            if (uri == Constants.Navigation.Paths.Article && value is not null)
            {
                var article = await dataStore.GetArticleAsync(Article.GetEditionId(value.ToString()), value.ToString());
                _ = await jSRuntime.InvokeAsync<object>("open", article.Url, "_blank");
            }
            else if (uri == Constants.Navigation.Paths.Web && value is not null)
            {
                _ = await jSRuntime.InvokeAsync<object>("open", value, "_blank");
            }
        }

        public Task GoToAsync(string uri, IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
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
