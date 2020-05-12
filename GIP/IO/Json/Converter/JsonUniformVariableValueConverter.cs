using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GIP.IO.Project;

namespace GIP.IO.Json.Converter
{
    public class JsonUniformVariableValueConverter : JsonConverter
    {
        public override bool CanConvert(Type inType)
        {
            return typeof(JsonUniformVariableValue).IsAssignableFrom(inType);
        }

        public override object ReadJson(JsonReader inReader, Type inObjectType, object inExistingValue, JsonSerializer inSerializer)
        {
            JObject jObject = JObject.Load(inReader);
            var result = JsonUniformVariableValue.ReadJson(jObject);
            result.ReadProperties(jObject);
            return result;
        }

        public override void WriteJson(JsonWriter inWriter, object inValue, JsonSerializer inSerializer)
        {
            inWriter.WriteStartObject();
            (inValue as JsonUniformVariableValue).WriteProperties(inWriter);
            inWriter.WriteEndObject();
            return;
        }
    }
}
