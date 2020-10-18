namespace GIP.Controls
{
    partial class DockFormProjectFileView
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockFormProjectFileView));
            this.TreeViewFiles = new System.Windows.Forms.TreeView();
            this.NodeIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.MenuTreeNodePopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_CreateNewTextFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_AddExistingFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_RemoveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_OpenInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_AddExistingDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTreeNodePopup.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeViewFiles
            // 
            this.TreeViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewFiles.ImageIndex = 0;
            this.TreeViewFiles.ImageList = this.NodeIconImageList;
            this.TreeViewFiles.LabelEdit = true;
            this.TreeViewFiles.Location = new System.Drawing.Point(0, 0);
            this.TreeViewFiles.Name = "TreeViewFiles";
            this.TreeViewFiles.SelectedImageIndex = 0;
            this.TreeViewFiles.Size = new System.Drawing.Size(284, 261);
            this.TreeViewFiles.TabIndex = 0;
            this.TreeViewFiles.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeViewFiles_BeforeLabelEdit);
            this.TreeViewFiles.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeViewFiles_AfterLabelEdit);
            this.TreeViewFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewFiles_AfterSelect);
            this.TreeViewFiles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewFiles_NodeMouseClick);
            this.TreeViewFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TreeViewFiles_KeyUp);
            // 
            // NodeIconImageList
            // 
            this.NodeIconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NodeIconImageList.ImageStream")));
            this.NodeIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.NodeIconImageList.Images.SetKeyName(0, "ProjectFile");
            this.NodeIconImageList.Images.SetKeyName(1, "MissingProject");
            this.NodeIconImageList.Images.SetKeyName(2, "Directory");
            this.NodeIconImageList.Images.SetKeyName(3, "MissingDirectory");
            this.NodeIconImageList.Images.SetKeyName(4, "TextFile");
            this.NodeIconImageList.Images.SetKeyName(5, "MissingTextFile");
            // 
            // MenuTreeNodePopup
            // 
            this.MenuTreeNodePopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_CreateNewTextFile,
            this.MenuItem_AddExistingFile,
            this.MenuItem_AddExistingDirectory,
            this.MenuItem_RemoveFile,
            this.MenuItem_Delete,
            this.MenuItem_OpenInExplorer});
            this.MenuTreeNodePopup.Name = "MenuTreeNodePopup";
            this.MenuTreeNodePopup.Size = new System.Drawing.Size(199, 136);
            // 
            // MenuItem_CreateNewTextFile
            // 
            this.MenuItem_CreateNewTextFile.Name = "MenuItem_CreateNewTextFile";
            this.MenuItem_CreateNewTextFile.Size = new System.Drawing.Size(198, 22);
            this.MenuItem_CreateNewTextFile.Text = "Create new text file";
            this.MenuItem_CreateNewTextFile.Click += new System.EventHandler(this.MenuItem_CreateNewTextFile_Click);
            // 
            // MenuItem_AddExistingFile
            // 
            this.MenuItem_AddExistingFile.Name = "MenuItem_AddExistingFile";
            this.MenuItem_AddExistingFile.Size = new System.Drawing.Size(198, 22);
            this.MenuItem_AddExistingFile.Text = "Add existing file...";
            this.MenuItem_AddExistingFile.Click += new System.EventHandler(this.MenuItem_AddExistingFile_Click);
            // 
            // MenuItem_RemoveFile
            // 
            this.MenuItem_RemoveFile.Name = "MenuItem_RemoveFile";
            this.MenuItem_RemoveFile.Size = new System.Drawing.Size(198, 22);
            this.MenuItem_RemoveFile.Text = "Remove file";
            this.MenuItem_RemoveFile.Click += new System.EventHandler(this.MenuItem_RemoveFile_Click);
            // 
            // MenuItem_Delete
            // 
            this.MenuItem_Delete.Name = "MenuItem_Delete";
            this.MenuItem_Delete.Size = new System.Drawing.Size(198, 22);
            this.MenuItem_Delete.Text = "Delete";
            this.MenuItem_Delete.Click += new System.EventHandler(this.MenuItem_Delete_Click);
            // 
            // MenuItem_OpenInExplorer
            // 
            this.MenuItem_OpenInExplorer.Name = "MenuItem_OpenInExplorer";
            this.MenuItem_OpenInExplorer.Size = new System.Drawing.Size(198, 22);
            this.MenuItem_OpenInExplorer.Text = "Open in explorer";
            this.MenuItem_OpenInExplorer.Click += new System.EventHandler(this.MenuItem_OpenInExplorer_Click);
            // 
            // MenuItem_AddExistingDirectory
            // 
            this.MenuItem_AddExistingDirectory.Name = "MenuItem_AddExistingDirectory";
            this.MenuItem_AddExistingDirectory.Size = new System.Drawing.Size(198, 22);
            this.MenuItem_AddExistingDirectory.Text = "Add existing directory...";
            this.MenuItem_AddExistingDirectory.Click += new System.EventHandler(this.MenuItem_AddExistingDirectory_Click);
            // 
            // DockFormProjectFileView
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.TreeViewFiles);
            this.Name = "DockFormProjectFileView";
            this.Text = "Files";
            this.MenuTreeNodePopup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeViewFiles;
        private System.Windows.Forms.ContextMenuStrip MenuTreeNodePopup;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_CreateNewTextFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_AddExistingFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Delete;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_RemoveFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_OpenInExplorer;
        private System.Windows.Forms.ImageList NodeIconImageList;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_AddExistingDirectory;
    }
}
