using Blazored.LocalStorage;
using System.Runtime.CompilerServices;
using WeeklyXamarin.Core.Helpers;
using WeeklyXamarin.Core.Models;

namespace WeeklyXamarin.Core.Services
{
    public class GitHubDataStore : IDataStore
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;
        private bool hasNetworkConnection;

        //[JSInvokable]
        public void UpdateNetworkStatus(bool connected)
        {
            hasNetworkConnection = connected;
        }

        public GitHubDataStore(IHttpClientFactory clientFactory, ILocalStorageService localStorage)
        {
            httpClient = clientFactory.CreateClient(Constants.DataStore.GitHub);
            this.localStorage = localStorage;
        }

        public async Task<IEnumerable<Edition>> GetEditionsAsync(bool forceRefresh = false)
        {
            Models.Index index = null;

            if (await localStorage.ContainKeyAsync("index"))
            {
                index = await localStorage.GetItemAsync<Models.Index>("index");
            }

            if (forceRefresh || index is null || index.IsStale)
            {
                if (hasNetworkConnection)
                {
                    var responseText = await httpClient.GetStringAsync("index.json");
                    index = Serializer.ToObject<Models.Index>(responseText);
                    index.FetchedDate = DateTime.UtcNow;
                    await localStorage.SetItemAsync("index", index);
                }
            }

            return index?.Editions;
        }

        public async Task<Edition> GetEditionAsync(string id, bool forceRefresh = false, bool cacheLocal = true)
        {
            try
            {
                Edition edition = null;

                if (forceRefresh || !await localStorage.ContainKeyAsync(id))
                {
                    if (hasNetworkConnection)
                    {
                        var responseText = await httpClient.GetStringAsync($"{id}.json");
                        edition = Serializer.ToObject<Edition>(responseText);

                        if (cacheLocal)
                        {
                            await localStorage.SetItemAsync(id, edition);
                        }
                    }
                }
                else
                {
                    edition = await localStorage.GetItemAsync<Edition>(id);
                }

                return edition;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Article> GetArticleAsync(string editionId, string articleId, bool forceRefresh = false, bool cacheLocal = true)
        {
            var edition = await GetEditionAsync(editionId, forceRefresh, cacheLocal);
            return edition?.Articles?.FirstOrDefault(a => a.EditionId == editionId && a.Id == articleId);
        }

        // Search

        public async IAsyncEnumerable<Article> GetArticleFromSearchAsync(string searchText, [EnumeratorCancellation] CancellationToken token, bool forceRefresh = false)
        {
            var editions = await GetEditionsAsync(forceRefresh);

            if (editions != null)
            {
                foreach (var edition in editions)
                {
                    var articles = await GetEditionAsync(edition.Id, forceRefresh);

                    if (articles != null && articles.Articles != null)
                    {
                        foreach (var article in articles.Articles)
                        {
                            if (article.Matches(searchText))
                            {
                                token.ThrowIfCancellationRequested();
                                yield return article;
                            }
                        }
                    }
                }
            }
        }

        public async Task<IEnumerable<Category>> GetCategories(bool forceRefresh = false)
        {
            Tag tag = null;

            if (forceRefresh || !await localStorage.ContainKeyAsync("categories"))
            {
                if (hasNetworkConnection)
                {
                    var responseText = await httpClient.GetStringAsync("categories.json");
                    tag = Serializer.ToObject<Tag>(responseText);
                    await localStorage.SetItemAsync("categories", tag);
                }
            }
            else
            {
                tag = await localStorage.GetItemAsync<Tag>("categories");
            }

            return tag?.Categories;
        }

        public async IAsyncEnumerable<Article> GetArticleByCategoryAsync(string category, [EnumeratorCancellation] CancellationToken token, bool forceRefresh = false)
        {
            var editions = await GetEditionsAsync(forceRefresh);

            if (editions != null)
            {
                foreach (var edition in editions)
                {
                    var articles = await GetEditionAsync(edition.Id, forceRefresh);

                    if (articles != null && articles.Articles != null)
                    {
                        foreach (var article in articles.Articles)
                        {
                            if (article.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                            {
                                token.ThrowIfCancellationRequested();
                                yield return article;
                            }
                        }
                    }
                }
            }
        }

        // Bookmarks

        public async Task<Bookmark> GetBookmarks(bool forceRefresh = false)
        {
            Bookmark bookmark = null;

            if (await localStorage.ContainKeyAsync(Constants.LocalStorage.Bookmarks))
            {
                bookmark = await localStorage.GetItemAsync<Bookmark>(Constants.LocalStorage.Bookmarks);
            }

            if (bookmark == null)
            {
                bookmark = new Bookmark();
            }

            return bookmark;
        }

        public async Task BookmarkArticle(Article articleToSave)
        {
            var bookmarks = await GetBookmarks();
            articleToSave.IsSaved = true;
            bookmarks.Add(articleToSave);

            var edition = await GetEditionAsync(articleToSave.EditionId);
            var article = edition.Articles.FirstOrDefault(x => x.Id == articleToSave.Id);
            article.IsSaved = true;

            await localStorage.SetItemAsync(article.EditionId, edition);
            await localStorage.SetItemAsync(Constants.LocalStorage.Bookmarks, bookmarks);
        }

        public async Task UnbookmarkArticle(Article articleToRemove)
        {
            var bookmarks = await GetBookmarks();
            bookmarks.Remove(articleToRemove);
            articleToRemove.IsSaved = false;

            var edition = await GetEditionAsync(articleToRemove.EditionId);
            var article = edition.Articles.FirstOrDefault(x => x.Id == articleToRemove.Id);
            article.IsSaved = false;

            await localStorage.SetItemAsync(article.EditionId, edition);

            await localStorage.SetItemAsync(Constants.LocalStorage.Bookmarks, bookmarks);
        }
    }
}
