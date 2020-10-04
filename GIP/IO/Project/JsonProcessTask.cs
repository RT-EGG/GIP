using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GIP.IO.Json;
using GIP.IO.Json.Converter;

namespace GIP.IO.Project
{
    [JsonConverter(typeof(JsonProcessTaskConverter))]
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

    public class JsonTextureExportTask : JsonProcessTask
    {
        [JsonProperty(PropertyName = "file_path")]
        public string FilePath
        { get; set; } = "";

        [JsonProperty(PropertyName = "texture")]
        public Guid Texture
        { get; set; } = Guid.Empty;

        [JsonProperty(PropertyName = "override")]
        public bool OverwriteIfExistAlready
        { get; set; } = true;

        public override string GetSubClassIdentifier() => "TextureExport";
    }

    public class JsonTaskSequence : JsonProcessTask
    {
        [JsonProperty(PropertyName = "tasks")]
        public List<JsonProcessTask> Tasks
        { get; set; } = new List<JsonProcessTask>();

        public override string GetSubClassIdentifier() => "Sequence";
    }

    public class JsonTaskSequenceCountingForLoop : JsonTaskSequence
    {
        [JsonProperty(PropertyName = "max_loop_count")]
        public int MaxLoopCount
        { get; set; } = 10;

        public override string GetSubClassIdentifier() => "CountingFor";
    }
}
