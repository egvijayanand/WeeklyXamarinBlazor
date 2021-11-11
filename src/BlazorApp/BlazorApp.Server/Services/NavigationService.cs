using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                _ = await jSRuntime.InvokeAsync<object>("open", article.Url, "_blank");
            }
            else if (uri == Constants.Navigation.Paths.Web)
            {
                _ = await jSRuntime.InvokeAsync<object>("open", value, "_blank");
            }
        }

        public Task GoToAsync(string uri, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
