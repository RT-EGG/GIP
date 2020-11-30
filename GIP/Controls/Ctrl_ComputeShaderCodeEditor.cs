using System;
using System.Windows.Forms;

namespace GIP.Controls
{
    public partial class Ctrl_ComputeShaderCodeEditor : UserControl
    {
        public Ctrl_ComputeShaderCodeEditor()
        {
            InitializeComponent();
            _Editor.TextChanged += (object sender, EventArgs e) => CodeTextChanged?.Invoke(this, e);
            return;
        }

        public event EventHandler CodeTextChanged;

        public new string Text
        {
            get => _Editor.Text;
            set => _Editor.Text = value;
        }

        private AvalonTextEditor _Editor => EditorHost.Child as AvalonTextEditor;
    }
}
