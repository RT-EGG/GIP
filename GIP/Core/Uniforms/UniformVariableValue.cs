using Reactive.Bindings;
using GIP.Controls.UniformVariableValues;

namespace GIP.Core.Uniforms
{
    public abstract class UniformVariableValue : DataObjectBase
    {
        public UniformVariableValue()
        {
            return;
        }

        public abstract void Bind(int inLocation, ComputeShader inTarget);

        public abstract string TypeString
        { get; }
        public IReadOnlyReactiveProperty<string> ValueString => m_ValueString;

        public virtual Ctrl_UniformVariableValueView CreateView() => new Ctrl_UniformVariableValueView();

        protected void SetValueString(string inValue)
        {
            m_ValueString.Value = inValue;
            return;
        }

        private ReactiveProperty<string> m_ValueString = new ReactiveProperty<string>("");
    }    
}
