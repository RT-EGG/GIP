using GIP.Core;

namespace GIP.Controls
{
    public partial class DockFormTextureList : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DockFormTextureList()
        {
            InitializeComponent();
        }

        public TextureInitializerList Data
        {
            get => CtrlTextureList.Data;
            set {
                CtrlTextureList.Data = value;
                return;
            }
        }

        protected override string GetPersistString()
        {
            return MainDockFormType.TextureList.ToPersistString();
        }
    }
}
