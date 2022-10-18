using Microsoft.JSInterop;
using VijayAnand.MauiToolkit.Core;
using VijayAnand.MauiToolkit.Core.Services;

namespace BlazorApp.Wasm.Services
{
	public class DialogService : IDialogService
	{
		//private readonly IJSInProcessRuntime jsRuntime;
		private readonly IJSRuntime jsRuntime;

		public DialogService(IJSRuntime jsRuntime)
		{
			this.jsRuntime = jsRuntime;
		}

		public Task<string> DisplayActionSheetAsync(string title, string cancel, string destruction, params string[] buttons)
		{
			throw new NotImplementedException();
		}

		public Task<string> DisplayActionSheetAsync(string title, string message, string cancel, string destruction, string defaultButton, params string[] buttons)
		{
			throw new NotImplementedException();
		}

		public async Task DisplayAlertAsync(string title, string message, string cancel)
		{
			//await Task.Run(() => jsRuntime.InvokeVoid("showAlert", title, message, cancel));
			await jsRuntime.InvokeVoidAsync("showAlert", title, message, cancel);
		}

		public Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
		{
			throw new NotImplementedException();
		}

		public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, InputType inputType = InputType.Default, string initialValue = "")
		{
			throw new NotImplementedException();
		}
	}
}
