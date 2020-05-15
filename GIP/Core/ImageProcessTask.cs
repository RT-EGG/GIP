using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using GIP.Core.Uniforms;

namespace GIP.Core
{
    public class ImageProcessTask
    {
        public ImageProcessTask(ShaderResourceInitializers inResources)
        {
            Resources = inResources;
            return;
        }

        //TODO remove lator
        public void SetSourceCode(string inCode)
        {
            SourceCode = inCode;
            return;
        }

        public bool CompileAndLink()
        {
            return CompileAndLink(SourceCode);
        }

        public bool CompileAndLink(IEnumerable<string> inLines)
        {
            string text = "";
            foreach (string line in inLines) {
                text += line + Environment.NewLine;
            }
            return CompileAndLink(text);
        }

        public bool CompileAndLink(string inLines)
        {
            CreateShader();
            m_Errors.Clear();

            SourceCode = inLines;
            GL.ShaderSource(ShaderID, inLines);
            GL.CompileShader(ShaderID);

            GL.GetShader(ShaderID, ShaderParameter.CompileStatus, out int state);
            if (state == 0) {
                string error = GL.GetShaderInfoLog(ShaderID);
                m_Errors.Add("=====Compile error=====");
                m_Errors.AddRange(error.Split('\n'));
                return false;
            }

            GL.LinkProgram(ProgramID);
            GL.GetProgram(ProgramID, GetProgramParameterName.LinkStatus, out state);
            if (state == 0) {
                string error = GL.GetProgramInfoLog(ProgramID);
                m_Errors.Add("=====Link error=====");
                m_Errors.AddRange(error.Split('\n'));
                return false;
            }

            return true;
        }

        public void GLDispose(bool aDisposing)
        {
            GL.DetachShader(ProgramID, ShaderID);
            GL.DeleteShader(ShaderID);
            GL.DeleteProgram(ProgramID);

            return;
        }

        private void CreateShader()
        {
            if (ShaderID == 0) {
                ShaderID = GL.CreateShader(ShaderType.ComputeShader);
            }
            if (ProgramID == 0) {
                ProgramID = GL.CreateProgram();
                GL.AttachShader(ProgramID, ShaderID);
            }

            return;
        }

        public IReadOnlyList<string> Error => m_Errors;
        public ShaderResourceInitializers Resources
        { get; } = null;
        public UniformVariableList UniformVariables
        { get; } = new UniformVariableList();

        public string Name
        { get; set; } = "";
        public string SourceCode
        { get; private set; } = "";
        public int DispatchGroupSizeX
        { get; set; } = 64;
        public int DispatchGroupSizeY
        { get; set; } = 64;
        public int DispatchGroupSizeZ
        { get; set; } = 64;

        private int ShaderID
        { get; set; } = 0;
        public int ProgramID
        { get; private set; } = 0;
        private List<string> m_Errors = new List<string>();
    }
}
