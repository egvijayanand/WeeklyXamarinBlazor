namespace WeeklyXamarin.Core.Helpers
{
    public class Constants
    {
        public const string AppTitle = "Weekly Xamarin";

        public class Keys
        {
            public const string Enter = nameof(Enter);
        }

        public class DataStore
        {
            public const string GitHub = nameof(GitHub);
        }

        public class LocalStorage
        {
            public const string Bookmarks = "bookmarks";
        }

        public static class Navigation
        {
            public static class Paths
            {
                public const string Editions = nameof(Editions);
                public const string Bookmarks = nameof(Bookmarks);
                public const string Search = nameof(Search);
                public const string About = nameof(About);

                public const string Edition = nameof(Edition);
                public const string Article = nameof(Article);
                public const string Web = nameof(Web);
            }

            public static class ParameterNames
            {
                public const string ArticleId = "ArticleId";
                public const string EditionId = "EditionId";
                public const string SearchQuery = "q";
                public const string SearchType = "type";
                public const string WebLink = "link";
            }

            public static class FilterType
            {
                public const string Keyword = nameof(Keyword);
                public const string Category = nameof(Category);
            }
        }

        public static class Analytics
        {
            public static class ParameterNames
            {
                public const string Source = "utm_source";
                public const string Medium = "utm_medium";
                public const string Campaign = "utm_campaign";
                public const string Term = "utm_term";
                public const string Content = "utm_content";
            }
        }
    }
}
