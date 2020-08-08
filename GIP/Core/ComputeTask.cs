using OpenTK.Graphics.OpenGL4;
using Reactive.Bindings;
using GIP.Core.Uniforms;
using System;

namespace GIP.Core
{
    public class ComputeTask : ProcessTask
    {
        public override bool Execute(ILogger inLogger)
        {
            if (Shader == null) {
                inLogger.PushLog(this, new LogData(LogLevel.Error, "Compute shader is not attached."));
                return false;
            }

            try {
                Shader.NextBindableTextureUnit = 0;
                foreach (var uniform in UniformVariables) {
                    uniform.Bind(Shader);
                }

                GL.UseProgram(Shader.ProgramID);
                GL.DispatchCompute(DispatchGroupSizeX.Value, DispatchGroupSizeY.Value, DispatchGroupSizeZ.Value);

            } catch (Exception e) {
                inLogger.PushLog(this, new LogExceptionData(e));
                return false;
            }

            return true;
        }

        public ComputeShader Shader
        { get; set; } = null;
        public UniformVariableList UniformVariables
        { get; } = new UniformVariableList();

        public ReactiveProperty<int> DispatchGroupSizeX
        { get; } = new ReactiveProperty<int>(64);
        public ReactiveProperty<int> DispatchGroupSizeY
        { get; } = new ReactiveProperty<int>(64);
        public ReactiveProperty<int> DispatchGroupSizeZ
        { get; } = new ReactiveProperty<int>(1);
    }
}
