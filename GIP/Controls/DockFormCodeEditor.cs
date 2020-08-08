using GIP.Core;

namespace GIP.Controls
{
    public partial class DockFormCodeEditor : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DockFormCodeEditor()
        {
            InitializeComponent();
            return;
        }

        public ComputeShader Shader
        {
            get => m_Shader;
            set {
                try {
                    if (m_Shader == value) {
                        return;
                    }

                    if (m_Shader != null) {
                        if (m_Shader.Source is ShaderTextSource) {
                            (m_Shader.Source as ShaderTextSource).SourceCode = Code;
                        }
                    }

                    m_Shader = value;
                    if (m_Shader == null) {
                        TextBoxCodeEditor.Text = "";

                    } else {
                        switch (m_Shader.Source) {
                            case ShaderTextSource text:
                                TextBoxCodeEditor.Text = text.SourceCode;
                                break;
                            default:
                                TextBoxCodeEditor.Text = "";
                                break;
                        }
                    }

                } finally {
                    this.Enabled = (m_Shader != null) && (m_Shader.Source is ShaderTextSource);
                }
            }
        }

        public string Code
        { get => TextBoxCodeEditor.Text; }

        protected override string GetPersistString()
        {
            return MainDockFormType.CodeEditor.ToPersistString();
        }

        private void TextBoxCodeEditor_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (m_Shader == null) {
                return;
            }

            switch (e.KeyCode) {
                case System.Windows.Forms.Keys.S:
                    if (e.Control) {
                        if (m_Shader.Source is ShaderTextSource) {
                            (m_Shader.Source as ShaderTextSource).SourceCode = Code;
                        }
                        m_Shader.Source.SaveSource();
                    }
                    break;
            }
        }

        private void TextBoxCodeEditor_TextChanged(object sender, System.EventArgs e)
        {
            if (m_Shader != null) {
                if (m_Shader.Source is ShaderTextSource) {
                    var textSource = m_Shader.Source as ShaderTextSource;
                    textSource.SourceCode = TextBoxCodeEditor.Text;
                }
            }
            return;
        }

        private void ButtonCompile_Click(object sender, System.EventArgs e)
        {
            if (m_Shader == null) {
                return;
            }

            m_Shader.CompileAndLink(Logger.DefaultLogger);
            return;
        }

        private ComputeShader m_Shader = null;
    }
}
