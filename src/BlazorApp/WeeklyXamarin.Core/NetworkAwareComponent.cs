using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WeeklyXamarin.Core
{
    public class NetworkAwareComponent : ComponentBase, INotifyPropertyChanged, IAsyncDisposable
    {
        private bool _connected;
        private DotNetObjectReference<NetworkAwareComponent> _objRef;

        public event Action<bool> NetworkStateChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _objRef = DotNetObjectReference.Create(this);
            _connected = await JSRuntime.InvokeAsync<bool>("readNetworkState", _objRef);
            OnNetworkStateChanged(_connected);
        }

        protected virtual bool SetProperty<T>(ref T field,
                                                  T value,
                                                  [CallerMemberName] string propertyName = null,
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

        public async ValueTask DisposeAsync()
        {
            await JSRuntime.InvokeVoidAsync("removeFrom");
            _objRef?.Dispose();
        }

        [JSInvokable]
        public void UpdateNetworkStatus(bool connected)
        {
            if (_connected != connected)
            {
                OnNetworkStateChanged(connected);
            }
        }

        protected virtual void OnNetworkStateChanged(bool connected)
        {
            NetworkStateChanged?.Invoke(connected);
        }
    }
}
