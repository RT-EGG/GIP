using Newtonsoft.Json.Linq;

namespace GIP.IO
{
    public static class NewtonsoftJsonExtensions
    {
        public static T Get<T>(this JObject inObject, string inKeyword, T inDefault = default)
        {
            JToken result = inObject[inKeyword];
            return (result == null) ? inDefault : result.ToObject<T>();
        }
    }
}
