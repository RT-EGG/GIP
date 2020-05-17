namespace GIP
{
    partial class FormMain
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_OpenFIle = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_OpenShaderFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SaveShaderFile = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelDockMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1306, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MenuItem_File
            // 
            this.MenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_OpenFIle,
            this.MenuItem_SaveFile});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(37, 20);
            this.MenuItem_File.Text = "File";
            // 
            // MenuItem_OpenFIle
            // 
            this.MenuItem_OpenFIle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_OpenShaderFile});
            this.MenuItem_OpenFIle.Name = "MenuItem_OpenFIle";
            this.MenuItem_OpenFIle.Size = new System.Drawing.Size(103, 22);
            this.MenuItem_OpenFIle.Text = "Open";
            // 
            // MenuItem_OpenShaderFile
            // 
            this.MenuItem_OpenShaderFile.Name = "MenuItem_OpenShaderFile";
            this.MenuItem_OpenShaderFile.Size = new System.Drawing.Size(138, 22);
            this.MenuItem_OpenShaderFile.Text = "Shader file...";
            this.MenuItem_OpenShaderFile.Click += new System.EventHandler(this.MenuItem_OpenShaderFile_Click);
            // 
            // MenuItem_SaveFile
            // 
            this.MenuItem_SaveFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_SaveShaderFile});
            this.MenuItem_SaveFile.Name = "MenuItem_SaveFile";
            this.MenuItem_SaveFile.Size = new System.Drawing.Size(103, 22);
            this.MenuItem_SaveFile.Text = "Save";
            // 
            // MenuItem_SaveShaderFile
            // 
            this.MenuItem_SaveShaderFile.Name = "MenuItem_SaveShaderFile";
            this.MenuItem_SaveShaderFile.Size = new System.Drawing.Size(138, 22);
            this.MenuItem_SaveShaderFile.Text = "Shader file...";
            this.MenuItem_SaveShaderFile.Click += new System.EventHandler(this.MenuItem_SaveShaderFile_Click);
            // 
            // PanelDockMain
            // 
            this.PanelDockMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDockMain.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.PanelDockMain.Location = new System.Drawing.Point(0, 24);
            this.PanelDockMain.Name = "PanelDockMain";
            this.PanelDockMain.Size = new System.Drawing.Size(1306, 524);
            this.PanelDockMain.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 548);
            this.Controls.Add(this.PanelDockMain);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FormMain";
            this.Text = "GIP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_OpenFIle;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_OpenShaderFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SaveFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SaveShaderFile;
        private WeifenLuo.WinFormsUI.Docking.DockPanel PanelDockMain;
    }
}

