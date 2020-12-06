using System;
using System.Reactive.Linq;
using Reactive.Bindings;
using OpenTK.Graphics.OpenGL4;
using GIP.Controls.UniformVariableValues;
using GIP.Core.Variables;
using GIP.IO.Json;
using GIP.IO.Project;
using System.Collections.Generic;

namespace GIP.Core.Uniforms
{
    class UniformVariableTextureValue : UniformVariableValue
    {
        public UniformVariableTextureValue()
        {
            Texture.Subscribe(texture => {
                texture?.Name.Subscribe(name => {
                    SetValueString(name);
                });
            });
            return;
        }

        public ReactiveProperty<TextureVariable> Texture
        { get; } = new ReactiveProperty<TextureVariable>(initialValue:null);
        public ReactiveProperty<TextureAccess> Access
        { get; } = new ReactiveProperty<TextureAccess>(TextureAccess.ReadWrite);
        public ReactiveProperty<SizedInternalFormat> InternalFormat
        { get; } = new ReactiveProperty<SizedInternalFormat>(SizedInternalFormat.Rgba8);
        public override string TypeString => "Texture";

        public override void Bind(int inLocation, ComputeShader inTarget)
        {
#if DEBUG
            Logger.DefaultLogger.PushLog(this, new LogData(LogLevel.Information, $"Bind {Texture.Value.Name.Value}({Texture.Value.TextureID}) to {inLocation}.{Environment.NewLine}"));
#endif

            int unit = inTarget.NextBindableTextureUnit++;
            GL.BindImageTexture(unit, Texture.Value.TextureID, 0, false, 0, Access.Value, InternalFormat.Value);
            GL.Uniform1(inLocation, unit);
            return;
        }

        public override Ctrl_UniformVariableValueView CreateView() => new Ctrl_UniformVariableTextureValueView();

        protected override IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonUniformVariableTextureValue) };
        public override bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
        {
            if (!base.ReadJson(inSource, inBuffer, inLogger)) {
                return false;
            }

            var src = inSource as JsonUniformVariableTextureValue;
            Access.Value = src.Access;
            InternalFormat.Value = src.InternalFormat;

            inBuffer.RegisterComplementTask((data, logger) => {
                data.TryGetValueAs<TextureVariable>(src.TextureGuid, out var texture, logger);
                Texture.Value = texture;
            });
            return true;
        }

        protected override JsonDataObject CreateJson() => new JsonUniformVariableTextureValue();
        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            (inDst as JsonUniformVariableTextureValue).TextureGuid = Texture.Value.GUID;
            (inDst as JsonUniformVariableTextureValue).Access = Access.Value;
            (inDst as JsonUniformVariableTextureValue).InternalFormat = InternalFormat.Value;
            return;
        }
    }
}
