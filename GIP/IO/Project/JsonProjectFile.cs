using System.Collections.Generic;
using Newtonsoft.Json;
using GIP.IO.Json;

namespace GIP.IO.Project
{
    class JsonProjectFile : JsonSerializable
    {
        [JsonProperty(PropertyName = "TextureInitializer")]
        public List<JsonTextureInitializer> TextureInitializer
        { get; set; } = new List<JsonTextureInitializer>();
    }
}
