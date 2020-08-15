using Newtonsoft.Json;
using OpenTK.Graphics.OpenGL4;
using GIP.IO.Json;
using GIP.IO.Json.Converter;
using Newtonsoft.Json.Converters;

namespace GIP.IO.Project
{
    [JsonConverter(typeof(JsonVariableConverter))]
    public abstract class JsonVariable : JsonDataObject, IJsonSubClassSerializable
    {

        [JsonProperty(PropertyName = "name")]
        public string Name
        { get; set; } = "";

        public abstract string GetSubClassIdentifier();
    }

    public class JsonTextureVariable : JsonVariable
    {
        [JsonProperty(PropertyName = "format"), JsonConverter(typeof(StringEnumConverter))]
        public PixelInternalFormat Format
        { get; set; } = PixelInternalFormat.Rgba;

        [JsonProperty(PropertyName = "data_type"), JsonConverter(typeof(StringEnumConverter))]
        public PixelType DataType
        { get; set; } = PixelType.UnsignedByte;

        [JsonProperty(PropertyName = "pixel_initializer")]
        public JsonTexturePixelInitializer PixelInitializer
        { get; set; } = new JsonTexturePixelColorInitializer();

        public override string GetSubClassIdentifier() => "Texture";
    }

}
