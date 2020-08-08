using System;
using System.Collections.Generic;
using GIP.Common;
using OpenTK.Graphics.OpenGL4;

namespace GIP.Core
{
    public delegate void ComputeShaderNotifyEvent(ComputeShader inValue);

    public class ComputeShader
    {
        public ComputeShader(ShaderSource inSource)
        {
            Source = inSource;
        }

        public bool CompileAndLink(ILogger inLogger)
        {
            foreach (var d in m_ShaderResources) {
                d.GLDispose();
            }
            m_ShaderResources.Clear();

            if (ProgramID != 0) {
                GL.DeleteProgram(ProgramID);
            }
            ProgramID = GL.CreateProgram();

            if (Source == null) {
                inLogger.PushLog(this, new LogData(LogLevel.Error, "Shader source is not attached." + Environment.NewLine));
                return false;
            }

            return Source.CompileAndLink(ProgramID, m_ShaderResources, inLogger);
        }

        public void GLDispose()
        {
            GL.DeleteProgram(ProgramID);
            return;
        }

        public IReadOnlyList<string> Error => m_Errors;

        public ShaderSource Source
        { get; } = null;
        public int ProgramID
        { get; private set; } = 0;
        public int NextBindableTextureUnit
        { get; set; } = 0;
        private List<IGLDisposable> m_ShaderResources = new List<IGLDisposable>();
        private List<string> m_Errors = new List<string>();
    }
}
