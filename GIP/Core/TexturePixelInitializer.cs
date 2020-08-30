using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL4;
using rtUtility.rtMath;
using GIP.Common;
using GIP.IO.Project;
using GIP.IO.Json;
using System.Collections.Generic;

namespace GIP.Core
{
    public interface ITexturePixelInitializer : IDataObjectBase
    {
        int TextureWidth { get; }
        int TextureHeight { get; }
        PixelFormat PixelFormat { get; }
        IntPtr GenerateBufferTaskMem(PixelType inType);
    }

    public abstract class TexturePixelInitializer
    {
        public static ITexturePixelInitializer CreateFrom(JsonTexturePixelInitializer inSource)
        {
            switch (inSource) {
                case JsonTexturePixelColorInitializer color:
                    return new TexturePixelInitializer.Color();
                case JsonTexturePixelFileInitializer file:
                    return new TexturePixelInitializer.File();
            }
            return null;
        }

        public class Color : DataObjectBase, ITexturePixelInitializer
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

            public override bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
            {
                if (!base.ReadJson(inSource, inBuffer, inLogger)) {
                    return false;
                }

                var src = inSource as JsonTexturePixelColorInitializer;
                RGB = src.ClearColor;
                Alpha = src.ClearColor.A / 255.0f;
                TextureWidth = src.Width;
                TextureHeight = src.Height;
                PixelFormat = src.PixelFormat;
                return true;
            }

            protected override JsonDataObject CreateJson() => new JsonTexturePixelColorInitializer();
            protected override void ExportToJson(JsonDataObject inDst)
            {
                base.ExportToJson(inDst);

                (inDst as JsonTexturePixelColorInitializer).ClearColor = new JsonColorRGBA(RGB, (byte)(Alpha * 255.0f));
                (inDst as JsonTexturePixelColorInitializer).Width = TextureWidth;
                (inDst as JsonTexturePixelColorInitializer).Height = TextureHeight;
                (inDst as JsonTexturePixelColorInitializer).PixelFormat = PixelFormat;
                return;
            }

            protected override IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonTexturePixelColorInitializer) };
        }

        public class File : DataObjectBase, ITexturePixelInitializer
        {
            public string FilePath
            { get; set; } = "";

            public int TextureWidth
            { get; private set; } = 0;
            public int TextureHeight
            { get; private set; } = 0;
            public PixelFormat PixelFormat
            { get; private set; } = PixelFormat.Bgra;

            public IntPtr GenerateBufferTaskMem(PixelType inType)
            {
                if (!System.IO.File.Exists(FilePath)) {
                    throw new FileNotFoundException($"Image file \"{FilePath}\" is not found.", FilePath);
                }

                IntPtr result = (IntPtr)null;
                Bitmap bitmap = new Bitmap(FilePath);
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
                TextureWidth = bitmap.Width;
                TextureHeight = bitmap.Height;

                System.Drawing.Imaging.BitmapData bmpData = null;
                try {
                    switch (inType) {
                        case PixelType.UnsignedByte:
                            bmpData = bitmap.LockBits(bitmap.FullRectangle(), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            result = Marshal.AllocCoTaskMem(TextureWidth * TextureHeight * 4);

                            CMethods.CopyMemory(result, bmpData.Scan0, (uint)(TextureWidth * TextureHeight * 4));
                            break;
                    }

                } finally {
                    if (bmpData != null) {
                        bitmap.UnlockBits(bmpData);
                    }
                    bitmap.Dispose();
                }

                return result;
            }

            public override bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
            {
                if (!base.ReadJson(inSource, inBuffer, inLogger)) {
                    return false;
                }

                var src = inSource as JsonTexturePixelFileInitializer;
                FilePath = src.Path;
                return true;
            }

            protected override JsonDataObject CreateJson() => new JsonTexturePixelFileInitializer();
            protected override void ExportToJson(JsonDataObject inDst)
            {
                base.ExportToJson(inDst);

                (inDst as JsonTexturePixelFileInitializer).Path = FilePath;
                return;
            }

            protected override IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonTexturePixelFileInitializer) };
        }
    }
}
