using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using WeifenLuo.WinFormsUI.Docking;
using GIP.Core;
using GIP.Common;
using GIP.Controls;

namespace GIP
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            ProcessTask = new ImageProcessTask(Resources);

            ProcessTaskRunner.OnBeforeRun += ProcessTaskRunner_OnBeforeRun;
            ProcessTaskRunner.OnAfterRun += ProcessTaskRunner_OnAfterRun;

            ProcessTaskRunner.ResourceInitializers = Resources;

            return;
        }

        private void OpenShaderFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open shader file";
            dialog.Filter = "All file(*.*)|*.*";
            dialog.FilterIndex = 0;

            if (dialog.ShowDialog() == DialogResult.OK) {
                OpenShaderFile(dialog.FileName);
            }
            return;
        }

        private void OpenShaderFile(string inPath)
        {
            using (StreamReader reader = new StreamReader(new FileStream(inPath, FileMode.Open, FileAccess.Read))) {
                ProcessTask.SetSourceCode(reader.ReadToEnd());
                var dockCodeEditor = m_DockForms.Get<DockFormCodeEditor>(MainDockFormType.CodeEditor);
                dockCodeEditor.Task = null;
                dockCodeEditor.Task = ProcessTask;
            }
            return;
        }

        private void SaveShaderFile()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save shader file";
            dialog.Filter = "All file(*.*)|*.*";
            dialog.FilterIndex = 0;

            if (dialog.ShowDialog() == DialogResult.OK) {
                SaveShaderFile(dialog.FileName);
            }
            return;
        }

        private void SaveShaderFile(string inPath)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(inPath, FileMode.OpenOrCreate, FileAccess.Write))) {
                writer.Write(ProcessTask.SourceCode);
            }
            return;
        }

        private void ProcessTaskRunner_OnBeforeRun(ImageProcessTaskRunner inRunner)
        {
            m_DockForms.Get<DockFormTextureView>(MainDockFormType.TextureView).Resources = null;
            return;
        }

        private void ProcessTaskRunner_OnAfterRun(ImageProcessTaskRunner inRunner)
        {
            m_DockForms.Get<DockFormTextureView>(MainDockFormType.TextureView).Resources = ProcessTaskRunner.Resources;
            return;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            m_DockForms = new MainDockForms();
            var dockCompile = m_DockForms.Get<DockFormCompile>(MainDockFormType.Compile);
            dockCompile.SetCompiler(Compiler);
            dockCompile.SetTaskRunner(ProcessTaskRunner);
            var dockCodeEditor = m_DockForms.Get<DockFormCodeEditor>(MainDockFormType.CodeEditor);
            dockCodeEditor.Task = ProcessTask;
            var dockTextureList = m_DockForms.Get<DockFormTextureList>(MainDockFormType.TextureList);
            dockTextureList.Data = Resources.Textures;
            var dockUniformVariables = m_DockForms.Get<DockFormUniformVariable>(MainDockFormType.UniformVariables);
            dockUniformVariables.SetShaderVariables(Resources, ProcessTask.UniformVariables);

            ProcessTaskRunner.Tasks.Add(ProcessTask);
            Project.ProcessTasks.Add(ProcessTask);
            Compiler.Project = Project;

            if (File.Exists("layout.xml")) {
                PanelDockMain.LoadFromXml("layout.xml", new DeserializeDockContent(m_DockForms.Find));
            } else {
                m_DockForms.ShowAll(PanelDockMain);
            }

            return;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Ctrl_GLControl.MakeCurrentSomeone();
            return;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            PanelDockMain.SaveAsXml("layout.xml");
            return;
        }

        private void MenuItem_OpenShaderFile_Click(object sender, EventArgs e)
        {
            OpenShaderFile();
            return;
        }

        private void MenuItem_SaveShaderFile_Click(object sender, EventArgs e)
        {
            SaveShaderFile();
            return;
        }

        private void MenuItem_ShowWindow_Click(object sender, EventArgs e)
        {
            if (sender == MenuItem_Code) {
                ShowWindow(m_DockForms.Get<DockFormCodeEditor>(MainDockFormType.CodeEditor));
            } else if (sender == MenuItem_Compile) {
                ShowWindow(m_DockForms.Get<DockFormCompile>(MainDockFormType.Compile));
            } else if (sender == MenuItem_TextureList) {
                ShowWindow(m_DockForms.Get<DockFormTextureList>(MainDockFormType.TextureList));
            } else if (sender == MenuItem_UniformVariables) {
                ShowWindow(m_DockForms.Get<DockFormUniformVariable>(MainDockFormType.UniformVariables));
            } else if (sender == MenuItem_TextureView) {
                ShowWindow(m_DockForms.Get<DockFormTextureView>(MainDockFormType.TextureView));
            }
            return;
        }

        private void ShowWindow(DockContent inContent)
        {
            if (inContent.Visible) {
                return;
            }
            
            inContent.Show(PanelDockMain);
            if (inContent.IsAutoHiding()) {
                inContent.DockPanel.ActiveAutoHideContent = inContent;
                inContent.Activate();
            }
            return;
        }

        private ShaderResourceInitializers Resources
        { get; } = new ShaderResourceInitializers();
        private ImageProcessTask ProcessTask
        { get; } = null;
        private ImageProcessTaskRunner ProcessTaskRunner
        { get; } = new ImageProcessTaskRunner();
        private Project Project
        { get; } = new Project();
        private ShaderCompiler Compiler
        { get; } = new ShaderCompiler();

        private MainDockForms m_DockForms
        { get; set; } = null;
    }
}
