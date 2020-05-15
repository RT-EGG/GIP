using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

namespace GIP.Core
{
    public delegate void ImageProcessTaskRunnerEvent(ImageProcessTaskRunner inRunner);

    public class ImageProcessTaskRunner
    {
        public event ImageProcessTaskRunnerEvent OnBeforeRun;
        public event ImageProcessTaskRunnerEvent OnAfterRun;

        public void GLDispose()
        {
            foreach (var texture in Resources.Textures.Values) {
                GL.DeleteTexture(texture);
            }
            Resources.Textures.Clear();
            return;
        }

        public void Run()
        {
            OnBeforeRun?.Invoke(this);

            try {
                try {
                    if (ResourceInitializers != null) {
                        foreach (var initializer in ResourceInitializers.Textures) {
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
                    }

                } finally {
                    GL.BindTexture(TextureTarget.Texture2D, 0);
                }

                foreach (var task in Tasks) {
                    GL.UseProgram(task.ProgramID);
                    try {
                        foreach (var variable in task.UniformVariables) {
                            variable.Bind(task.ProgramID, Resources);
                        }

                        ErrorCode error = GL.GetError();
                        GL.DispatchCompute(task.DispatchGroupSizeX, task.DispatchGroupSizeY, task.DispatchGroupSizeZ);
                        error = GL.GetError();

                    } finally {
                        GL.UseProgram(0);
                    }
                }
            } finally {
                OnAfterRun?.Invoke(this);
            }
            return;
        }

        public ShaderResources Resources
        { get; } = new ShaderResources();
        public ShaderResourceInitializers ResourceInitializers
        { get; set; } = null;
        public IList<ImageProcessTask> Tasks
        { get; } = new List<ImageProcessTask>();
    }
}
