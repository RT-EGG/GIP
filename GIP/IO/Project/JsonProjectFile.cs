using System.Collections.Generic;
using Newtonsoft.Json;
using GIP.IO.Json;

namespace GIP.IO.Project
{
    public class JsonProjectFile : JsonDataObject
    {
        [JsonProperty(PropertyName = "shader_sources")]
        public List<JsonShaderSource> ShaderSources
        { get; set; } = new List<JsonShaderSource>();

        [JsonProperty(PropertyName = "variables")]
        public List<JsonVariable> Variables
        { get; set; } = new List<JsonVariable>();

        [JsonProperty(PropertyName = "task_sequence")]
        public JsonTaskSequence TaskSequence
        { get; set; } = new JsonTaskSequence();
    }
}
