using GIP.Core;

namespace GIP.Controls
{
    public partial class DockFormTextureView : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DockFormTextureView()
        {
            InitializeComponent();
        }

        public Project Project
        {
            get => CtrlTextureView.Project;
            set => CtrlTextureView.Project = value;
        }

        protected override string GetPersistString()
        {
            return MainDockFormType.TextureView.ToPersistString();
        }
    }
}
