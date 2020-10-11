using Newtonsoft.Json;
using GIP.IO.Json;

namespace GIP.IO
{
    public class JsonWindowLayout : JsonSerializable
    {
        [JsonProperty("location")]
        public JsonVector2i Location
        { get; set; } = null;

        [JsonProperty("size")]
        public JsonVector2i Size
        { get; set; } = null;

        [JsonProperty("dock_form_layout")]
        public string DockFormLayout
        { get; set; } = null;
    }
}
