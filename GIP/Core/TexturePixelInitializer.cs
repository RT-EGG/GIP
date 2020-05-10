using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL4;
using rtUtility.rtMath;

namespace GIP.Core
{
    public abstract class TexturePixelInitializer
    {
        public abstract int TextureWidth { get; }
        public abstract int TextureHeight { get; }
        public abstract PixelFormat PixelFormat { get; }
        public abstract IntPtr GenerateBufferTaskMem(PixelType inType);

        public class Color : TexturePixelInitializer
        {
            public TColorRGB RGB
            { get; set; } = new TColorRGB();
            public float Alpha
            { get; set; } = 1.0f;

            public override int TextureWidth => 2048;
            public override int TextureHeight => 2048;
            public override PixelFormat PixelFormat => PixelFormat.Rgba;
            public override IntPtr GenerateBufferTaskMem(PixelType inType)
            {
                switch (inType) {
                    case PixelType.UnsignedByte:
                        IntPtr result = Marshal.AllocCoTaskMem(TextureWidth * TextureHeight * 4);
                        byte[] buffer = new byte[TextureWidth * TextureHeight * 4];
                        byte[] pixel = new byte[4] {
                            RGB.Rb, RGB.Gb, RGB.Bb,  (byte)Math.Truncate((Alpha * 255.0f) + 0.5f)
                        };
                        for (int i = 0; i < buffer.Length; i += 4) {
                            Array.Copy(pixel, 0, buffer, i, 4);
                        }
                        Marshal.Copy(buffer, 0, result, buffer.Length);
                        return result;
                }
                return (IntPtr)null;
            }
        }

        public class File : TexturePixelInitializer
        {
            public string Path
            { get; set; } = "";

            public override int TextureWidth => throw new System.NotImplementedException();
            public override int TextureHeight => throw new System.NotImplementedException();
            public override PixelFormat PixelFormat => throw new NotImplementedException();
            public override IntPtr GenerateBufferTaskMem(PixelType inType)
            {
                throw new NotImplementedException();
            }
        }
    }
}
