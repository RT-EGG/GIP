﻿using System;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Microsoft.WindowsAPICodePack.Dialogs;
using GIP.Common;
using GIP.Core;

namespace GIP.Controls
{
    public partial class DockFormProjectFileView : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public enum NodeIcon
        {
            ProjectFile = 0,
            MissingProjectFile,
            ExistDirectory,
            MissingDirectory,
            ExistTextFile,
            MissingTextFile
        }

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

                    new TreeNodeProjectFile(TreeViewFiles.Nodes, m_Project);
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

        private void RemoveFile(TreeNode inNode)
        {
            if (!(inNode is TreeNodeComputeShader)) {
                return;
            }

            (inNode as TreeNodeComputeShader).Data.GLDispose();
            Data.ComputeShaders.Remove((inNode as TreeNodeComputeShader).Data);
            return;
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
            string directory;
            switch (TreeViewFiles.SelectedNode) {
                case TreeNodeDirectory d:
                    directory = d.DirectoryPath;
                    break;
                case TreeNodeProjectFile p:
                    directory = Path.GetDirectoryName(p.Data?.FilePath?.Value);
                    break;
                default:
                    return;
            }

            string path = $"{directory}\\new_file.txt";
            int index = 0;
            while (File.Exists(path)) {
                path = $"{directory}\\new_file{++index}.txt";
            }
            File.Create(path).Close();
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

        private void MenuItem_AddExistingDirectory_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = TreeViewFiles.SelectedNode is TreeNodeDirectory
                                        ? (TreeViewFiles.SelectedNode as TreeNodeDirectory).DirectoryPath
                                        : Path.GetDirectoryName(Data.FilePath.Value);
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok) {
                (TreeViewFiles.Nodes[0] as TreeNodeProjectFile).FindNodeFor(dialog.FileName);
            }
            return;
        }

        private void MenuItem_RemoveFile_Click(object sender, EventArgs e)
        {
            RemoveFile(TreeViewFiles.SelectedNode);
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
                default:
                    return;
            }
            RemoveFile(TreeViewFiles.SelectedNode);
            return;
        }

        private void MenuItem_OpenInExplorer_Click(object sender, EventArgs e)
        {
            if (!(TreeViewFiles.SelectedNode is ITreeNodePath)) {
                return;
            }

            var path = (TreeViewFiles.SelectedNode as ITreeNodePath).Path;
            if (path != null) {
                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{path}\"");
            }
            return;
        }

        private void TreeViewFiles_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.CancelEdit = !(e.Node is TreeNodeComputeShader);
            return;
        }

        private void TreeViewFiles_AfterLabelEdit(object sender, NodeLabelEditEventArgs args)
        {
            if (args.Label == null) {
                return;
            }
            if (!(args.Node is ITreeNodePath)) {
                return;
            }

            try {
                args.CancelEdit = true;
                (args.Node as ITreeNodePath).ChangePathName(args.Label);
                args.CancelEdit = false;

            } catch (ChangePathException e) {
                MessageBox.Show(e.Message, "GIP");
            } catch (Exception e) {
                Logger.DefaultLogger.PushLog(this, new LogExceptionData(e));
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
            MenuItem_AddExistingFile.Visible = (inNode is TreeNodeDirectory) | (inNode is TreeNodeProjectFile);
            MenuItem_AddExistingDirectory.Visible = (inNode is TreeNodeDirectory) | (inNode is TreeNodeProjectFile);
            MenuItem_CreateNewTextFile.Visible = (inNode is TreeNodeDirectory) | (inNode is TreeNodeProjectFile);
            MenuItem_RemoveFile.Visible = inNode is TreeNodeComputeShader;
            MenuItem_Delete.Visible = !(inNode is TreeNodeProjectFile) && (inNode as ITreeNodePath).PathExist;
            MenuItem_OpenInExplorer.Visible = inNode is ITreeNodePath;

            MenuTreeNodePopup.Show(inLocation);
            return;
        }

        private Project m_Project = null;

        public abstract class FileTreeNode : TreeNode
        {
            public abstract void DisposePathWatch();

            public void SetIcon(NodeIcon inValue)
            {
                TreeView.InvokeOnUIThread(() => {
                    ImageIndex = (int)inValue;
                    SelectedImageIndex = ImageIndex;
                    TreeView.Invalidate();
                });
                return;
            }

            public string DirectoryPath
            {
                get {
                    if (this is ITreeNodePath) {
                        return Path.GetDirectoryName((this as ITreeNodePath).Path) ?? "";
                    }

                    switch (Parent) {
                        case TreeNodeProjectFile project:
                            return project.DirectoryPath;
                        case TreeNodeDirectory directory:
                            return directory.Path;
                    }
                    throw new InvalidProgramException("The node must have parent as project or directory, or be project.");
                }
            }
        }
    }
}
