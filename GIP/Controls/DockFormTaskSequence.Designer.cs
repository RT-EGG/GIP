namespace GIP.Controls
{
    partial class DockFormTaskSequence
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
            this.tvTaskSequence = new System.Windows.Forms.TreeView();
            this.MenuTreeNodePopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_NewTask = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_NewTask_Compute = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_NewTask_ExportTexture = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_InsertTask = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_InsertTask_Compute = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_InsertTask_ExportTexture = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonRunSequence = new System.Windows.Forms.Button();
            this.MenuItem_NewTask_CountingLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_InsertTask_CountingLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTreeNodePopup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvTaskSequence
            // 
            this.tvTaskSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTaskSequence.Location = new System.Drawing.Point(0, 0);
            this.tvTaskSequence.Name = "tvTaskSequence";
            this.tvTaskSequence.Size = new System.Drawing.Size(387, 448);
            this.tvTaskSequence.TabIndex = 0;
            this.tvTaskSequence.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTaskSequence_AfterSelect);
            this.tvTaskSequence.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvTaskSequence_NodeMouseClick);
            // 
            // MenuTreeNodePopup
            // 
            this.MenuTreeNodePopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_NewTask,
            this.MenuItem_InsertTask,
            this.MenuItem_Delete});
            this.MenuTreeNodePopup.Name = "MenuTreeNodePopup";
            this.MenuTreeNodePopup.Size = new System.Drawing.Size(181, 92);
            // 
            // MenuItem_NewTask
            // 
            this.MenuItem_NewTask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_NewTask_Compute,
            this.MenuItem_NewTask_ExportTexture,
            this.MenuItem_NewTask_CountingLoop});
            this.MenuItem_NewTask.Name = "MenuItem_NewTask";
            this.MenuItem_NewTask.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_NewTask.Text = "New task";
            // 
            // MenuItem_NewTask_Compute
            // 
            this.MenuItem_NewTask_Compute.Name = "MenuItem_NewTask_Compute";
            this.MenuItem_NewTask_Compute.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_NewTask_Compute.Text = "Compute";
            this.MenuItem_NewTask_Compute.Click += new System.EventHandler(this.MenuItem_NewTask_Click);
            // 
            // MenuItem_NewTask_ExportTexture
            // 
            this.MenuItem_NewTask_ExportTexture.Name = "MenuItem_NewTask_ExportTexture";
            this.MenuItem_NewTask_ExportTexture.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_NewTask_ExportTexture.Text = "Export texture";
            this.MenuItem_NewTask_ExportTexture.Click += new System.EventHandler(this.MenuItem_NewTask_Click);
            // 
            // MenuItem_InsertTask
            // 
            this.MenuItem_InsertTask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_InsertTask_Compute,
            this.MenuItem_InsertTask_ExportTexture,
            this.MenuItem_InsertTask_CountingLoop});
            this.MenuItem_InsertTask.Name = "MenuItem_InsertTask";
            this.MenuItem_InsertTask.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_InsertTask.Text = "Insert task";
            // 
            // MenuItem_InsertTask_Compute
            // 
            this.MenuItem_InsertTask_Compute.Name = "MenuItem_InsertTask_Compute";
            this.MenuItem_InsertTask_Compute.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_InsertTask_Compute.Text = "Compute";
            this.MenuItem_InsertTask_Compute.Click += new System.EventHandler(this.MenuItem_InsertTask_Click);
            // 
            // MenuItem_InsertTask_ExportTexture
            // 
            this.MenuItem_InsertTask_ExportTexture.Name = "MenuItem_InsertTask_ExportTexture";
            this.MenuItem_InsertTask_ExportTexture.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_InsertTask_ExportTexture.Text = "Export texture";
            this.MenuItem_InsertTask_ExportTexture.Click += new System.EventHandler(this.MenuItem_InsertTask_Click);
            // 
            // MenuItem_Delete
            // 
            this.MenuItem_Delete.Name = "MenuItem_Delete";
            this.MenuItem_Delete.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_Delete.Text = "Delete";
            this.MenuItem_Delete.Click += new System.EventHandler(this.MenuItem_Delete_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ButtonRunSequence, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 417);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 31);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ButtonRunSequence
            // 
            this.ButtonRunSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonRunSequence.Location = new System.Drawing.Point(3, 3);
            this.ButtonRunSequence.Name = "ButtonRunSequence";
            this.ButtonRunSequence.Size = new System.Drawing.Size(75, 25);
            this.ButtonRunSequence.TabIndex = 0;
            this.ButtonRunSequence.Text = "Run";
            this.ButtonRunSequence.UseVisualStyleBackColor = true;
            this.ButtonRunSequence.Click += new System.EventHandler(this.ButtonRunSequence_Click);
            // 
            // MenuItem_NewTask_CountingLoop
            // 
            this.MenuItem_NewTask_CountingLoop.Name = "MenuItem_NewTask_CountingLoop";
            this.MenuItem_NewTask_CountingLoop.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_NewTask_CountingLoop.Text = "Counting-loop";
            this.MenuItem_NewTask_CountingLoop.Click += new System.EventHandler(this.MenuItem_NewTask_Click);
            // 
            // MenuItem_InsertTask_CountingLoop
            // 
            this.MenuItem_InsertTask_CountingLoop.Name = "MenuItem_InsertTask_CountingLoop";
            this.MenuItem_InsertTask_CountingLoop.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_InsertTask_CountingLoop.Text = "Counting-loop";
            this.MenuItem_InsertTask_CountingLoop.Click += new System.EventHandler(this.MenuItem_InsertTask_Click);
            // 
            // DockFormTaskSequence
            // 
            this.ClientSize = new System.Drawing.Size(387, 448);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tvTaskSequence);
            this.Name = "DockFormTaskSequence";
            this.Text = "Task sequence";
            this.MenuTreeNodePopup.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvTaskSequence;
        private System.Windows.Forms.ContextMenuStrip MenuTreeNodePopup;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Delete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ButtonRunSequence;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_NewTask;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_NewTask_Compute;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_NewTask_ExportTexture;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_InsertTask;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_InsertTask_Compute;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_InsertTask_ExportTexture;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_NewTask_CountingLoop;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_InsertTask_CountingLoop;
    }
}
