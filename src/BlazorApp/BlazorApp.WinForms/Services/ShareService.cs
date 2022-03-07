using Microsoft.Maui.Essentials;

namespace BlazorApp.WinForms.Services
{
    public class ShareService : IShareService
    {
        readonly IDialogService dialogService;

        public ShareService(IDialogService dialogService)
        {
            this.dialogService = dialogService;

        }

        public async Task ShareText(string title, string text)
        {
            try
            {
                await Share.RequestAsync(text, title);
            }
            catch (Exception ex)
            {
                await dialogService.DisplayAlert(title, ex.Message, "OK");
            }
        }

        public async Task ShareUri(string title, string text, string url)
        {
            try
            {
                await Share.RequestAsync(new ShareTextRequest(text, title) { Uri = url });
            }
            catch (Exception ex)
            {
                await dialogService.DisplayAlert(title, ex.Message, "OK");
            }
        }
    }
}
