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
            : this()
        {
            inParent.Nodes.Add(this);
            Data = inData;
            PathExistenceWatcher.Singleton.RegisterWatcher(Data.FilePath.Value, this);
            return;
        }

        public TreeNodeComputeShader(TreeNodeCollection inParent, ComputeShader inData)
            : this()
        {
            inParent.Add(this);
            Data = inData;
            PathExistenceWatcher.Singleton.RegisterWatcher(Data.FilePath.Value, this);
            return;
        }

        private TreeNodeComputeShader()
        {
            ImageIndex = (int)DockFormProjectFileView.NodeIcon.ExistTextFile;
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
