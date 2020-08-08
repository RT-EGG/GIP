using GIP.Core.Variables;

namespace GIP.Controls
{
    public partial class DockFormVariableList : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DockFormVariableList()
        {
            InitializeComponent();
        }

        public VariableList Data
        {
            get => CtrlTextureList.Data;
            set {
                CtrlTextureList.Data = value;
                return;
            }
        }

        protected override string GetPersistString()
        {
            return MainDockFormType.VariableList.ToPersistString();
        }
    }
}
