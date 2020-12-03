using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GIP.Common;

namespace GIP.Controls
{
    class TreeNodeDirectory : DockFormProjectFileView.FileTreeNode, IPathExistenceWatchReactioner, ITreeNodePath
    {
        public TreeNodeDirectory(TreeNodeCollection inParent, string inPath)
            : this(inPath)
        {
            inParent.Add(this);
            PathExistenceWatcher.Singleton.RegisterWatcher(Path, this);            
            return;
        }

        public TreeNodeDirectory(TreeNode inParent, string inPath)
            : this(inPath)
        {
            inParent.Nodes.Add(this);
            PathExistenceWatcher.Singleton.RegisterWatcher(Path, this);
            return;
        }

        private TreeNodeDirectory(string inPath)
        {
            Path = inPath;
            Text = Path.Split('\\').Last();
            return;
        }

        public override void DisposePathWatch()
        {
            PathExistenceWatcher.Singleton.UnregisterWatcher(Path, this);
            return;
        }

        ~TreeNodeDirectory()
        {
            return;
        }

        void IPathExistenceWatchReactioner.OnDelete(string inPath)
        {
            SetIcon(DockFormProjectFileView.NodeIcon.MissingDirectory);
            return;
        }

        void IPathExistenceWatchReactioner.OnRestore(string inPath)
        {
            SetIcon(DockFormProjectFileView.NodeIcon.ExistDirectory);
            return;
        }

        public string Path
        { get; private set; } = "";
        bool ITreeNodePath.PathExist => Directory.Exists(Path);

        void ITreeNodePath.ChangePathName(string inName)
        {
            string oldPath = Path;
            string newPath = StringExtensions.JoinPath(DirectoryPath, inName);

            if (!Directory.Exists(oldPath)) {
                throw new OldPathNotFoundException($"Original path \"{oldPath}\" is not found.");
            }

            if (Directory.Exists(newPath)) {
                throw new PathAlreadyExistException($"File \"{inName}\" already exists.");
            }

            Path = newPath;
            try {
                Directory.Move(oldPath, newPath);
                PathExistenceWatcher.Singleton.UnregisterWatcher(oldPath, this);
                PathExistenceWatcher.Singleton.RegisterWatcher(newPath, this);
            } catch (Exception e) {
                Path = oldPath;
                throw e;
            }
            return;
        }
    }
}
