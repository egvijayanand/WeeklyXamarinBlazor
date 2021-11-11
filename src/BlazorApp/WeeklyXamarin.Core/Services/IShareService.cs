using System.Threading.Tasks;

namespace WeeklyXamarin.Core.Services
{
    public interface IShareService
    {
        Task ShareText(string title, string text);

        Task ShareUri(string title, string text, string uri);
    }
}
