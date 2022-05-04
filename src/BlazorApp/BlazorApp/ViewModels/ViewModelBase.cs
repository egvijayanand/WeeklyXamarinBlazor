using System.Runtime.CompilerServices;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.ViewModels
{
    public partial class ViewModelBase : ObservableValidator, IViewModel
    {
        [ObservableProperty]
        private string title = string.Empty;

        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(IsNotBusy))]
        private bool isBusy;

        public ViewModelBase(IDataStore? dataStore)
        {
            DataStore = dataStore;
        }

        public IDataStore? DataStore { get; protected set; }

        public bool IsNotBusy => !IsBusy;

        public virtual Task InitializeAsync(IDictionary<string, object> parameters)
            => Task.FromResult(0);

        protected virtual bool SetProperty<T>(ref T field,
                                              T value,
                                              [CallerMemberName] string? propertyName = null,
                                              Action? onChanging = null,
                                              Action? onChanged = null,
                                              Func<T, T, bool>? validateValue = null)
        {
            // If value didn't change
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            // If value changed but didn't validate
            if (validateValue != null && !validateValue(field, value))
            {
                return false;
            }

            onChanging?.Invoke();
            field = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
