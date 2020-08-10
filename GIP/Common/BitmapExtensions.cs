using System.Drawing;

namespace GIP.Common
{
    public static class BitmapExtensions
    {
        public static Rectangle FullRectangle(this Bitmap inBitmap)
        {
            return new Rectangle(0, 0, inBitmap.Width, inBitmap.Height);
        }
    }
}
