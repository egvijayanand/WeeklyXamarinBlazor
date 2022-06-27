using System.Text.Json;

namespace WeeklyXamarin.Core.Helpers
{
    public class Serializer
    {
        public static string ToJson<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static T ToObject<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
