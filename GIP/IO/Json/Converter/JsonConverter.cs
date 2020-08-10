using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace GIP.IO.Json.Converter
{
    interface IJsonSubClassSerializable
    {
        void ReadProperties(JObject inObject);
        void WriteProperties(JsonWriter inWriter);
    }

    abstract class JsonConverter<T> : JsonConverter where T : IJsonSubClassSerializable
    {
        public override bool CanConvert(Type inType)
        {
            return typeof(T).IsAssignableFrom(inType);
        }

        public override object ReadJson(JsonReader inReader, Type inObjectType, object inExistingValue, JsonSerializer inSerializer)
        {
            JObject jObject = JObject.Load(inReader);
            var result = GenerateObject(jObject);
            result.ReadProperties(jObject);
            return result;
        }

        public override void WriteJson(JsonWriter inWriter, object inValue, JsonSerializer inSerializer)
        {
            inWriter.WriteStartObject();
            ((T)inValue).WriteProperties(inWriter);
            inWriter.WriteEndObject();
            return;
        }

        protected abstract T GenerateObject(JObject inObject);
    }
}
