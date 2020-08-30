using GIP.Core;
using GIP.IO.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GIP.IO.Project
{
    public class JsonComputeShader : JsonDataObject
    {
        [JsonProperty(PropertyName = "file_type"), JsonConverter(typeof(StringEnumConverter))]
        public ComputeShaderFileType FileType
        { get; set; } = ComputeShaderFileType.Text;

        [JsonProperty(PropertyName = "file_path")]
        public string FilePath
        { get; set; } = "";
    }
}
