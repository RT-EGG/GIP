using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GIP.Core;
using GIP.Common;

namespace GIP.Controls
{
    class TreeNodeProjectFile : DockFormProjectFileView.FileTreeNode, IPathExistenceWatchReactioner, ITreeNodePath
    {
        public TreeNodeProjectFile(TreeNodeCollection inParent, Project inData)
        {
            inParent.Add(this);

            Data = inData;
            PathExistenceWatcher.Singleton.RegisterWatcher(Data.FilePath.Value, this);
            return;
        }

        public Project Data
        {
            get => m_Data;
            set {
                if (m_Data == value) {
                    return;
                }

                m_ProjectSubscription.DisposeAndClear();

                m_Data = value;
                if (m_Data != null) {
                    m_Data.FilePath.Subscribe((p) => Text = m_Data.Name);
                    m_Data.ComputeShaders.SubscribeCollectionChanged((s, e) => Data_ShaderSources_CollectionChanged(s, e));

                    Nodes.Clear();
                    AddNodesInDirectory();
                    m_Data.ComputeShaders.ForEach(item => { AddFile(item); });
                }
                return;
            }
        }

        string ITreeNodePath.Path => Data?.FilePath?.Value;

        private void Data_ShaderSources_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null) {
                foreach (var item in e.NewItems) {
                    if (!(item is ComputeShader)) {
                        continue;
                    }

                    AddFile(item as ComputeShader);
                }
            }

            if (e.OldItems != null) {
                foreach (var item in e.OldItems) {
                    if (!(item is ComputeShader)) {
                        continue;
                    }

                    RemoveFile(item as ComputeShader);
                }
            }
            return;
        }

        private void AddFile(ComputeShader inShader)
        {
            string path = inShader.FilePath.Value.UnifyPathDelimitter().RemoveExtraDelimitter();
            TreeNode parent = FindOrCreateNodeForDirectory(Path.GetDirectoryName(path));
            if (parent == null) {
                new TreeNodeComputeShader(Nodes, inShader);
                Expand();
            } else {
                new TreeNodeComputeShader(parent, inShader);
                parent.Expand();
            }
            return;
        }

        private void RemoveFile(ComputeShader inShader)
        {
            if (FindNodeFor(inShader.FilePath.Value, out var nodePath)) {
                var node = nodePath.Last().Item2;
                TreeView.InvokeOnUIThread(() => node.Parent.Nodes.Remove(node));
            }
            return;
        }

        public TreeNode FindNodeFor(string inPath)
        {
            if (FindNodeFor(inPath, out var pathes)) {
                return pathes.Last().Item2;
            }
            return null;
        }

        private bool FindNodeFor(string inPath, out IList<(string, TreeNode)> outPath)
        {
            inPath = Data.FilePath.Value.PathAbsoluteToRelative(inPath);
            outPath = new List<(string, TreeNode)>();

            var split = inPath.Split('\\');
            if (split.Length <= 0) {
                return false;
            }
            if (split[0].EndsWith(":")) {
                return false;
            }

            TreeNode node = this;
            outPath.Add((".", node));
            foreach (var (i, name) in split.Enumerate()) {
                if (name == ".") {
                    // means current directory
                    continue;
                }

                TreeNode next = (node == null) ? null : FindNodeIn(node, name);
                outPath.Add((name, next));

                node = next;
            }

            return node != null;
        }

        private TreeNode FindOrCreateNodeForDirectory(string inDirectory)
        {
            if (!FindNodeFor(inDirectory, out var nodePath)) {
                string path = Path.GetDirectoryName(Data.FilePath.Value);
                TreeNode parent = null;
                foreach (var d in nodePath) {
                    var (name, node) = d;

                    if (name != ".") {
                        path += $"\\{name}";

                        if (node == null) {
                            node = new TreeNodeDirectory(parent, path);
                            continue;
                        }
                    }

                    parent = node;
                }
                return parent;
            }

            return nodePath.Last().Item2;
        }

        private TreeNode FindNodeIn(TreeNode inNode, string inName)
        {
            foreach (TreeNode child in inNode.Nodes) {
                if (child.Text == inName) {
                    return child;
                }
            }
            return null;
        }

        private void AddNodesInDirectory()
        {
            Nodes.Clear();
            foreach (var file in Directory.GetDirectories(Path.GetDirectoryName(Data.FilePath.Value), "*", SearchOption.TopDirectoryOnly)) {
                new TreeNodeDirectory(this, file);
            }
            return;
        }

        void IPathExistenceWatchReactioner.OnDelete(string inPath)
        {
            SetIcon(DockFormProjectFileView.NodeIcon.MissingProjectFile);
            return;
        }

        void IPathExistenceWatchReactioner.OnRestore(string inPath)
        {
            SetIcon(DockFormProjectFileView.NodeIcon.ProjectFile);
            return;
        }

        private List<IDisposable> m_ProjectSubscription = new List<IDisposable>();
        private Project m_Data = null;
    }
}
