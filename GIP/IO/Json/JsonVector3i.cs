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

        [JsonProperty(PropertyName = "x")]
        public int X
        { get; set; } = 0;

        [JsonProperty(PropertyName = "y")]
        public int Y
        { get; set; } = 0;

        [JsonProperty(PropertyName = "z")]
        public int Z
        { get; set; } = 0;
    }
}
