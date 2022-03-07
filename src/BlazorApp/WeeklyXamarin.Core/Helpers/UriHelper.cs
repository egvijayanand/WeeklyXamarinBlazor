using static WeeklyXamarin.Core.Helpers.Constants.Navigation;

namespace WeeklyXamarin.Core.Helpers
{
    public static class UriHelper
    {
        public static Dictionary<string, object> QueryParameters(string articleId, string content)
        {
            return new Dictionary<string, object>
            {
                { ParameterNames.ArticleId, articleId },
                { Constants.Analytics.ParameterNames.Content, content }
            };
        }
    }
}
