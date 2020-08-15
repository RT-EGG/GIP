using Newtonsoft.Json;
using GIP.IO.Json;
using GIP.IO.Json.Converter;

namespace GIP.IO.Project
{
    [JsonConverter(typeof(JsonUniformVariableValueConverter))]
    abstract class JsonUniformVariableValue : JsonDataObject, IJsonSubClassSerializable
    {
        public abstract string GetSubClassIdentifier();
    }

    class JsonUniformVariableTextureValue : JsonUniformVariableValue
    {
        [JsonProperty(PropertyName = "TextureIndex")]
        public int TextureIndex
        { get; set; } = -1;

        public override string GetSubClassIdentifier() => "Texture";
    }
}
