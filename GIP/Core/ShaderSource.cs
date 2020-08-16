using System.Collections.Generic;
using System.IO;
using Reactive.Bindings;
using OpenTK.Graphics.OpenGL4;
using GIP.Common;
using GIP.IO.Project;
using GIP.IO.Json;

namespace GIP.Core
{
    public delegate void ShaderSourceNotifyEvent(ShaderSource inValue);

    public abstract class ShaderSource : DataObjectBase
    {
        public static bool IsBinaryFile(string inPath)
        {
            using (StreamReader reader = new StreamReader(new FileStream(inPath, FileMode.Open))) {
                char[] buffer = new char[1000];
                reader.ReadBlock(buffer, 0, buffer.Length);

                foreach (var character in buffer) {
                    if ((byte)character > 127) {
                        return true;
                    }
                }
                return false;
            }
        }

        public ShaderSource(string inPath)
        {
            FilePath = m_FilePath.ToReadOnlyReactiveProperty();
            m_FilePath.Value = inPath;
            LoadSource(inPath);
            return;
        }

        public ReadOnlyReactiveProperty<string> FilePath
        { get; } = null;

        public virtual bool IsEdited => false;

        public abstract bool CompileAndLink(int inProgramID, List<IGLDisposable> inOutResources, ILogger inErrors = null);

        public void SaveSource()
        {
            SaveSource(m_FilePath.Value);
            return;
        }
        public abstract void SaveSource(string inPath);
        protected abstract void LoadSource(string inPath);

        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            (inDst as JsonShaderSource).FilePath = FilePath.Value;
            return;
        }

        private ReactiveProperty<string> m_FilePath = new ReactiveProperty<string>();

        protected class GLShader : IGLDisposable
        {
            public GLShader(ShaderType inType = ShaderType.ComputeShader)
            {
                ID = GL.CreateShader(inType);
                return;
            }

            public void GLDispose()
            {
                GL.DeleteShader(ID);
                return;
            }

            public int ID
            { get; } = 0;
        }
    }
}
