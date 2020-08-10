using Newtonsoft.Json.Linq;
using GIP.IO.Project;

namespace GIP.IO.Json.Converter
{
    class JsonUniformVariableValueConverter : JsonConverter<JsonUniformVariableValue>
    {
        protected override JsonUniformVariableValue GenerateObject(JObject inObject)
        {
            return JsonUniformVariableValue.ReadJson(inObject);
        }
    }
}
