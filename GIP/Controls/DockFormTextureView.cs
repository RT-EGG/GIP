using GIP.Core;

namespace GIP.Controls
{
    public partial class DockFormTextureView : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DockFormTextureView()
        {
            InitializeComponent();
        }

        public ShaderResources Resources
        {
            get => CtrlTextureView.Resources;
            set {
                CtrlTextureView.Resources = value;
                return;
            }
        }

        protected override string GetPersistString()
        {
            return MainDockFormType.TextureView.ToPersistString();
        }
    }
}
