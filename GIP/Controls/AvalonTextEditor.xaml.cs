using System;
using System.Windows.Controls;
using GIP.Controls.GlslSyntax;

namespace GIP.Controls
{
    public partial class AvalonTextEditor : UserControl
    {
        public AvalonTextEditor()
        {
            InitializeComponent();
            Editor.SyntaxHighlighting = new GlslSyntaxHighlightingDefinition();
            Editor.Options.ConvertTabsToSpaces = true;
            return;
        }

        public event EventHandler TextChanged;

        public string Text
        {
            get => Editor.Text;
            set => Editor.Text = value;
        }

        private void Editor_TextChanged(object sender, System.EventArgs e)
            => TextChanged?.Invoke(this, e);
    }
}
