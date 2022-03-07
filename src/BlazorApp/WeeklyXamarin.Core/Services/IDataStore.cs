using WeeklyXamarin.Core.Models;

namespace WeeklyXamarin.Core.Services
{
    public interface IDataStore
    {
        // Connectivity
        void UpdateNetworkStatus(bool connected);

        // Editions
        Task<IEnumerable<Edition>> GetEditionsAsync(bool forceRefresh = false);

        Task<Edition> GetEditionAsync(string id, bool forceRefresh = false, bool cacheLocal = true);

        // Articles
        Task<Article> GetArticleAsync(string editionId, string articleId, bool forceRefresh = false, bool cacheLocal = true);

        // Bookmarks

        Task<Bookmark> GetBookmarks(bool forceRefresh = false);

        Task BookmarkArticle(Article articleToSave);

        Task UnbookmarkArticle(Article articleToRemove);

        // Search

        IAsyncEnumerable<Article> GetArticleFromSearchAsync(string searchText, CancellationToken token, bool forceRefresh = false);

        // Category

        Task<IEnumerable<Category>> GetCategories(bool forceRefresh = false);

        IAsyncEnumerable<Article> GetArticleByCategoryAsync(string category, CancellationToken token, bool forceRefresh = false);
    }
}
