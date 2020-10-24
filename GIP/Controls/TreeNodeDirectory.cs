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
            PathExistenceWatcher.Singleton.RegisterWatcher(DirectoryPath, this);            
            return;
        }

        public TreeNodeDirectory(TreeNode inParent, string inPath)
            : this(inPath)
        {
            inParent.Nodes.Add(this);
            PathExistenceWatcher.Singleton.RegisterWatcher(DirectoryPath, this);
            return;
        }

        private TreeNodeDirectory(string inPath)
        {
            DirectoryPath = inPath;
            Text = DirectoryPath.Split('\\').Last();
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

        public string DirectoryPath
        { get; private set; } = "";

        string ITreeNodePath.Path => DirectoryPath;
    }
}
