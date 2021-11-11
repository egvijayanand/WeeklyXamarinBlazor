using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.Wpf.Services
{
    public class NavigationService : INavigationService
    {
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
            if (uri == Constants.Navigation.Paths.Article && App.Routes[uri] is WebWindow window)
            {
                await window.Navigate(value);
            }
            else if (uri == Constants.Navigation.Paths.Web && key == Constants.Navigation.ParameterNames.WebLink)
            {
                WebWindow.Instance.WebView.Source = new Uri(value);
                WebWindow.Instance.Show();
                WebWindow.Instance.BringIntoView();
            }
        }

        public async Task GoToAsync(string uri, Dictionary<string, object> parameters)
        {
            if (uri == Constants.Navigation.Paths.Article
                && parameters.ContainsKey(Constants.Navigation.ParameterNames.ArticleId)
                && App.Routes[uri] is WebWindow window)
            {
                await window.Navigate(parameters[Constants.Navigation.ParameterNames.ArticleId].ToString());
            }
            else if (uri == Constants.Navigation.Paths.Web
                && parameters.ContainsKey(Constants.Navigation.ParameterNames.WebLink))
            {
                WebWindow.Instance.WebView.Source = new Uri(parameters[Constants.Navigation.ParameterNames.WebLink].ToString());
                WebWindow.Instance.Show();
                WebWindow.Instance.BringIntoView();
            }
        }
    }
}
