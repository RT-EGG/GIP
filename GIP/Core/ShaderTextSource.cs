using System;
using System.Collections.Generic;
using System.IO;
using OpenTK.Graphics.OpenGL4;
using GIP.Common;
using GIP.IO.Project;
using GIP.IO.Json;

namespace GIP.Core
{
    public class ShaderTextSource : ShaderSource
    {
        public ShaderTextSource(string inPath) 
            : base(inPath)
        {
            return;
        }

        public string SourceCode
        { get; set; } = "";
        public string OriginalSourceCode
        { get; private set; } = "";

        public override bool IsEdited => SourceCode != OriginalSourceCode;

        public override void SaveSource(string inPath)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(inPath, FileMode.OpenOrCreate, FileAccess.Write))) {
                writer.Flush();
                writer.Write(SourceCode);
            }
            OriginalSourceCode = SourceCode;
            return;
        }

        protected override void LoadSource(string inPath)
        {
            using (StreamReader reader = new StreamReader(new FileStream(inPath, FileMode.Open, FileAccess.Read))) {
                SourceCode = reader.ReadToEnd();
                OriginalSourceCode = SourceCode;
            }
            return;
        }

        public override bool CompileAndLink(int inProgramID, List<IGLDisposable> inOutResources, ILogger inErrors = null)
        {
            var shader = new GLShader();
            inOutResources.Add(shader);

            GL.ShaderSource(shader.ID, SourceCode);
            GL.CompileShader(shader.ID);

            GL.GetShader(shader.ID, ShaderParameter.CompileStatus, out int state);
            if (state == 0) {
                string error = GL.GetShaderInfoLog(shader.ID);
                inErrors?.PushLog(this, new LogData(LogLevel.Error, "=====Compile error=====" + Environment.NewLine + error));
                return false;
            }

            GL.AttachShader(inProgramID, shader.ID);
            GL.LinkProgram(inProgramID);
            GL.GetProgram(inProgramID, GetProgramParameterName.LinkStatus, out state);
            if (state == 0) {
                string error = GL.GetProgramInfoLog(inProgramID);
                inErrors?.PushLog(this, new LogData(LogLevel.Error, "=====Link error=====" + Environment.NewLine + error));
                return false;
            }

            return true;
        }

        protected override JsonDataObject CreateJson() => new JsonShaderTextSource();
    }
}
