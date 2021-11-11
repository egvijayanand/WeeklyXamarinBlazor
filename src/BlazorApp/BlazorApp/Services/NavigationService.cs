using BlazorApp.Views;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Services;
using static WeeklyXamarin.Core.Helpers.Constants;

namespace BlazorApp.Services
{
    public class NavigationService : INavigationService
    {
        public async Task GoToAsync(string uri)
        {
            await Shell.Current.GoToAsync(uri);
        }

        public async Task GoToAsync(string uri, string key, string value)
        {
#if WINDOWS || ANDROID
            await Shell.Current.GoToAsync($"{uri}?{key}={value}");
#else
            await (Application.Current.MainPage as NavigationPage)?.PushAsync(new WebPage(new Dictionary<string, object>() { [key] = value }));
#endif

            //var element = Routing.GetOrCreateContent(uri);

            //if (uri == Constants.Navigation.Paths.Article || uri == Constants.Navigation.Paths.Web)
            //{
            //    await (Application.Current.MainPage as NavigationPage)?.PushAsync(new WebPage(new Dictionary<string, string>() { [key] = value }));
            //}
        }

        public async Task GoToAsync(string uri, Dictionary<string, object> parameters)
        {
#if WINDOWS || ANDROID
            var fullUrl = BuildUri(uri, parameters);
            await Shell.Current.GoToAsync(fullUrl);
#else
            await (Application.Current.MainPage as NavigationPage)?.PushAsync(new WebPage(parameters));
#endif
        }

        public async Task GoBackAsync()
        {
            if (Shell.Current.Navigation.ModalStack.Count > 0)
            {
                await Shell.Current.Navigation.PopModalAsync();
            }
            else
            {
                await Shell.Current.Navigation.PopAsync();
            }
        }

        private string BuildUri(string uri, Dictionary<string, object> parameters)
        {
            var fullUrl = new StringBuilder();
            fullUrl.Append(uri);
            fullUrl.Append("?");
            fullUrl.Append(string.Join("&", parameters.Select(item => $"{item.Key}={item.Value}")));
            return fullUrl.ToString();
        }
    }
}
