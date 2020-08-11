using System.Collections.Generic;
using Newtonsoft.Json;
using GIP.IO.Json;

namespace GIP.IO.Project
{
    public class JsonProjectFile : JsonSerializable
    {
        [JsonProperty(PropertyName = "variables")]
        public List<JsonVariable> Variables
        { get; set; } = new List<JsonVariable>();
    }
}
