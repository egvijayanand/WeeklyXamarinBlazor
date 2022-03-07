using Microsoft.JSInterop;
using VijayAnand.MauiToolkit.Core;

namespace BlazorApp.Wasm.Services
{
    public class DialogService : IDialogService
    {
        private readonly IJSRuntime jSRuntime;

        public DialogService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            throw new NotImplementedException();
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await jSRuntime.InvokeVoidAsync("showAlert", title, message, cancel);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            throw new NotImplementedException();
        }

        public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, InputType inputType = InputType.Default, string initialValue = "")
        {
            throw new NotImplementedException();
        }
    }
}
