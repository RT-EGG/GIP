using OpenTK.Graphics.OpenGL4;

namespace GIP.Core
{
    class ImageProcessTaskRunner
    {
        public void GLDispose()
        {
            foreach (var texture in Resources.Textures.Values) {
                GL.DeleteTexture(texture);
            }
            Resources.Textures.Clear();
            return;
        }

        public void Run(ImageProcessTask inTask)
        {
            try {
                foreach (var initializer in inTask.Resources.Textures) {
                    if (!Resources.Textures.TryGetValue(initializer, out int texture)) {
                        texture = GL.GenTexture();
                        Resources.Textures.Add(initializer, texture);
                    }
                    GL.BindTexture(TextureTarget.Texture2D, texture);
                    initializer.GlTexImage2D();
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, new int[] { (int)All.ClampToBorder });
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, new int[] { (int)All.ClampToBorder });
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, new int[] { (int)All.Nearest });
                    GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, new int[] { (int)All.Nearest });
                }
            } finally {
                GL.BindTexture(TextureTarget.Texture2D, 0);
            }

            GL.UseProgram(inTask.ProgramID);
            try {
                foreach (var variable in inTask.UniformVariables) {
                    variable.Bind(inTask.ProgramID, Resources);
                }

                ErrorCode error = GL.GetError();
                GL.DispatchCompute(inTask.DispatchGroupSizeX, inTask.DispatchGroupSizeY, inTask.DispatchGroupSizeZ);
                error = GL.GetError();

            } finally {
                GL.UseProgram(0);
            }
            return;
        }

        public ShaderResources Resources
        { get; } = new ShaderResources();
    }
}
