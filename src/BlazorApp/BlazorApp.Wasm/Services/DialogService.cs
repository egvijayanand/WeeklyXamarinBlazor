using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.Wasm.Services
{
    public class DialogService : IDialogService
    {
        private readonly IJSRuntime jSRuntime;

        public DialogService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await jSRuntime.InvokeVoidAsync("showAlert", title, message, cancel);
        }
    }
}
