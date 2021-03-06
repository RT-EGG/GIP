﻿using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;
using GIP.Core;
using GIP.Common;
using GIP.Controls;
using GIP.IO.Json;
using GIP.IO.Project;
using GIP.IO;

namespace GIP
{
    public partial class FormMain : Form
    {
        public FormMain(Arguments inArgs)
        {
            InitializeComponent();

            Arguments = inArgs;
            if (Arguments.MinWindow) {
                WindowState = FormWindowState.Minimized;
            }

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
            if (/*File.Exists(inPath)*/ false) {
                // query overwrite or open
                if (false) {
                    OpenProject(inPath);
                } else {
                    Project = new Project(inPath);
                }
            } else {
                Project = new Project(inPath);
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
            DockForms.Get<DockFormCodeEditor>(MainDockFormType.CodeEditor)?.SaveCurrentSource();
            return;
        }

        private void OpenProject()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open project";
            dialog.Filter = "GIP project file(*.gip, *.json)|*.gip;*.json";
            dialog.FilterIndex = 0;

            if (dialog.ShowDialog() == DialogResult.OK) {
                OpenProject(dialog.FileName);
            }
            return;
        }

        private void OpenProject(string inPath)
        {
            if (false) {
                // query save or not if project changed.
            } else {
                var json = JsonSerializable.ImportFromFile<JsonProjectFile>(inPath);

                Project newProject = new Project(inPath);
                JsonDataReadBuffer buffer = new JsonDataReadBuffer();
                newProject.ReadJson(json, buffer, Logger.DefaultLogger);
                buffer.ProcessComplementation(Logger.DefaultLogger);
                Project = newProject;
            }
            return;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            JsonWindowLayout layout;
            if (File.Exists(LayoutFilePath)) {
                layout = JsonSerializable.ImportFromFile<JsonWindowLayout>(LayoutFilePath);
            } else {
                layout = JsonSerializable.ImportFromText<JsonWindowLayout>(Properties.Resources.DefaultLayout_json);
            }

            if (layout.Location != null) {
                Location = (System.Drawing.Point)layout.Location;
            }
            if (layout.Size != null) {
                Size = (System.Drawing.Size)layout.Size;
            }
            if (layout.DockFormLayout != null) {
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(layout.DockFormLayout))) {
                    PanelDockMain.LoadFromXml(stream, new DeserializeDockContent(DockForms.Find));
                }
            }

            UIEventBridge.Register(DockForms);
            Logger.DefaultLogger.Add(DockForms.Get<DockFormConsole>(MainDockFormType.Console));
            return;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Ctrl_GLControl.MakeCurrentSomeone();

            if (Arguments.Tasks != null) {
                ProjectsRunner runner = new ProjectsRunner();
                runner.RunFiles(Arguments.Tasks.Split(new char[]{ ';' }, StringSplitOptions.RemoveEmptyEntries), Logger.DefaultLogger);

                if (Arguments.AutoClose) {
                    Logger.DefaultLogger.PushLog(this, new LogData(LogLevel.Information, "Auto close by argument."));
                    this.Close();
                }
            }

            return;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            JsonWindowLayout layout = new JsonWindowLayout();
            layout.Location = (JsonVector2i)this.Location;
            layout.Size = (JsonVector2i)this.Size;
            using (MemoryStream stream = new MemoryStream()) {
                PanelDockMain.SaveAsXml(stream, Encoding.UTF8);

                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream)) {
                    layout.DockFormLayout = reader.ReadToEnd();
                }
            }
            layout.ExportToFile(LayoutFilePath);
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

        private void MenuItem_Open_Project_Click(object sender, EventArgs e)
        {
            OpenProject();
            return;
        }

        private void MenuItem_ShowWindow_Click(object sender, EventArgs e)
        {
            if (sender == MenuItem_ProjectFiles) {
                ShowWindow(DockForms.Get<DockFormProjectFileView>(MainDockFormType.ProjectFiles));
            } else if (sender == MenuItem_Code) {
                ShowWindow(DockForms.Get<DockFormCodeEditor>(MainDockFormType.CodeEditor));
            } else if (sender == MenuItem_TaskEditor) {
                ShowWindow(DockForms.Get<DockFormTaskEditor>(MainDockFormType.TaskEditor));
            } else if (sender == MenuItem_TaskSequence) {
                ShowWindow(DockForms.Get<DockFormTaskSequence>(MainDockFormType.TaskSequence));
            } else if (sender == MenuItem_Compile) {
                ShowWindow(DockForms.Get<DockFormConsole>(MainDockFormType.Console));
            } else if (sender == MenuItem_VariableList) {
                ShowWindow(DockForms.Get<DockFormVariableList>(MainDockFormType.VariableList));
            } else if (sender == MenuItem_TextureView) {
                ShowWindow(DockForms.Get<DockFormTextureView>(MainDockFormType.TextureView));
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
                DockForms.Get<DockFormProjectFileView>(MainDockFormType.ProjectFiles).Data = m_Project;
                DockForms.Get<DockFormTaskSequence>(MainDockFormType.TaskSequence).Project = m_Project;
                DockForms.Get<DockFormVariableList>(MainDockFormType.VariableList).Data = m_Project.Variables;
                DockForms.Get<DockFormTaskEditor>(MainDockFormType.TaskEditor).Project = m_Project;
                DockForms.Get<DockFormTextureView>(MainDockFormType.TextureView).Project = m_Project;

                return;
            } 
        }

        private Arguments Arguments
        { get; } = null;
        private MainDockForms DockForms => MainDockForms.Instance;
        private MainFormEventBridge UIEventBridge
        { get; set; } = new MainFormEventBridge();
        private Project m_Project = null;

        private string LayoutFilePath => $"{AppDomain.CurrentDomain.BaseDirectory}/layout.json";
    }
}
