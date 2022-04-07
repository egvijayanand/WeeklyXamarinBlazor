using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.JSInterop;

namespace WeeklyXamarin.Core.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static bool TryGetQueryString<T>(this NavigationManager navigator, string key, out T value)
        {
            var uri = navigator.ToAbsoluteUri(navigator.Uri);

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(key, out var valueFromQuery))
            {
                if (typeof(T) == typeof(int) && int.TryParse(valueFromQuery, out int valueAsInt))
                {
                    value = (T)(object)valueAsInt;
                    return true;
                }

                if (typeof(T) == typeof(string))
                {
                    value = (T)(object)valueFromQuery.ToString();
                    return true;
                }

                if (typeof(T) == typeof(decimal) && decimal.TryParse(valueFromQuery, out decimal valueAsDecimal))
                {
                    value = (T)(object)valueAsDecimal;
                    return true;
                }
            }

            value = default;
            return false;
        }

        public static ValueTask NavigateToFragmentAsync(this NavigationManager navigator, IJSRuntime jSRuntime)
        {
            var uri = navigator.ToAbsoluteUri(navigator.Uri);
            return uri.Fragment.Length == 0 ? default : jSRuntime.InvokeVoidAsync("scrollToFragment", uri.Fragment[1..]);
        }
    }
}
