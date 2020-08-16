using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GIP.IO.Json;
using GIP.IO.Json.Converter;

namespace GIP.IO.Project
{
    public abstract class JsonProcessTask : JsonDataObject, IJsonSubClassSerializable
    {
        [JsonProperty(PropertyName = "name")]
        public string Name
        { get; set; } = "";

        public abstract string GetSubClassIdentifier();
    }

    public class JsonComputeTask : JsonProcessTask
    {
        [JsonProperty(PropertyName = "shader")]
        public Guid ShaderGuid
        { get; set; } = Guid.Empty;

        [JsonProperty(PropertyName = "uniform_variables")]
        public List<JsonUniformVariable> UniformVariables
        { get; set; } = new List<JsonUniformVariable>();
        
        [JsonProperty(PropertyName = "dispatch_group_size")]
        public JsonVector3i DispatchGroupSize
        { get; set; } = new JsonVector3i(64, 64, 1);

        public override string GetSubClassIdentifier() => "Compute";
    }

    public class JsonTaskSequence : JsonProcessTask
    {
        [JsonProperty(PropertyName = "tasks")]
        public List<JsonProcessTask> Tasks
        { get; set; } = new List<JsonProcessTask>();

        public override string GetSubClassIdentifier() => "Sequence";
    }
}
