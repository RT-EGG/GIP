using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using GIP.Core;

namespace GIP.Controls
{
    public partial class Ctrl_GLTextureView : UserControl
    {
        public Ctrl_GLTextureView()
        {
            InitializeComponent();
        }

        public void MakeCurrent()
        {
            GLView.MakeCurrent();
            return;
        }

        private void GLView_OnGLPaint(Ctrl_GLControl inControl)
        {
            GL.Viewport(inControl.ClientRectangle);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            GL.ClearDepth(1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (ComboCurrentTexture.SelectedItem == null) {
                return;
            }

            ComboTextureItem item = ComboCurrentTexture.SelectedItem as ComboTextureItem;
            GL.GetTextureLevelParameter(item.TextureID, 0, GetTextureParameter.TextureWidth, out int texWidth);
            GL.GetTextureLevelParameter(item.TextureID, 0, GetTextureParameter.TextureHeight, out int texHeight);
            if ((texWidth <= 0) || (texHeight <= 0)) {
                return;
            }

            double renderWidth, renderHeight;
            if (((double)texWidth / (double)inControl.Width) > ((double)texHeight / (double)inControl.Height)) {
                renderWidth = inControl.Width;
                renderHeight = ((double)inControl.Width / (double)texWidth) * texHeight;
            } else {
                renderHeight = inControl.Height;
                renderWidth = ((double)inControl.Height / (double)texHeight) * texWidth;
            }
            double x0 = (inControl.Width * 0.5) - (renderWidth * 0.5);
            double x1 = (inControl.Width * 0.5) + (renderWidth * 0.5);
            double y0 = (inControl.Height * 0.5) - (renderHeight * 0.5);
            double y1 = (inControl.Height * 0.5) + (renderHeight * 0.5);

            GL.PushAttrib(AttribMask.AllAttribBits);
            try {
                GL.Color3(1.0, 1.0, 1.0);
                GL.Enable(EnableCap.Texture2D);
                GL.Disable(EnableCap.Lighting);

                GL.MatrixMode(MatrixMode.Modelview);
                GL.PushMatrix();
                try {
                    GL.LoadIdentity();

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.PushMatrix();
                    try {
                        GL.LoadIdentity();
                        GL.Ortho(0.0, inControl.Width, 0.0, inControl.Height, -1.0, 1.0);

                        GL.ActiveTexture(TextureUnit.Texture0);
                        GL.BindTexture(TextureTarget.Texture2D, item.TextureID);
                        try {
                            GL.Begin(PrimitiveType.Quads);
                            GL.TexCoord2(0.0, 1.0); GL.Vertex2(x0, y1);
                            GL.TexCoord2(0.0, 0.0); GL.Vertex2(x0, y0);
                            GL.TexCoord2(1.0, 0.0); GL.Vertex2(x1, y0);
                            GL.TexCoord2(1.0, 1.0); GL.Vertex2(x1, y1);
                            GL.End();

                        } finally {
                            GL.BindTexture(TextureTarget.Texture2D, 0);
                        }

                    } finally {
                        GL.PopMatrix();
                    }
                } finally {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.PopMatrix();
                }
            } finally {
                GL.PopAttrib();
            }
            return;
        }

        public ShaderResources Resources
        {
            get => m_Resources;
            set {
                if (m_Resources == value) {
                    return;
                }

                m_Resources = value;
                ComboCurrentTexture.Items.Clear();
                if (m_Resources != null) {
                    foreach (var texture in value.Textures) {
                        ComboCurrentTexture.Items.Add(new ComboTextureItem {
                            Name = texture.Key.Name.Value,
                            TextureID = texture.Value
                        });
                    }
                    if (ComboCurrentTexture.Items.Count > 0) {
                        ComboCurrentTexture.SelectedIndex = 0;
                    }
                }
                
                Invalidate();
                return;
            }
        }

        private void ComboCurrentTexture_SelectedValueChanged(object sender, EventArgs e)
        {
            GLView.Invalidate();
            return;
        }

        private ShaderResources m_Resources = null;

        private class ComboTextureItem
        {
            public string Name
            { get; set; } = "";
            public int TextureID
            { get; set; } = 0;

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
