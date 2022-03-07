namespace WeeklyXamarin.Core.Models
{
    public record Article
    {
        public string Id { get; init; }

        public string EditionId { get; init; }

        public string Title { get; init; }

        public string Author { get; init; }

        public string Description { get; init; }

        public string Category { get; set; }

        public string Url { get; init; }

        public bool IsSaved { get; set; }

        public static string GetEditionId(string articleId)
        {
            return articleId.Substring(0, articleId.IndexOf("-"));
        }

        private string SearchIndex => $"{Title} {Description} {Author} {Category}".ToLowerInvariant();

        internal bool Matches(string searchText)
        {
            var terms = searchText.Trim().ToLowerInvariant().Split('\x20', StringSplitOptions.RemoveEmptyEntries);
            return terms.Any(i => SearchIndex.Contains(i));
        }
    }
}
