using System.Linq;
using System.Windows.Forms;
using System.IO;
using GIP.Common;

namespace GIP.Controls
{
    class TreeNodeDirectory : TreeNode, IFileModificationReactioner, IFileCreationReactioner
    {
        public TreeNodeDirectory(string inPath)
        {
            DirectoryPath = inPath;
            Text = DirectoryPath.Split('\\').Last();
            AddNodesInDirectory();

            FileModificationMonitor.AddCreationRaactioner(DirectoryPath, this);
            FileModificationMonitor.AddModificationReactioner(DirectoryPath, this);
            return;
        }

        ~TreeNodeDirectory()
        {
            FileModificationMonitor.RemoveCreateionReactioner(DirectoryPath, this);
            FileModificationMonitor.RemoveModificationReactioner(DirectoryPath, this);
            return;
        }

        private void AddNodesInDirectory()
        {
            Nodes.Clear();
            foreach (var file in  Directory.GetDirectories(DirectoryPath, "*", SearchOption.TopDirectoryOnly)) {
                Nodes.Add(new TreeNodeDirectory(file));
            }
            return;
        }

        public void OnFileCreated(FileSystemEventArgs inArgs)
        {
            if (File.GetAttributes(inArgs.FullPath).HasFlag(FileAttributes.Directory)) {
                TreeView.InvokeOnUIThread(() => { Nodes.Add(new TreeNodeDirectory(inArgs.FullPath)); });
            }
            return;
        }

        public void OnFileChanged(FileSystemEventArgs inArgs)
        {
            return;
        }

        public void OnFileDeleted(FileSystemEventArgs inArgs)
        {
            if (Parent != null) {
                TreeView.InvokeOnUIThread(() => { Parent.Nodes.Remove(this); });
            }
            return;
        }

        public void OnFileRenamed(RenamedEventArgs inArgs)
        {
            FileModificationMonitor.RemoveCreateionReactioner(DirectoryPath, this);
            FileModificationMonitor.RemoveModificationReactioner(DirectoryPath, this);
            DirectoryPath = inArgs.FullPath;
            FileModificationMonitor.AddCreationRaactioner(DirectoryPath, this);
            FileModificationMonitor.AddModificationReactioner(DirectoryPath, this);

            TreeView.InvokeOnUIThread(() => { Text = DirectoryPath.Split('\\').Last(); });
            return;
        }

        public string DirectoryPath
        { get; private set; } = "";
    }
}
