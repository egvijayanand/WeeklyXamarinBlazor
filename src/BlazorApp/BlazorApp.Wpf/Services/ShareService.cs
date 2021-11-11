using Microsoft.Maui.Essentials;
using System.Threading.Tasks;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.Wpf.Services
{
    public class ShareService : IShareService
    {
        public async Task ShareText(string title, string text)
        {
            await Share.RequestAsync(text, title);
        }

        public async Task ShareUri(string title, string text, string url)
        {
            await Share.RequestAsync(new ShareTextRequest(text, title) { Uri = url });
        }
    }
}
