using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenTK.Graphics.OpenGL4;
using GIP.IO.Json;

namespace GIP.IO.Project
{
    public class JsonTextureInitializer : JsonDataObject
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name
        { get; set; } = "";

        [JsonProperty(PropertyName = "Format"), JsonConverter(typeof(StringEnumConverter))]
        public PixelInternalFormat Format
        { get; set; } = PixelInternalFormat.Rgba;

        [JsonProperty(PropertyName = "DataType"), JsonConverter(typeof(StringEnumConverter))]
        public PixelType DataType
        { get; set; } = PixelType.UnsignedByte;

        [JsonProperty(PropertyName = "PixelInitializer")]
        public JsonTexturePixelInitializer PixelInitializer
        { get; set; } = new JsonTexturePixelColorInitializer();
    }
}
