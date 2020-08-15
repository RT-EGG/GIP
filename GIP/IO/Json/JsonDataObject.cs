using System;
using Newtonsoft.Json;

namespace GIP.IO.Json
{
    class JsonDataObject : JsonSerializable
    {
        [JsonProperty(PropertyName = "guid")]
        public Guid GUID
        { get; set; } = Guid.NewGuid();
    }
}
