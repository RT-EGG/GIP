using Newtonsoft.Json.Linq;
using GIP.IO.Project;

namespace GIP.IO.Json.Converter
{
    class JsonVariableConverter : JsonConverter<JsonVariable>
    {
        protected override JsonVariable GenerateObject(JObject inObject)
        {
            return JsonVariable.ReadJson(inObject);
        }
    }
}
