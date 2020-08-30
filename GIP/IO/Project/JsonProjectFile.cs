using System.Collections.Generic;
using Newtonsoft.Json;
using GIP.IO.Json;

namespace GIP.IO.Project
{
    public class JsonProjectFile : JsonDataObject
    {
        [JsonProperty(PropertyName = "compute_shader")]
        public List<JsonComputeShader> ComputeShader
        { get; set; } = new List<JsonComputeShader>();

        [JsonProperty(PropertyName = "variables")]
        public List<JsonVariable> Variables
        { get; set; } = new List<JsonVariable>();

        [JsonProperty(PropertyName = "task_sequence")]
        public JsonTaskSequence TaskSequence
        { get; set; } = new JsonTaskSequence();
    }
}
