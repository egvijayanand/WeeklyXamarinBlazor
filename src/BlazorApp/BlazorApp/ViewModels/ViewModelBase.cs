using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private string _title;

        public ViewModelBase(IDataStore dataStore)
        {
            DataStore = dataStore;
        }

        protected IDataStore DataStore { get; private set; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual Task InitializeAsync(IDictionary<string, object> parameters)
        {
            return Task.FromResult(0);
        }

        protected virtual bool SetProperty<T>(ref T field,
                                              T value,
                                              [CallerMemberName] string propertyName = "",
                                              Action onChanging = null,
                                              Action onChanged = null,
                                              Func<T, T, bool> validateValue = null)
        {
            // if value didn't change
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            // if value changed but didn't validate
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
