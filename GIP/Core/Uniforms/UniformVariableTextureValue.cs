using System;
using System.Reactive.Linq;
using Reactive.Bindings;
using OpenTK.Graphics.OpenGL4;
using GIP.Controls.UniformVariableValues;
using GIP.Core.Variables;
using GIP.IO.Json;
using GIP.IO.Project;

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
            int unit = inTarget.NextBindableTextureUnit++;
            GL.BindImageTexture(unit, Texture.Value.TextureID, 0, false, 0, Access.Value, InternalFormat.Value);
            GL.Uniform1(inLocation, unit);
            return;
        }

        public override Ctrl_UniformVariableValueView CreateView() => new Ctrl_UniformVariableTextureValueView();

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
