using System;
using System.Reactive.Linq;
using Reactive.Bindings;
using OpenTK.Graphics.OpenGL4;
using GIP.Controls.UniformVariableValues;
using GIP.Core.Variables;

namespace GIP.Core.Uniforms
{
    class UniformTextureVariable : UniformVariableValue
    {
        public UniformTextureVariable()
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

        public override Ctrl_UniformVariableValueView CreateView()
        {
            return new Ctrl_UniformVariableTextureValueView();
        }
    }
}
