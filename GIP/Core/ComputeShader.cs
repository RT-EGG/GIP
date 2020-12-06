using System;
using System.Collections.Generic;
using System.IO;
using Reactive.Bindings;
using GIP.Common;
using GIP.IO.Json;
using GIP.IO.Project;
using OpenTK.Graphics.OpenGL4;

namespace GIP.Core
{
    public delegate void ComputeShaderNotifyEvent(ComputeShader inValue);

    public enum ComputeShaderFileType
    {
        Text,
        Binary,
        SpirV
    }

    public partial class ComputeShader : DataObjectBase
    {
        public ComputeShader(ComputeShaderFileType inFileType, string inFilePath)
        {
            FileType = inFileType;
            FilePath.Value = inFilePath;
            return;
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

            if (!File.Exists(FilePath.Value)) {
                inLogger.PushLog(this, new LogData(LogLevel.Error, "Shader source file is not exist." + Environment.NewLine));
                return false;
            }

            switch (FileType) {
                case ComputeShaderFileType.Text:
                    return CompileAndLinkText(FilePath.Value, m_ShaderResources, inLogger);
            }
            return false;
        }

        public void GLDispose()
        {
            GL.DeleteProgram(ProgramID);
            return;
        }

        public IReadOnlyList<string> Error => m_Errors;

        public ComputeShaderFileType FileType
        { get; } = ComputeShaderFileType.Text;
        public ReactiveProperty<string> FilePath
        { get; } = new ReactiveProperty<string>("");

        public int ProgramID
        { get; private set; } = 0;
        public int NextBindableTextureUnit
        { get; set; } = 0;
        private List<IGLDisposable> m_ShaderResources = new List<IGLDisposable>();
        private List<string> m_Errors = new List<string>();

        protected override JsonDataObject CreateJson() => new JsonComputeShader();
        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            var dst = (inDst as JsonComputeShader);
            dst.FileType = FileType;
            dst.FilePath = FilePath.Value;
            return;
        }

        public void OnDelete(string inPath)
        {
            throw new NotImplementedException();
        }

        public void OnRestore(string inPath)
        {
            throw new NotImplementedException();
        }
    }

    public partial class ComputeShader
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

        private bool CompileAndLinkText(string inFilePath, IList<IGLDisposable> inResources, ILogger inLogger)
        {
            string source;
            using (var reader = new StreamReader(new FileStream(inFilePath, FileMode.Open, FileAccess.Read))) {
                source = reader.ReadToEnd();
            }

            var shader = new GLShader();
            inResources.Add(shader);

            GL.ShaderSource(shader.ID, source);
            GL.CompileShader(shader.ID);

            GL.GetShader(shader.ID, ShaderParameter.CompileStatus, out int state);
            if (state == 0) {
                string error = GL.GetShaderInfoLog(shader.ID).Replace("\n", Environment.NewLine);
                inLogger?.PushLog(this, new LogData(LogLevel.Error, "compile error" + Environment.NewLine + error));
                return false;
            }

            GL.AttachShader(ProgramID, shader.ID);
            GL.LinkProgram(ProgramID);
            GL.GetProgram(ProgramID, GetProgramParameterName.LinkStatus, out state);
            if (state == 0) {
                string error = GL.GetProgramInfoLog(ProgramID).Replace("\n", Environment.NewLine);
                inLogger?.PushLog(this, new LogData(LogLevel.Error, "link error" + Environment.NewLine + error));
                return false;
            }

            inLogger?.PushLog(this, new LogData(LogLevel.Information, "successed" + Environment.NewLine));
            return true;
        }

        private class GLShader : IGLDisposable
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
