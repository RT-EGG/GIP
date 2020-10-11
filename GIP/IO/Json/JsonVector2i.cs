using Newtonsoft.Json;

namespace GIP.IO.Json
{
    public class JsonVector2i
    {
        public JsonVector2i()
        { }
        public JsonVector2i(int inX, int inY)
        {
            X = inX;
            Y = inY;
            return;
        }

        [JsonProperty(PropertyName = "x")]
        public int X
        { get; set; } = 0;

        [JsonProperty(PropertyName = "y")]
        public int Y
        { get; set; } = 0;

        public static explicit operator System.Drawing.Point(JsonVector2i inSrc)
        {
            return new System.Drawing.Point(inSrc.X, inSrc.Y);
        }

        public static explicit operator JsonVector2i(System.Drawing.Point inSrc)
        {
            return new JsonVector2i(inSrc.X, inSrc.Y);
        }

        public static explicit operator System.Drawing.Size(JsonVector2i inSrc)
        {
            return new System.Drawing.Size(inSrc.X, inSrc.Y);
        }

        public static explicit operator JsonVector2i(System.Drawing.Size inSrc)
        {
            return new JsonVector2i(inSrc.Width, inSrc.Height);
        }
    }
}
