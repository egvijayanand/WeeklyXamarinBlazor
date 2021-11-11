using WeeklyXamarin.Core.Services;

namespace BlazorApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IDataStore dataStore) : base(dataStore)
        {
            Title = "Weekly Xamarin";
        }
    }
}
