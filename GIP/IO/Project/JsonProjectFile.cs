using System.Collections.Generic;
using Newtonsoft.Json;
using GIP.IO.Json;

namespace GIP.IO.Project
{
    public class JsonProjectFile : JsonSerializable
    {
        [JsonProperty(PropertyName = "TextureInitializer")]
        public List<JsonTextureInitializer> TextureInitializer
        { get; set; } = new List<JsonTextureInitializer>();

        [JsonProperty(PropertyName = "Tasks")]
        public List<JsonImageProcessTask> Tasks
        { get; set; } = new List<JsonImageProcessTask>();
    }
}
