using Newtonsoft.Json;
using GIP.IO.Json.Converter;
using GIP.IO.Json;

namespace GIP.IO.Project
{
    [JsonConverter(typeof(JsonShaderSourceConverter))]
    abstract class JsonShaderSource : JsonDataObject, IJsonSubClassSerializable
    {
        [JsonProperty(PropertyName = "file_path")]
        public string FilePath
        { get; set; } = "";

        public abstract string GetSubClassIdentifier();
    }


    class JsonShaderTextSource : JsonShaderSource
    {
        public override string GetSubClassIdentifier() => "Text";
    }
}
