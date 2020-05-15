using System;
using System.Windows.Forms;
using System.IO;
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

            Compiler.OnBeforeCompile += Compiler_OnBeforeCompile;
            Compiler.OnAfterCompile += Compiler_OnAfterCompile;
            ProcessTaskRunner.OnBeforeRun += ProcessTaskRunner_OnBeforeRun;
            ProcessTaskRunner.OnAfterRun += ProcessTaskRunner_OnAfterRun;

            ProcessTaskRunner.ResourceInitializers = Resources;

            return;
        }

        //private void Compile()
        //{
        //    FormCompile.Compiler.Compile();
        //    return;
        //}

        //private void CompileAndRun()
        //{
        //    Compile();
        //    //TODO check compile result before run
        //    ProcessTaskRunner.GLDispose();
        //    ProcessTaskRunner.Run();
        //    return;
        //}

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
                FormCodeEditor.Task = null;
                FormCodeEditor.Task = ProcessTask;
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

        private void Compiler_OnBeforeCompile(ShaderCompiler inCompiler)
        {
            FormTextureView.Resources = null;
            return;
        }

        private void Compiler_OnAfterCompile(ShaderCompiler inCompiler)
        {
            FormTextureView.Resources = ProcessTaskRunner.Resources;
            return;
        }

        private void ProcessTaskRunner_OnBeforeRun(ImageProcessTaskRunner inRunner)
        {
            FormTextureView.Resources = null;
            return;
        }

        private void ProcessTaskRunner_OnAfterRun(ImageProcessTaskRunner inRunner)
        {
            FormTextureView.Resources = ProcessTaskRunner.Resources;
            return;
        }

        private void FormMain_Load(object sender, EventArgs e)
        { 
            FormCodeEditor = new DockFormCodeEditor();
            FormTextureView = new DockFormTextureView();
            FormTextureList = new DockFormTextureList();
            FormUniformVariable = new DockFormUniformVariable();
            FormCompile = new DockFormCompile(Compiler, ProcessTaskRunner);

            FormCodeEditor.Show(PanelDockMain);
            FormCompile.Show(PanelDockMain);
            FormTextureView.Show(PanelDockMain);
            FormTextureList.Show(PanelDockMain);
            FormUniformVariable.Show(PanelDockMain);

            FormCodeEditor.Task = ProcessTask;
            FormTextureList.Data = Resources.Textures;
            FormUniformVariable.SetShaderVariables(Resources, ProcessTask.UniformVariables);

            ProcessTaskRunner.Tasks.Add(ProcessTask);
            Project.ProcessTasks.Add(ProcessTask);
            Compiler.Project = Project;
            return;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Ctrl_GLControl.MakeCurrentSomeone();
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

        private DockFormCodeEditor FormCodeEditor
        { get; set; } = null;
        private DockFormCompile FormCompile
        { get; set; } = null;
        private DockFormTextureView FormTextureView
        { get; set; } = null;
        private DockFormTextureList FormTextureList
        { get; set; } = null;
        private DockFormUniformVariable FormUniformVariable
        { get; set; } = null;
    }
}
