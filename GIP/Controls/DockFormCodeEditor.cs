using GIP.Core;

namespace GIP.Controls
{
    public partial class DockFormCodeEditor : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DockFormCodeEditor()
        {
            InitializeComponent();
        }

        public ImageProcessTask Task
        {
            get => m_Task;
            set {
                if (m_Task == value) {
                    return;
                }
                m_Task = value;

                TextBoxCodeEditor.Enabled = m_Task != null;
                UdDispatchSizeX.Enabled = m_Task != null;
                UdDispatchSizeY.Enabled = m_Task != null;
                UdDispatchSizeZ.Enabled = m_Task != null;
                if (m_Task == null) {
                    TextBoxCodeEditor.Text = "";                    
                    UdDispatchSizeX.Value = 0;                    
                    UdDispatchSizeY.Value = 0;
                    UdDispatchSizeZ.Value = 0;
                    
                } else {
                    TextBoxCodeEditor.Text = m_Task.SourceCode;
                    UdDispatchSizeX.Value = m_Task.DispatchGroupSizeX;
                    UdDispatchSizeY.Value = m_Task.DispatchGroupSizeY;
                    UdDispatchSizeZ.Value = m_Task.DispatchGroupSizeZ;

                }

                return;
            }
        }

        public string Code
        { get => TextBoxCodeEditor.Text; }

        protected override string GetPersistString()
        {
            return MainDockFormType.CodeEditor.ToPersistString();
        }

        private ImageProcessTask m_Task = null;
    }
}
