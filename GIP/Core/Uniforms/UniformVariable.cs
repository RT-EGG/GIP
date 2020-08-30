using Reactive.Bindings;
using OpenTK.Graphics.OpenGL;
using GIP.Common;
using GIP.IO.Json;
using GIP.IO.Project;
using System;
using System.Collections.Generic;

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

        protected override IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonUniformVariable) };
        public override bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
        {
            if (!base.ReadJson(inSource, inBuffer, inLogger)) {
                return false;
            }

            var src = inSource as JsonUniformVariable;
            UniformName.Value = src.UniformName;
            Variable.Value = UniformVariableValue.CreateFrom(src.Value);
            if (Variable.Value != null) {
                Variable.Value.ReadJson(src.Value, inBuffer, inLogger);
            }
            return true;
        }

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
