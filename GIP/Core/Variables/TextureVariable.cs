using System;
using System.Runtime.InteropServices;
using Reactive.Bindings;
using OpenTK.Graphics.OpenGL4;
using GIP.Common;

namespace GIP.Core.Variables
{
    public class TextureVariable : VariableBase
    {
        public TextureVariable()
        {
            Format.Subscribe(f => m_ValueString.Value = ToValueString());
            DataType.Subscribe(d => m_ValueString.Value = ToValueString());
            return;
        }

        public TextureVariable(TextureVariable inSrc)
            : this()
        {
            Format = inSrc.Format;
            DataType = inSrc.DataType;
            return;
        }

        public override void InitializeVariable()
        {
            base.InitializeVariable();

            if (TextureID == 0) {
                TextureID = GL.GenTexture();
            }
            GlTexImage2D();
            return;
        }

        public override void DisposeVariable()
        {
            base.DisposeVariable();

            if (TextureID != 0) {
                GL.DeleteTexture(TextureID);
                TextureID = 0;
            }

            return;
        }

        private void GlTexImage2D()
        {
            IntPtr buffer = PixelInitializer.GenerateBufferTaskMem(DataType.Value);
            if (buffer == null) {
                new NotSupportedException($"Not supports the type({DataType}).");
            }
            GL.BindTexture(TextureTarget.Texture2D, TextureID);
            try {
                ErrorCode error = GL.GetError();
                GL.TexImage2D(TextureTarget.Texture2D, 0, Format.Value, 
                                PixelInitializer.TextureWidth, PixelInitializer.TextureHeight, 
                                0, PixelInitializer.PixelFormat, DataType.Value, buffer);

                error = GL.GetError();
                if (error != ErrorCode.NoError) {
                    throw new GLApiErrorException(error, nameof(GL.TexImage2D));
                }

                GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, new int[] { (int)All.ClampToBorder });
                GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, new int[] { (int)All.ClampToBorder });
                GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, new int[] { (int)All.Nearest });
                GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, new int[] { (int)All.Nearest });

            } finally {
                Marshal.FreeCoTaskMem(buffer);
                GL.BindTexture(TextureTarget.Texture2D, 0);
            }
            return;
        }

        public override string ToString()
        {
            return Name.Value;
        }

        private string ToValueString()
        {
            return $"{ToString(Format.Value)}-{ToString(DataType.Value)}";
        }

        private string ToString(PixelInternalFormat inFormat)
        {
            switch (inFormat) {
                case PixelInternalFormat.Rgb: return "RGB";
                case PixelInternalFormat.Rgba: return "RGBA";
            }
            return "N/A";
        }

        private string ToString(PixelType inType)
        {
            switch (inType) {
                case PixelType.UnsignedByte: return "ubyte";
            }
            return "N/A";
        }

        public override IReadOnlyReactiveProperty<string> ValueString => m_ValueString;
        private ReactiveProperty<string> m_ValueString = new ReactiveProperty<string>("");

        public ReactiveProperty<PixelInternalFormat> Format
        { get; } = new ReactiveProperty<PixelInternalFormat>(PixelInternalFormat.Rgb);
        public ReactiveProperty<PixelType> DataType
        { get; } = new ReactiveProperty<PixelType>(PixelType.UnsignedByte);
        public TexturePixelInitializer PixelInitializer
        { get; set; } = new TexturePixelInitializer.Color();

        public int TextureID
        { get; private set; } = 0;
    }
}
