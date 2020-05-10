using System.Windows.Forms;
using GIP.Core;
using GIP.Core.Uniforms;

namespace GIP.Controls.UniformVariableValues
{
    public partial class Ctrl_UniformVariableValueView : UserControl
    {
        public Ctrl_UniformVariableValueView()
        {
            InitializeComponent();
            return;
        }

        public virtual void SetEnabled(bool inEnabled)
        {
            return;
        }

        public virtual void SetResource(ShaderResourceInitializers inValue)
        {
            return;
        }

        public virtual void SetData(UniformVariableValue inValue)
        {
            return;
        }
    }
}
