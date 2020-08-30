using System;
using Reactive.Bindings;
using OpenTK.Graphics.OpenGL4;
using GIP.Common;
using GIP.Core.Uniforms;
using GIP.IO.Json;
using GIP.IO.Project;

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

        protected override JsonDataObject CreateJson() => new JsonComputeTask();
        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            var dst = inDst as JsonComputeTask;
            dst.ShaderGuid = Shader.GUID;
            dst.UniformVariables.AddRange(UniformVariables.Convert(u => u.ExportToJson<JsonUniformVariable>()));
            dst.DispatchGroupSize = new JsonVector3i(
                DispatchGroupSizeX.Value,
                DispatchGroupSizeY.Value,
                DispatchGroupSizeZ.Value
                );
            return;
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
