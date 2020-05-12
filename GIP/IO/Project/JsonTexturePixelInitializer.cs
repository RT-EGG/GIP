using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GIP.IO.Json;
using GIP.IO.Json.Converter;

namespace GIP.IO.Project
{
    [JsonConverter(typeof(JsonTexturePixelInitializerConverter))]
    public abstract class JsonTexturePixelInitializer
    {
        public static JsonTexturePixelInitializer ReadJson(JObject inObject)
        {
            switch (inObject.Get<string>("InitializerType")) {
                case "Color":
                    return new JsonTexturePixelColorInitializer();
                case "File":
                    return new JsonTexturePixelFileInitializer();
                default:
                    throw new JsonReaderException();
            }
        }

        public virtual void ReadProperties(JObject inObject)
        {
            return;
        }

        public virtual void WriteProperties(JsonWriter inWriter)
        {
            inWriter.WritePropertyName("InitializerType");
            inWriter.WriteValue(ColorInitializerType);
            return;
        }

        public abstract string ColorInitializerType { get; }
    }

    public class JsonTexturePixelColorInitializer : JsonTexturePixelInitializer
    {
        [JsonProperty(PropertyName = "R")]
        public byte R
        { get; set; } = 255;
        [JsonProperty(PropertyName = "G")]
        public byte G
        { get; set; } = 255;
        [JsonProperty(PropertyName = "B")]
        public byte B
        { get; set; } = 255;
        [JsonProperty(PropertyName = "A")]
        public byte A
        { get; set; } = 255;

        public override void ReadProperties(JObject inObject)
        {
            base.ReadProperties(inObject);
            R = inObject.Get<byte>("R", 255);
            G = inObject.Get<byte>("G", 255);
            B = inObject.Get<byte>("B", 255);
            R = inObject.Get<byte>("A", 255);
            return;
        }

        public override void WriteProperties(JsonWriter inWriter)
        {
            base.WriteProperties(inWriter);
            inWriter.WritePropertyName("R"); inWriter.WriteValue(R);
            inWriter.WritePropertyName("G"); inWriter.WriteValue(G);
            inWriter.WritePropertyName("B"); inWriter.WriteValue(B);
            inWriter.WritePropertyName("A"); inWriter.WriteValue(A);
            return;
        }

        public override string ColorInitializerType => "Color";
    }

    public class JsonTexturePixelFileInitializer : JsonTexturePixelInitializer
    {
        [JsonProperty(PropertyName = "Path")]
        public string Path
        { get; set; } = "";

        public override void ReadProperties(JObject inObject)
        {
            base.ReadProperties(inObject);
            Path = inObject.Get("Path", "");
            return;
        }

        public override void WriteProperties(JsonWriter inWriter)
        {
            base.WriteProperties(inWriter);
            inWriter.WritePropertyName("Path"); inWriter.WriteValue(Path);
            return;
        }

        public override string ColorInitializerType => "File";
    }
}
