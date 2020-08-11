using Newtonsoft.Json;
using rtUtility.rtMath;

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

        public JsonColorRGBA(IROColorRGB inRGB, byte inA = 255)
            : this(inRGB.Rb, inRGB.Gb, inRGB.Bb, inA)
        { }

        public JsonColorRGBA(IROColorRGBA inRGBA)
            : this(inRGBA, inRGBA.Ab)
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
    }
}
