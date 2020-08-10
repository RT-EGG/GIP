using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenTK.Graphics.OpenGL4;
using GIP.IO.Json;
using GIP.IO.Json.Converter;

namespace GIP.IO.Project
{
    [JsonConverter(typeof(JsonVariableConverter))]
    public abstract class JsonVariable : JsonSerializable, IJsonSubClassSerializable
    {
        private const string JsonName_Type = "VariableType";
        public static JsonVariable ReadJson(JObject inObject)
        {
            switch (inObject.Get<string>(JsonName_Type)) {
                case "Texture":
                    return new JsonTextureVariable();
                default:
                    throw new JsonReaderException();
            }
        }

        public virtual void ReadProperties(JObject inObject)
        {
            Name = inObject.Get<string>("name");
            return;
        }

        public virtual void WriteProperties(JsonWriter inWriter)
        {
            inWriter.WritePropertyName(JsonName_Type);
            inWriter.WriteValue(VariableType);
            return;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name
        { get; set; } = "";

        protected abstract string VariableType { get; }
    }

    public class JsonTextureVariable : JsonVariable
    {
        [JsonProperty(PropertyName = "format")]
        public PixelInternalFormat Format
        { get; set; } = PixelInternalFormat.Rgba;

        [JsonProperty(PropertyName = "data_type")]
        public PixelType DataType
        { get; set; } = PixelType.UnsignedByte;

        [JsonProperty(PropertyName = "pixel_initializer")]
        public JsonTexturePixelInitializer PixelInitializer
        { get; set; } = new JsonTexturePixelColorInitializer();

        protected override string VariableType => "Texture";
    }

}
