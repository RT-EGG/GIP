using System;
using System.Windows.Forms;
using System.IO;
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
            return;
        }

        private void NewProject()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "New project";
            dialog.Filter = "GIP project file(*.gip)|*.gip";
            dialog.FilterIndex = 0;

            if (dialog.ShowDialog() == DialogResult.OK) {
                NewProject(dialog.FileName);
            }
            return;
        }

        private void NewProject(string inPath)
        {
            if (false) {
                // query save if have not saved yet.
            }

            Project = new Project(inPath);
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
                //ProcessTask.SetSourceCode(reader.ReadToEnd());
            }
            return;
        }

        private void SaveProject()
        {
            var json = Project.ExportToJson();
            json.ExportToFile(Project.FilePath.Value);
            return;
        }

        private void SaveShaderFile()
        {
            var codeEditor = m_DockForms.Get<DockFormCodeEditor>(MainDockFormType.CodeEditor);
            var currentShader = codeEditor.Shader;
            if (currentShader == null) {
                return;
            }

            currentShader.Source.SaveSource();
            return;
        }

        private void SaveShaderFile(string inPath)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(inPath, FileMode.OpenOrCreate, FileAccess.Write))) {
                //writer.Write(ProcessTask.SourceCode);
            }
            return;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            m_DockForms = new MainDockForms();

            if (File.Exists("layout.xml")) {
                PanelDockMain.LoadFromXml("layout.xml", new DeserializeDockContent(m_DockForms.Find));
            } else {
                m_DockForms.ShowAll(PanelDockMain);
            }

            UIEventBridge.Register(m_DockForms);
            Logger.DefaultLogger.Add(m_DockForms.Get<DockFormConsole>(MainDockFormType.Console));
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

        private void MenuItem_NewProject_Click(object sender, EventArgs e)
        {
            NewProject();
            return;
        }

        private void MenuItem_SaveShaderFile_Click(object sender, EventArgs e)
        {
            SaveShaderFile();
            return;
        }

        private void MenuItem_Save_Project_Click(object sender, EventArgs e)
        {
            SaveProject();
            return;
        }

        private void MenuItem_ShowWindow_Click(object sender, EventArgs e)
        {
            if (sender == MenuItem_ProjectFiles) {
                ShowWindow(m_DockForms.Get<DockFormProjectFileView>(MainDockFormType.ProjectFiles));
            } else if (sender == MenuItem_Code) {
                ShowWindow(m_DockForms.Get<DockFormCodeEditor>(MainDockFormType.CodeEditor));
            } else if (sender == MenuItem_TaskEditor) {
                ShowWindow(m_DockForms.Get<DockFormTaskEditor>(MainDockFormType.TaskEditor));
            } else if (sender == MenuItem_TaskSequence) {
                ShowWindow(m_DockForms.Get<DockFormTaskSequence>(MainDockFormType.TaskSequence));
            } else if (sender == MenuItem_Compile) {
                ShowWindow(m_DockForms.Get<DockFormConsole>(MainDockFormType.Console));
            } else if (sender == MenuItem_VariableList) {
                ShowWindow(m_DockForms.Get<DockFormVariableList>(MainDockFormType.VariableList));
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

        private Project Project
        { 
            get => m_Project;
            set {
                if (m_Project == value) {
                    return;
                }
                m_Project = value;
                m_DockForms.Get<DockFormProjectFileView>(MainDockFormType.ProjectFiles).Data = m_Project;
                m_DockForms.Get<DockFormTaskSequence>(MainDockFormType.TaskSequence).Project = m_Project;
                m_DockForms.Get<DockFormVariableList>(MainDockFormType.VariableList).Data = m_Project.Variables;
                m_DockForms.Get<DockFormTaskEditor>(MainDockFormType.TaskEditor).Project = m_Project;
                m_DockForms.Get<DockFormTextureView>(MainDockFormType.TextureView).Project = m_Project;

                return;
            } 
        }

        private MainDockForms m_DockForms
        { get; set; } = null;
        private MainFormEventBridge UIEventBridge
        { get; set; } = new MainFormEventBridge();
        private Project m_Project = null;
    }
}
