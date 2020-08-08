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
            this.MenuItem_NewComputeTask = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_InsertNewComputeTask = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonRunSequence = new System.Windows.Forms.Button();
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
            this.MenuItem_NewComputeTask,
            this.MenuItem_InsertNewComputeTask,
            this.MenuItem_Delete});
            this.MenuTreeNodePopup.Name = "MenuTreeNodePopup";
            this.MenuTreeNodePopup.Size = new System.Drawing.Size(203, 70);
            // 
            // MenuItem_NewComputeTask
            // 
            this.MenuItem_NewComputeTask.Name = "MenuItem_NewComputeTask";
            this.MenuItem_NewComputeTask.Size = new System.Drawing.Size(202, 22);
            this.MenuItem_NewComputeTask.Text = "New compute task";
            this.MenuItem_NewComputeTask.Click += new System.EventHandler(this.MenuItem_NewComputeTask_Click);
            // 
            // MenuItem_InsertNewComputeTask
            // 
            this.MenuItem_InsertNewComputeTask.Name = "MenuItem_InsertNewComputeTask";
            this.MenuItem_InsertNewComputeTask.Size = new System.Drawing.Size(202, 22);
            this.MenuItem_InsertNewComputeTask.Text = "Insert new compute task";
            this.MenuItem_InsertNewComputeTask.Click += new System.EventHandler(this.MenuItem_InsertNewComputeTask_Click);
            // 
            // MenuItem_Delete
            // 
            this.MenuItem_Delete.Name = "MenuItem_Delete";
            this.MenuItem_Delete.Size = new System.Drawing.Size(202, 22);
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
        private System.Windows.Forms.ToolStripMenuItem MenuItem_NewComputeTask;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_InsertNewComputeTask;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Delete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ButtonRunSequence;
    }
}
