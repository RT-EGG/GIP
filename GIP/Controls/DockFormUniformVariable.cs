using GIP.Core;
using GIP.Core.Uniforms;

namespace GIP.Controls
{
    public partial class DockFormUniformVariable : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DockFormUniformVariable()
        {
            InitializeComponent();
        }

        public void SetShaderVariables(ShaderResourceInitializers inResources, UniformVariableList inVariables)
        {
            CtrlUniformVariableListView.Resources = inResources;
            CtrlUniformVariableListView.Data = inVariables;
            return;
        }
    }
}
