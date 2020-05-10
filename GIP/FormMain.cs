using System;
using System.Windows.Forms;
using System.IO;
using GIP.Core;
using GIP.Common;

namespace GIP
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            ProcessTask = new ImageProcessTask(Resources);
            return;
        }

        private bool Compile()
        {
            CtrlTextureView.MakeCurrent();
            if (ProcessTask.CompileAndLink(TextBoxCode.Text)) {
                TextBoxCompileState.Text = "Compile successed.";
                return true;
            } else {
                TextBoxCompileState.Text = ProcessTask.Error.Linearize();
                return false;
            }            
        }

        private bool CompileAndRun()
        {
            if (!Compile()) {
                return false;
            }

            CtrlTextureView.Resources = null;

            ProcessTask.DispatchGroupSizeX = (int)UdDispatchSizeX.Value;
            ProcessTask.DispatchGroupSizeY = (int)UdDispatchSizeY.Value;
            ProcessTask.DispatchGroupSizeZ = (int)UdDispatchSizeZ.Value;
            ProcessTaskRunnner.GLDispose();
            ProcessTaskRunnner.Run(ProcessTask);
            CtrlTextureView.Resources = ProcessTaskRunnner.Resources;
            return true;
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
                TextBoxCode.Text = reader.ReadToEnd();
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
                writer.Write(TextBoxCode.Text);
            }
            return;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            CtrlTextureView.MakeCurrent();
            CtrlShaderVariables.SetShaderVariables(Resources, ProcessTask.UniformVariables);
            return;
        }

        private void ButtonCompile_Click(object sender, EventArgs e)
        {
            Compile();
            return;
        }

        private void ButtonCompileAndRun_Click(object sender, EventArgs e)
        {
            CompileAndRun();
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
        private ImageProcessTaskRunner ProcessTaskRunnner
        { get; } = new ImageProcessTaskRunner();
    }
}
