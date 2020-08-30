using GIP.Core;
using System.IO;

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
                        if (m_Shader.FileType == ComputeShaderFileType.Text) {
                            SaveSource(m_Shader.FilePath.Value);
                        }
                    }

                    m_Shader = value;
                    if (m_Shader == null) {
                        TextBoxCodeEditor.Text = "";

                    } else {
                        if (m_Shader.FileType == ComputeShaderFileType.Text) {
                            LoadSource(m_Shader.FilePath.Value);
                        }
                    }

                } finally {
                    this.Enabled = (m_Shader != null) && (m_Shader.FileType == ComputeShaderFileType.Text);
                }
            }
        }

        public string Code
        { get => TextBoxCodeEditor.Text; }

        public void SaveCurrentSource()
        {
            if ((m_Shader == null) || (m_Shader.FileType != ComputeShaderFileType.Text)) {
                return; 
            }

            SaveSource(m_Shader.FilePath.Value);
            return;
        }

        private void LoadSource(string inPath)
        {
            using (StreamReader reader = new StreamReader(new FileStream(inPath, FileMode.Open, FileAccess.Read))) {
                TextBoxCodeEditor.Text= reader.ReadToEnd();
            }
            return;
        }

        private void SaveSource(string inPath)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(inPath, FileMode.OpenOrCreate, FileAccess.Write))) {
                writer.Write(TextBoxCodeEditor.Text);
            }
            return;
        }

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
                        SaveSource(m_Shader.FilePath.Value);
                    }
                    break;
            }
        }

        private void TextBoxCodeEditor_TextChanged(object sender, System.EventArgs e)
        {
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
