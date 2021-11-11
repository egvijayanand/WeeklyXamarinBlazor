using Microsoft.Maui.Essentials;
using System.Threading.Tasks;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.Services
{
    public class ShareService : IShareService
    {
        public async Task ShareText(string title, string text)
        {
            await Share.RequestAsync(new ShareTextRequest(text, title));
        }

        public async Task ShareUri(string title, string text, string uri)
        {
            await Share.RequestAsync(new ShareTextRequest() { Title = title, Uri = uri });
        }
    }
}
