using System.IO;
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
                    //if (m_Shader == value) {
                    //    return;
                    //}

                    if (m_Shader != null) {
                        if ((m_Shader != value) && TextBoxCodeEditor.Enabled &&
                            (m_Shader.FileType == ComputeShaderFileType.Text)) {
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
            if (File.Exists(inPath)) {
                using (StreamReader reader = new StreamReader(new FileStream(inPath, FileMode.Open, FileAccess.Read))) {
                    TextBoxCodeEditor.Text = reader.ReadToEnd();
                }
                TextBoxCodeEditor.Enabled = true;
            } else {
                TextBoxCodeEditor.Text = "File is missed.";
                TextBoxCodeEditor.Enabled = false;
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
