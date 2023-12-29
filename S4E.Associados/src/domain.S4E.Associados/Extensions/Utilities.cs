using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace domain.S4E.Associados.Extensions
{
    public static class Utilities
    {
        public static string ToJson(this object obj)
            => JsonConvert.SerializeObject(obj, Formatting.Indented);

        public static JObject ToJson(this string json)
            => JObject.Parse(json);

        public static string GetErrorMessage(this JObject json)
            => json["error"]["message"].ToString();
    }
}
