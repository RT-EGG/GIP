using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL4;
using rtUtility.rtMath;

namespace GIP.Core
{
    public interface ITexturePixelInitializer
    {
        int TextureWidth { get; }
        int TextureHeight { get; }
        PixelFormat PixelFormat { get; }
        IntPtr GenerateBufferTaskMem(PixelType inType);
    }

    public abstract class TexturePixelInitializer
    {
        public class Color : ITexturePixelInitializer
        {
            public TColorRGB RGB
            { get; set; } = new TColorRGB();
            public float Alpha
            { get; set; } = 1.0f;

            public int TextureWidth
            { get; set; } = 2048;
            public int TextureHeight
            { get; set; } = 2048;
            public PixelFormat PixelFormat
            { get; set; } = PixelFormat.Rgba;
            public IntPtr GenerateBufferTaskMem(PixelType inType)
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

        public class File : ITexturePixelInitializer
        {
            public string Path
            { get; set; } = "";

            public int TextureWidth
            { get; } = 0;
            public int TextureHeight
            { get; } = 0;
            public PixelFormat PixelFormat
            { get; } = PixelFormat.Rgba;
            public IntPtr GenerateBufferTaskMem(PixelType inType)
            {
                throw new NotImplementedException();
            }
        }
    }
}
