using Newtonsoft.Json;

namespace GIP.IO.Json
{
    public class JsonVector3i : JsonSerializable
    {
        public JsonVector3i()
        { }
        public JsonVector3i(int inX, int inY, int inZ)
        {
            X = inX;
            Y = inY;
            Z = inZ;
            return;
        }

        [JsonProperty(PropertyName = "X")]
        public int X
        { get; set; } = 0;

        [JsonProperty(PropertyName = "Y")]
        public int Y
        { get; set; } = 0;

        [JsonProperty(PropertyName = "Z")]
        public int Z
        { get; set; } = 0;
    }
}
