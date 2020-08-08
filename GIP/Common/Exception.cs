using System;

namespace GIP.Common
{
    public class UniformVariableNotBindableException : Exception
    {
        public UniformVariableNotBindableException(string inMessage)
            : base (inMessage)
        { }
    }

    public class UniformVariableNotAssignedException : UniformVariableNotBindableException
    {
        public UniformVariableNotAssignedException(string inVariableName)
            : base ($"Variable \"{inVariableName}\" is not assigned.")
        { }
    }

    public class UniformVariableNotFoundException : UniformVariableNotBindableException
    {
        public UniformVariableNotFoundException(string inVariableName)
            : base ($"Variable \"{inVariableName}\" not found.")
        { }
    }

    public class UniformTextureVariableNotFoundException : UniformVariableNotBindableException
    {
        public UniformTextureVariableNotFoundException(string inTextureName)
            : base ($"Texture \"{inTextureName}\" not found..")
        { }
    }

    public class GLApiErrorException : Exception
    {
        public GLApiErrorException(OpenTK.Graphics.OpenGL.ErrorCode inCode, string inApiName)
            : base ($"GL error \"{inCode}\" on \"{inApiName}\".")
        { }

        public GLApiErrorException(OpenTK.Graphics.OpenGL4.ErrorCode inCode, string inApiName)
            : base($"GL error \"{inCode}\" on \"{inApiName}\".")
        { }
    }
}
