namespace BlazorApp.WinForms.Services
{
    public class ShareService : IShareService
    {
        public ShareService()
        {

        }

        public Task ShareTextAsync(string title, string text)
        {
            throw new NotImplementedException();
        }

        public Task ShareUriAsync(string title, string text, string url)
        {
            throw new NotImplementedException();
        }
    }
}
