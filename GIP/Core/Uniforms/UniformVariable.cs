using Reactive.Bindings;
using OpenTK.Graphics.OpenGL;
using GIP.Common;
using GIP.IO.Json;
using GIP.IO.Project;

namespace GIP.Core.Uniforms
{
    public class UniformVariable : DataObjectBase
    {
        public UniformVariable()
        { return; }

        public void Bind(ComputeShader inShader)
        {
            int location = GL.GetUniformLocation(inShader.ProgramID, UniformName.Value);
            if (location < 0) {
                throw new UniformVariableNotFoundException(UniformName.Value);
            }
            if (Variable.Value == null) {
                throw new UniformVariableNotAssignedException(UniformName.Value);
            }
            Variable.Value.Bind(location, inShader);
            return;
        }

        public ReactiveProperty<string> UniformName
        { get; } = new ReactiveProperty<string>("Uniform");

        public ReactiveProperty<UniformVariableValue> Variable
        { get; set; } = new ReactiveProperty<UniformVariableValue>(new UniformVariableTextureValue());

        protected override JsonDataObject CreateJson() => new JsonUniformVariable();
        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            var dst = inDst as JsonUniformVariable;
            dst.UniformName = UniformName.Value;
            dst.Value = Variable.Value.ExportToJson<JsonUniformVariableValue>();
            return;
        }
    }
}
