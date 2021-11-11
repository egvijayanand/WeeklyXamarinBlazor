namespace WeeklyXamarin.Core.Extensions
{
    public static class StringExtensions
    {
        public static string HashTag(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? null : $"#{str}";
        }
    }
}
