using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenTK.Graphics.OpenGL4;
using GIP.IO.Json;
using GIP.IO.Json.Converter;

namespace GIP.IO.Project
{
    [JsonConverter(typeof(JsonTexturePixelInitializerConverter))]
    public abstract class JsonTexturePixelInitializer : JsonDataObject, IJsonSubClassSerializable
    {
        public abstract string GetSubClassIdentifier();
    }

    public class JsonTexturePixelColorInitializer : JsonTexturePixelInitializer
    {
        [JsonProperty(PropertyName = "clear_color")]
        public JsonColorRGBA ClearColor
        { get; set; } = new JsonColorRGBA();
        [JsonProperty(PropertyName = "width")]
        public int Width
        { get; set; } = 0;
        [JsonProperty(PropertyName = "height")]
        public int Height
        { get; set; } = 0;
        [JsonProperty(PropertyName = "pixel_format"), JsonConverter(typeof(StringEnumConverter))]
        public PixelFormat PixelFormat
        { get; set; } = PixelFormat.Rgba;

        public override string GetSubClassIdentifier() => "Color";
    }

    public class JsonTexturePixelFileInitializer : JsonTexturePixelInitializer
    {
        [JsonProperty(PropertyName = "path")]
        public string Path
        { get; set; } = "";

        public override string GetSubClassIdentifier() => "File";
    }
}
