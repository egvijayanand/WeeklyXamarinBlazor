using WeeklyXamarin.Core.Services;

namespace BlazorApp.ViewModels
{
    public class DataViewModel : BaseViewModel
    {
        public DataViewModel(IDataStore dataStore)
        {
            DataStore = dataStore;
        }

        protected IDataStore DataStore { get; }
    }
}
