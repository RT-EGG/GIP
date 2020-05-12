using Reactive.Bindings;
using OpenTK.Graphics.OpenGL;
using GIP.Common;

namespace GIP.Core.Uniforms
{
    public class UniformVariable
    {
        public UniformVariable()
        { return; }

        public void Bind(int inProgramID, ShaderResources inResources)
        {
            int location = GL.GetUniformLocation(inProgramID, UniformName.Value);
            if (location < 0) {
                throw new UniformVariableNotFoundException(UniformName.Value);
            }
            if (Variable.Value == null) {
                throw new UniformVariableNotAssignedException(UniformName.Value);
            }
            Variable.Value.Bind(location, inResources);
            return;
        }

        public ReactiveProperty<string> UniformName
        { get; } = new ReactiveProperty<string>("Uniform");

        public ReactiveProperty<UniformVariableValue> Variable
        { get; set; } = new ReactiveProperty<UniformVariableValue>(new UniformTextureVariable());
    }
}
