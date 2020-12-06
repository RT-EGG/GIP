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
                    //if (m_Shader == value) {
                    //    return;
                    //}

                    if (m_Shader != null) {
                        if ((m_Shader != value) && CodeEditor.Enabled &&
                            (m_Shader.FileType == ComputeShaderFileType.Text)) {
                            SaveSource(m_Shader.FilePath.Value);
                        }
                    }

                    m_Shader = value;
                    if (m_Shader == null) {
                        CodeEditor.Text = "";

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
        { get => CodeEditor.Text; }

        public void SaveCurrentSource()
        {
            if ((m_Shader == null) || (m_Shader.FileType != ComputeShaderFileType.Text)) {
                return; 
            }

            SaveSource(m_Shader.FilePath.Value);
            return;
        }

        public void CompileCurrentSource(ILogger inLogger)
        {
            if ((m_Shader == null) || (m_Shader.FileType != ComputeShaderFileType.Text)) {
                return;
            }

            Logger.DefaultLogger.NewSession($"Compile shader file \"{Path.GetFileName(m_Shader.FilePath.Value)}\"...");
            m_Shader.CompileAndLink(inLogger);
            return;
        }

        private void LoadSource(string inPath)
        {
            if (File.Exists(inPath)) {
                using (StreamReader reader = new StreamReader(new FileStream(inPath, FileMode.Open, FileAccess.Read))) {
                    CodeEditor.Text = reader.ReadToEnd();
                }
                CodeEditor.Enabled = true;
            } else {
                CodeEditor.Text = "File is missed.";
                CodeEditor.Enabled = false;
            }
            return;
        }

        private void SaveSource(string inPath)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(inPath, FileMode.Create, FileAccess.Write))) {
                writer.Write(CodeEditor.Text);
            }
            return;
        }

        protected override string GetPersistString()
        {
            return MainDockFormType.CodeEditor.ToPersistString();
        }

        private void ButtonCompile_Click(object sender, System.EventArgs e)
        {
            CompileCurrentSource(Logger.DefaultLogger);
            return;
        }

        private ComputeShader m_Shader = null;
    }
}
