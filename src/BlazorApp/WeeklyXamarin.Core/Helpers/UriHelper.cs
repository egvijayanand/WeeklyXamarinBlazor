using System.Collections.Generic;

namespace WeeklyXamarin.Core.Helpers
{
    public static class UriHelper
    {
        public static Dictionary<string, object> QueryParameters(string articleId, string content)
        {
            return new Dictionary<string, object>
            {
                { Constants.Navigation.ParameterNames.ArticleId, articleId },
                { Constants.Analytics.ParameterNames.Content, content }
            };
        }
    }
}
