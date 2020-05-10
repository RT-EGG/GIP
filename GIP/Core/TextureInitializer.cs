using System;
using System.Runtime.InteropServices;
using Reactive.Bindings;
using OpenTK.Graphics.OpenGL4;

namespace GIP.Core
{
    public class TextureInitializer
    {
        public TextureInitializer()
        {
            return;
        }

        public TextureInitializer(TextureInitializer inSrc)
        {
            Format = inSrc.Format;
            DataType = inSrc.DataType;
            return;
        }

        public void GlTexImage2D()
        {
            IntPtr buffer = PixelInitializer.GenerateBufferTaskMem(DataType.Value);
            if (buffer == null) {
                new NotSupportedException($"Not supports the type({DataType}).");
            }
            try {
                GL.TexImage2D(TextureTarget.Texture2D, 0, Format.Value, 
                                PixelInitializer.TextureWidth, PixelInitializer.TextureHeight, 
                                0, PixelInitializer.PixelFormat, DataType.Value, buffer);
            } finally {
                Marshal.FreeCoTaskMem(buffer);
            }
            return;
        }

        public override string ToString()
        {
            return Name.Value;
        }

        public ReactiveProperty<string> Name
        { get; } = new ReactiveProperty<string>("Texture");
        public ReactiveProperty<PixelInternalFormat> Format
        { get; } = new ReactiveProperty<PixelInternalFormat>(PixelInternalFormat.Rgb);
        public ReactiveProperty<PixelType> DataType
        { get; } = new ReactiveProperty<PixelType>(PixelType.UnsignedByte);
        public TexturePixelInitializer PixelInitializer
        { get; set; } = new TexturePixelInitializer.Color();
    }
}
