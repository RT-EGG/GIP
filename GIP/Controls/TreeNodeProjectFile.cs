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

        public override void DisposePathWatch()
        {
            PathExistenceWatcher.Singleton.UnregisterWatcher(Data.FilePath.Value, this);
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
                    m_Data.ComputeShaders.ForEach(item => { AddFile(item); });
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
            if (parent == this) {
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
                TreeView.InvokeOnUIThread(() => {
                    var parent = node.Parent;
                    parent.Nodes.Remove(node);
                    do {
                        if (parent is TreeNodeDirectory) {
                            if (parent.Nodes.Empty()) {
                                var newParent = parent.Parent;
                                if (newParent == null) {
                                    // absolute directory
                                    TreeView.Nodes.Remove(parent);
                                } else {
                                    // under the project node
                                    newParent.Nodes.Remove(parent);
                                }
                                parent = newParent;
                            } else {
                                break;
                            }
                        } else {
                            break;
                        }

                    } while (parent != null);
                });
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
            if ((inPath == Data.FilePath.Value) || (inPath == Path.GetDirectoryName(Data.FilePath.Value))) {
                outPath = new List<(string, TreeNode)> {
                    ("", this)
                };
                return true;
            }
            outPath = new List<(string, TreeNode)>();

            inPath = Data.FilePath.Value.PathAbsoluteToRelative(inPath);
            var split = inPath.Split('\\');
            if (split.Length <= 0) {
                return false;
            }

            TreeNode node = this, next = null;
            foreach (var (i, name) in split.Enumerate()) {
                if (name.EndsWith(":")) {
                    // find drive from parent's collection
                    next = TreeView.Nodes.FindByText(name, false).FirstOrDefault();
                } else {
                    // TODO
                    // support ".."
                    if (name == ".") {
                        // means current directory
                        continue;
                    }

                    next = (node == null) ? null : FindNodeIn(node, name);
                }

                outPath.Add((name, next));
                node = next;
            }

            return node != null;
        }

        private TreeNode FindOrCreateNodeForDirectory(string inDirectory)
        {
            if (!FindNodeFor(inDirectory, out var nodePath)) {
                string path;
                TreeNode parent = this; ;
                if (nodePath.First().Item1.EndsWith(":")) {
                    path = "";

                } else {
                    path = Path.GetDirectoryName(Data.FilePath.Value);
                    parent = this;
                }

                foreach (var d in nodePath) {
                    var (name, node) = d;

                    if (name != ".") {
                        if (path == "") {
                            path = name;
                            node = new TreeNodeDirectory(TreeView.Nodes, path);
                        } else {
                            path = string.Join("\\", path, name);
                            node = new TreeNodeDirectory(parent, path);
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
