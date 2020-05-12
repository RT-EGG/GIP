using System.Collections.Generic;
using Newtonsoft.Json;
using GIP.IO.Json;

namespace GIP.IO.Project
{
    public class JsonImageProcessTask : JsonSerializable
    {
        [JsonProperty(PropertyName = "SourceFile")]
        public string SourceFile
        { get; set; } = "";

        [JsonProperty(PropertyName = "DispatchSize")]
        public JsonVector3i DispatchSize
        { get; set; } = new JsonVector3i(64, 64, 64);

        [JsonProperty(PropertyName = "UniformVariables")]
        public List<JsonUniformVariable> UniformVariables
        { get; set; } = new List<JsonUniformVariable>();
    }
}
