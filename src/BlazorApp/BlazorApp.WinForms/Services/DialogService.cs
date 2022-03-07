using Microsoft.VisualBasic;

namespace BlazorApp.WinForms.Services
{
    public class DialogService : IDialogService
    {
        public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            throw new NotImplementedException();
        }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            _ = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Task.FromResult(true);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            return Task.FromResult(result == DialogResult.OK);
        }

        public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, InputType inputType = InputType.Default, string initialValue = "")
        {
            var result = Interaction.InputBox(message, title);
            return Task.FromResult(result);
        }
    }
}
