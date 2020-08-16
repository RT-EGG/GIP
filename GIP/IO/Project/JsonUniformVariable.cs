using Newtonsoft.Json;
using GIP.IO.Json;

namespace GIP.IO.Project
{
    public class JsonUniformVariable : JsonDataObject
    {
        [JsonProperty(PropertyName = "UniformName")]
        public string UniformName
        { get; set; } = "";

        [JsonProperty(PropertyName = "Value")]
        public JsonUniformVariableValue Value
        { get; set; }
    }
}
