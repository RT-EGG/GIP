using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace GIP.IO.Json.Converter
{
    interface IJsonSubClassSerializable
    {
        string GetSubClassIdentifier();
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
            T result = GenerateObject(jObject.Get<string>("@class", ""));
            if (result == null) {
                return null;
            }

            inSerializer.Populate(jObject.CreateReader(), result);

            return result;
        }

        public override void WriteJson(JsonWriter inWriter, object inValue, JsonSerializer inSerializer)
        {
            inWriter.WriteStartObject();
            inWriter.WritePropertyName("@class");
            inWriter.WriteValue(((T)inValue).GetSubClassIdentifier());

            foreach (var prop in CollectProperties(inValue)) {
                inWriter.WritePropertyName(prop.Name);

                if (prop.Converter != null) {
                    prop.Converter.WriteJson(inWriter, prop.GetValue(inValue), inSerializer);
                } else {
                    inSerializer.Serialize(inWriter, prop.GetValue(inValue));
                }
            }

            inWriter.WriteEndObject();
            return;
        }

        private IEnumerable<ExportTargetProperty> CollectProperties(object inValue)
        {
            foreach (var prop in inValue.GetType().GetProperties()) {
                var attributes = prop.GetCustomAttributes(true);
                if (attributes.FirstOrDefault(a => a is JsonIgnoreAttribute) != null) {
                    continue;
                }

                var propAtt = (JsonPropertyAttribute)attributes.FirstOrDefault(a => a is JsonPropertyAttribute);
                var convAtt = (JsonConverterAttribute)attributes.FirstOrDefault(a => a is JsonConverterAttribute);

                string name = (propAtt?.PropertyName == null) ? prop.Name : propAtt.PropertyName;
                JsonConverter converter = null;
                if (convAtt != null) {
                    converter = (JsonConverter)Activator.CreateInstance(convAtt.ConverterType, convAtt.ConverterParameters);
                }

                ExportTargetProperty property = new ExportTargetProperty(prop);
                property.Name = (propAtt?.PropertyName == null) ? prop.Name : propAtt.PropertyName;
                property.Converter = convAtt == null ? null : (JsonConverter)Activator.CreateInstance(convAtt.ConverterType, convAtt.ConverterParameters);

                yield return property;
            }

            yield break;
        }

        protected abstract T GenerateObject(string inSubClassIdentifier);

        private class ExportTargetProperty
        {
            public ExportTargetProperty(PropertyInfo inProperty)
            {
                Property = inProperty;
                return;
            }

            public string Name
            { get; set; } = "";
            public JsonConverter Converter
            { get; set; } = null;

            public void SetValue(object inObject, object inValue)
            {
                Property.SetValue(inObject, inValue);
                return;
            }

            public object GetValue(object inObject)
            {
                return Property.GetValue(inObject);
            }

            private PropertyInfo Property
            { get; } = null;
        }
    }
}
