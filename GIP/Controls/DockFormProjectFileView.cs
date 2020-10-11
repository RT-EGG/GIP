using System;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using GIP.Core;

namespace GIP.Controls
{
    public partial class DockFormProjectFileView : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public event ComputeShaderNotifyEvent OnComputeShaderSelect;

        public DockFormProjectFileView()
        {
            InitializeComponent();
            Data = null;
        }

        public Project Data
        {
            get => m_Project;
            set {
                try {
                    if (m_Project == value) {
                        return;
                    }
                    m_Project = value;
                    TreeViewFiles.Enabled = m_Project != null;
                    TreeViewFiles.Nodes.Clear();
                    if (m_Project == null) {
                        return;
                    }

                    TreeViewFiles.Nodes.Add(new TreeNodeProjectFile(m_Project));
                    TreeViewFiles.Nodes[0].Expand();

                } catch (Exception e) {
                    m_Project = null;
                    throw e;

                } finally {
                    this.Enabled = m_Project != null;
                }
                return;
            }
        }

        protected override string GetPersistString()
        {
            return MainDockFormType.ProjectFiles.ToPersistString();
        }

        private void TreeViewFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch  (e.Button) {
                case MouseButtons.Right:
                    TreeViewFiles.SelectedNode = e.Node;
                    RequestTreeViewPopup(TreeViewFiles.PointToScreen(e.Location), e.Node);
                    break;
            }
            return;
        }

        private void MenuItem_CreateNewTextFile_Click(object sender, EventArgs e)
        {
            if (!(TreeViewFiles.SelectedNode is TreeNodeDirectory)) {
                return;
            }

            string directory = (TreeViewFiles.SelectedNode as TreeNodeDirectory).DirectoryPath;
            string path = $"{directory}\\new_file.txt";
            int index = 0;
            while (File.Exists(path)) {
                path = $"{directory}\\new_file{++index}.txt";
            }
            File.Create(path);
            m_Project.ComputeShaders.Add(new ComputeShader(ComputeShaderFileType.Text, path));

            TreeViewFiles.SelectedNode.Expand();
            var newNode = (TreeViewFiles.Nodes[0] as TreeNodeProjectFile).FindNodeFor(path);
            TreeViewFiles.SelectedNode = newNode;
            newNode.BeginEdit();
            return;
        }

        private void MenuItem_AddExistingFile_Click(object sender, EventArgs e)
        {          
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = TreeViewFiles.SelectedNode is TreeNodeDirectory
                                        ? (TreeViewFiles.SelectedNode as TreeNodeDirectory).DirectoryPath
                                        : Path.GetDirectoryName(Data.FilePath.Value);
            
            if (dialog.ShowDialog() == DialogResult.OK) {
                if (Data.ComputeShaders.FirstOrDefault(s => s.FilePath.Value == dialog.FileName) == null) {
                    // if ShaderSources has file of the path, do nothing.

                    if (ComputeShader.IsBinaryFile(dialog.FileName)) {
                    } else {
                        Data.ComputeShaders.Add(new ComputeShader(ComputeShaderFileType.Text, dialog.FileName));
                    }
                }
            }
            return;
        }

        private void MenuItem_RemoveFile_Click(object sender, EventArgs e)
        {
            var node = TreeViewFiles.SelectedNode;
            if (!(node is TreeNodeComputeShader)) {
                return;
            }

            (node as TreeNodeComputeShader).Data.GLDispose();
            Data.ComputeShaders.Remove((node as TreeNodeComputeShader).Data);
            return;
        }

        private void MenuItem_Delete_Click(object sender, EventArgs e)
        {
            switch (TreeViewFiles.SelectedNode) {
                case TreeNodeComputeShader s:
                    FileSystem.DeleteFile(s.Data.FilePath.Value, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    break;
                case TreeNodeDirectory d:
                    FileSystem.DeleteDirectory(d.DirectoryPath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    break;
            }
            return;
        }

        private void MenuItem_OpenInExplorer_Click(object sender, EventArgs e)
        {
            if (!(TreeViewFiles.SelectedNode is TreeNodeDirectory)) {
                return;
            }

            var path = (TreeViewFiles.SelectedNode as TreeNodeDirectory).DirectoryPath;
            System.Diagnostics.Process.Start(path);
            return;
        }

        private void TreeViewFiles_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //
        }

        private void TreeViewFiles_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null) {
                return;
            }
            bool isFile = true;
            string path;
            switch (e.Node) {
                case TreeNodeComputeShader source:
                    path = source.Data.FilePath.Value;
                    break;
                case TreeNodeProjectFile project:
                    path = project.Data.FilePath.Value;
                    break;
                case TreeNodeDirectory directory:
                    path = directory.DirectoryPath;
                    isFile = false;
                    break;
                default:
                    throw new InvalidProgramException($"Invalid node type \"{e.Node.GetType()}\".");
            }
            string parentDirectory = Path.GetDirectoryName(path);
            string newPath = $"{parentDirectory}\\{e.Label}";
            if (isFile) {
                if (File.Exists(newPath)) {
                    MessageBox.Show($"File \"{newPath}\" has already existed.", "GIP");
                    e.CancelEdit = true;
                    return;
                } 
                File.Move(path, newPath);
                
            } else {
                if (Directory.Exists(newPath)) {
                    MessageBox.Show($"Directory \"{newPath}\" has already existed.", "GIP");
                    e.CancelEdit = true;
                    return;
                }

                Directory.Move(path, newPath);
            }
            return;
        }

        private void TreeViewFiles_KeyUp(object sender, KeyEventArgs e)
        {
            var node = TreeViewFiles.SelectedNode;
            if (node == null) {
                return;
            }
            
            switch (e.KeyCode) {
                case Keys.F2:
                    node.BeginEdit();       
                    break;
            }
            return;
        }

        private void TreeViewFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is TreeNodeComputeShader) {
                OnComputeShaderSelect?.Invoke((e.Node as TreeNodeComputeShader).Data);
            } else {
                OnComputeShaderSelect?.Invoke(null);
            }
            return;
        }

        private void RequestTreeViewPopup(Point inLocation, TreeNode inNode)
        {
            MenuItem_AddExistingFile.Visible = inNode is TreeNodeDirectory;
            MenuItem_CreateNewTextFile.Visible = inNode is TreeNodeDirectory;
            MenuItem_RemoveFile.Visible = inNode is TreeNodeComputeShader;
            MenuItem_Delete.Visible = !(inNode is TreeNodeProjectFile);
            MenuItem_OpenInExplorer.Visible = inNode is TreeNodeDirectory;

            MenuTreeNodePopup.Show(inLocation);
            return;
        }

        private Project m_Project = null;
    }
}
