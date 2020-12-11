using Newtonsoft.Json;
using GIP.Common;

namespace GIP.IO.Json
{
    public class JsonColorRGBA : JsonSerializable
    {
        public JsonColorRGBA()
            : this(0, 0, 0)
        { }

        public JsonColorRGBA(byte inR, byte inG, byte inB, byte inA = 255)
        {
            R = inR;
            G = inG;
            B = inB;
            A = inA;
            return;
        }

        public JsonColorRGBA(ColorRGB inRGB, byte inA = 255)
            : this(inRGB.R, inRGB.G, inRGB.B, inA)
        { }

        public JsonColorRGBA(ColorRGBA inRGBA)
            : this(inRGBA, inRGBA.A)
        { }

        [JsonProperty(PropertyName = "r")]
        public byte R
        { get; set; } = 0;
        [JsonProperty(PropertyName = "g")]
        public byte G
        { get; set; } = 0;
        [JsonProperty(PropertyName = "b")]
        public byte B
        { get; set; } = 0;
        [JsonProperty(PropertyName = "a")]
        public byte A
        { get; set; } = 0;

        public static implicit operator ColorRGBA(JsonColorRGBA inValue)
        {
            return new ColorRGBA(inValue.R, inValue.G, inValue.B, inValue.A);
        }
    }
}
