using System.Windows.Forms;
using GIP.Core;
using GIP.Core.Uniforms;

namespace GIP.Controls
{
    public partial class Ctrl_ShaderVariables : UserControl
    {
        public Ctrl_ShaderVariables()
        {
            InitializeComponent();

            return;
        }

        public void SetShaderVariables(ShaderResourceInitializers inResources, UniformVariableList inVariables)
        {
            CtrlGlobalTextureListView.Data = inResources.Textures;
            CtrlUniformVariableListView.Resources = inResources;
            CtrlUniformVariableListView.Data = inVariables;
            return;
        }
    }
}
