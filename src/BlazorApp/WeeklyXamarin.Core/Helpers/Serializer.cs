using Newtonsoft.Json;

namespace WeeklyXamarin.Core.Helpers
{
    public class Serializer
    {
        public static string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
