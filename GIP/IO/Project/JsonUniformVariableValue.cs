using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GIP.IO.Json;
using GIP.IO.Json.Converter;

namespace GIP.IO.Project
{
    [JsonConverter(typeof(JsonUniformVariableValueConverter))]
    public abstract class JsonUniformVariableValue : JsonSerializable
    {
        public static JsonUniformVariableValue ReadJson(JObject inObject)
        {
            switch (inObject.Get<string>("Type")) {
                case "Texture":
                    return new JsonUniformVariableTextureValue();
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
            inWriter.WritePropertyName("Type");
            inWriter.WriteValue(ValueType);
            return;
        }

        public abstract string ValueType { get; }
    }

    public class JsonUniformVariableTextureValue : JsonUniformVariableValue
    {
        [JsonProperty(PropertyName = "TextureIndex")]
        public int TextureIndex
        { get; set; } = 0;

        public override void ReadProperties(JObject inObject)
        {
            base.ReadProperties(inObject);

            TextureIndex = inObject.Get<int>("TextureIndex", -1);
            return;
        }

        public override void WriteProperties(JsonWriter inWriter)
        {
            base.WriteProperties(inWriter);

            inWriter.WritePropertyName("TextureIndex");
            inWriter.WriteValue(TextureIndex);
            return;
        }

        public override string ValueType => "Texture";
    }
}
