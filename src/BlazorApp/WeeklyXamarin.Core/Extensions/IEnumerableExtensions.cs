using System.Collections.Generic;
using WeeklyXamarin.Core.Helpers;

namespace WeeklyXamarin.Core.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void AddTo<T>(this IEnumerable<T> source, List<T> destination)
        {
            if (source != null)
            {
                destination.AddRange(source);
            }
        }

        public static void AddTo<T>(this IEnumerable<T> source, ObservableRangeCollection<T> destination)
        {
            if (source != null)
            {
                destination.AddRange(source);
            }
        }
    }
}
