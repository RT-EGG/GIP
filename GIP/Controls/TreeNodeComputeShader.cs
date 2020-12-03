using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GIP.Common;
using GIP.Core;

namespace GIP.Controls
{
    class TreeNodeComputeShader : DockFormProjectFileView.FileTreeNode, IPathExistenceWatchReactioner, ITreeNodePath
    {
        public TreeNodeComputeShader(TreeNode inParent, ComputeShader inData)
        {
            inParent.Nodes.Add(this);
            Data = inData;
            PathExistenceWatcher.Singleton.RegisterWatcher(Data.FilePath.Value, this);
            return;
        }

        public TreeNodeComputeShader(TreeNodeCollection inParent, ComputeShader inData)
        {
            inParent.Add(this);
            Data = inData;
            PathExistenceWatcher.Singleton.RegisterWatcher(Data.FilePath.Value, this);
            return;
        }

        public override void DisposePathWatch()
        {
            PathExistenceWatcher.Singleton.UnregisterWatcher(Data.FilePath.Value, this);
            return;
        }

        public ComputeShader Data
        {
            get => m_Data;
            private set {
                if (m_Data == value) {
                    return;
                }

                m_Subscription.DisposeAndClear();

                m_Data = value;
                if (m_Data == null) {
                    TreeView.InvokeOnUIThread(() => Text = "<N/A>");
                } else {
                    m_Subscription.Add(m_Data.FilePath.Subscribe(path => {
                        TreeView.InvokeOnUIThread(() => Text = Path.GetFileName(m_Data.FilePath.Value));
                    }));
                }
                return;
            }
        }

        string ITreeNodePath.Path => Data?.FilePath?.Value;
        bool ITreeNodePath.PathExist => File.Exists((this as ITreeNodePath).Path);
        void ITreeNodePath.ChangePathName(string inName)
        {
            string oldPath = Data.FilePath.Value;
            string newPath = StringExtensions.JoinPath(DirectoryPath, inName);

            if (!File.Exists(oldPath)) {
                throw new OldPathNotFoundException($"Original path \"{oldPath}\" is not found.");
            }

            if (File.Exists(newPath)) {
                throw new PathAlreadyExistException($"File \"{inName}\" already exists.");
            }

            Data.FilePath.Value = newPath;
            try {
                File.Move(oldPath, newPath);
                PathExistenceWatcher.Singleton.UnregisterWatcher(oldPath, this);
                PathExistenceWatcher.Singleton.RegisterWatcher(newPath, this);
            } catch (Exception e) {
                Data.FilePath.Value = oldPath;
                throw e;
            }
            return;
        }

        void IPathExistenceWatchReactioner.OnDelete(string inPath)
        {
            SetIcon(DockFormProjectFileView.NodeIcon.MissingTextFile);
            return;
        }

        void IPathExistenceWatchReactioner.OnRestore(string inPath)
        {
            SetIcon(DockFormProjectFileView.NodeIcon.ExistTextFile);
            return;
        }

        private ComputeShader m_Data = null;
        private List<IDisposable> m_Subscription = new List<IDisposable>();
    }
}
