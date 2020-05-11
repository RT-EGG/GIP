using System;
using Newtonsoft.Json;
using GIP.IO.Project;
using Newtonsoft.Json.Linq;

namespace GIP.IO.Json.Converter
{
    class JsonTexturePixelInitializerConverter : JsonConverter
    {
        public override bool CanConvert(Type inType)
        {
            return typeof(JsonTexturePixelInitializer).IsAssignableFrom(inType);
        }

        public override object ReadJson(JsonReader inReader, Type inObjectType, object inExistingValue, JsonSerializer inSerializer)
        {
            JObject jObject = JObject.Load(inReader);
            var result = JsonTexturePixelInitializer.ReadJson(jObject);
            result.ReadProperties(jObject);
            return result;
        }

        public override void WriteJson(JsonWriter inWriter, object inValue, JsonSerializer inSerializer)
        {
            inWriter.WriteStartObject();
            (inValue as JsonTexturePixelInitializer).WriteProperties(inWriter);
            inWriter.WriteEndObject();
            return;
        }
    }
}
