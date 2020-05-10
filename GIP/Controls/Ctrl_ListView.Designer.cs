namespace GIP.Controls
{
    partial class Ctrl_ListView
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ListViewItems = new System.Windows.Forms.ListView();
            this.PanelList = new System.Windows.Forms.Panel();
            this.PanelButtons.SuspendLayout();
            this.PanelList.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelButtons
            // 
            this.PanelButtons.Controls.Add(this.ButtonDown);
            this.PanelButtons.Controls.Add(this.ButtonUp);
            this.PanelButtons.Controls.Add(this.ButtonRemove);
            this.PanelButtons.Controls.Add(this.ButtonAdd);
            this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelButtons.Location = new System.Drawing.Point(0, 0);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Padding = new System.Windows.Forms.Padding(3);
            this.PanelButtons.Size = new System.Drawing.Size(30, 99);
            this.PanelButtons.TabIndex = 1;
            // 
            // ButtonDown
            // 
            this.ButtonDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonDown.Location = new System.Drawing.Point(3, 72);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(24, 23);
            this.ButtonDown.TabIndex = 3;
            this.ButtonDown.Text = "▼";
            this.ButtonDown.UseVisualStyleBackColor = true;
            this.ButtonDown.Visible = false;
            // 
            // ButtonUp
            // 
            this.ButtonUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonUp.Location = new System.Drawing.Point(3, 49);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(24, 23);
            this.ButtonUp.TabIndex = 2;
            this.ButtonUp.Text = "▲";
            this.ButtonUp.UseVisualStyleBackColor = true;
            this.ButtonUp.Visible = false;
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonRemove.Location = new System.Drawing.Point(3, 26);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(24, 23);
            this.ButtonRemove.TabIndex = 1;
            this.ButtonRemove.Text = "✖";
            this.ButtonRemove.UseVisualStyleBackColor = true;
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonAdd.Location = new System.Drawing.Point(3, 3);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(24, 23);
            this.ButtonAdd.TabIndex = 0;
            this.ButtonAdd.Text = "➕";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ListViewItems
            // 
            this.ListViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewItems.FullRowSelect = true;
            this.ListViewItems.HideSelection = false;
            this.ListViewItems.Location = new System.Drawing.Point(30, 0);
            this.ListViewItems.Name = "ListViewItems";
            this.ListViewItems.Size = new System.Drawing.Size(353, 99);
            this.ListViewItems.TabIndex = 3;
            this.ListViewItems.UseCompatibleStateImageBehavior = false;
            this.ListViewItems.View = System.Windows.Forms.View.Details;
            this.ListViewItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewItems_ItemSelectionChanged);
            // 
            // PanelList
            // 
            this.PanelList.Controls.Add(this.ListViewItems);
            this.PanelList.Controls.Add(this.PanelButtons);
            this.PanelList.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelList.Location = new System.Drawing.Point(0, 0);
            this.PanelList.Name = "PanelList";
            this.PanelList.Size = new System.Drawing.Size(383, 99);
            this.PanelList.TabIndex = 4;
            // 
            // Ctrl_ListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelList);
            this.Name = "Ctrl_ListView";
            this.Size = new System.Drawing.Size(383, 101);
            this.PanelButtons.ResumeLayout(false);
            this.PanelList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelButtons;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.ListView ListViewItems;
        private System.Windows.Forms.Panel PanelList;
    }
}
