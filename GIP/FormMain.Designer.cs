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
            this.MenuItem_NewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Save_Project = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Save_CurrentShaderFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_View = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ProjectFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Code = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_TaskEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_TaskSequence = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Compile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_VariableList = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_UniformVariables = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_TextureView = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelDockMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.MenuItem_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Open_Project = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File,
            this.MenuItem_View});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1306, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MenuItem_File
            // 
            this.MenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_NewProject,
            this.MenuItem_OpenFile,
            this.MenuItem_SaveFile});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(37, 20);
            this.MenuItem_File.Text = "File";
            // 
            // MenuItem_NewProject
            // 
            this.MenuItem_NewProject.Name = "MenuItem_NewProject";
            this.MenuItem_NewProject.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_NewProject.Text = "New project";
            this.MenuItem_NewProject.Click += new System.EventHandler(this.MenuItem_NewProject_Click);
            // 
            // MenuItem_SaveFile
            // 
            this.MenuItem_SaveFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Save_Project,
            this.MenuItem_Save_CurrentShaderFile});
            this.MenuItem_SaveFile.Name = "MenuItem_SaveFile";
            this.MenuItem_SaveFile.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_SaveFile.Text = "Save";
            // 
            // MenuItem_Save_Project
            // 
            this.MenuItem_Save_Project.Name = "MenuItem_Save_Project";
            this.MenuItem_Save_Project.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.MenuItem_Save_Project.Size = new System.Drawing.Size(218, 22);
            this.MenuItem_Save_Project.Text = "Project";
            this.MenuItem_Save_Project.Click += new System.EventHandler(this.MenuItem_Save_Project_Click);
            // 
            // MenuItem_Save_CurrentShaderFile
            // 
            this.MenuItem_Save_CurrentShaderFile.Name = "MenuItem_Save_CurrentShaderFile";
            this.MenuItem_Save_CurrentShaderFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItem_Save_CurrentShaderFile.Size = new System.Drawing.Size(218, 22);
            this.MenuItem_Save_CurrentShaderFile.Text = "Current shader file...";
            this.MenuItem_Save_CurrentShaderFile.Click += new System.EventHandler(this.MenuItem_SaveShaderFile_Click);
            // 
            // MenuItem_View
            // 
            this.MenuItem_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_ProjectFiles,
            this.MenuItem_Code,
            this.MenuItem_TaskEditor,
            this.MenuItem_TaskSequence,
            this.MenuItem_Compile,
            this.MenuItem_VariableList,
            this.MenuItem_UniformVariables,
            this.MenuItem_TextureView});
            this.MenuItem_View.Name = "MenuItem_View";
            this.MenuItem_View.Size = new System.Drawing.Size(44, 20);
            this.MenuItem_View.Text = "View";
            // 
            // MenuItem_ProjectFiles
            // 
            this.MenuItem_ProjectFiles.Name = "MenuItem_ProjectFiles";
            this.MenuItem_ProjectFiles.Size = new System.Drawing.Size(163, 22);
            this.MenuItem_ProjectFiles.Text = "Files";
            this.MenuItem_ProjectFiles.Click += new System.EventHandler(this.MenuItem_ShowWindow_Click);
            // 
            // MenuItem_Code
            // 
            this.MenuItem_Code.Name = "MenuItem_Code";
            this.MenuItem_Code.Size = new System.Drawing.Size(163, 22);
            this.MenuItem_Code.Text = "Code";
            this.MenuItem_Code.Click += new System.EventHandler(this.MenuItem_ShowWindow_Click);
            // 
            // MenuItem_TaskEditor
            // 
            this.MenuItem_TaskEditor.Name = "MenuItem_TaskEditor";
            this.MenuItem_TaskEditor.Size = new System.Drawing.Size(163, 22);
            this.MenuItem_TaskEditor.Text = "TaskEditor";
            this.MenuItem_TaskEditor.Click += new System.EventHandler(this.MenuItem_ShowWindow_Click);
            // 
            // MenuItem_TaskSequence
            // 
            this.MenuItem_TaskSequence.Name = "MenuItem_TaskSequence";
            this.MenuItem_TaskSequence.Size = new System.Drawing.Size(163, 22);
            this.MenuItem_TaskSequence.Text = "TaskSequence";
            this.MenuItem_TaskSequence.Click += new System.EventHandler(this.MenuItem_ShowWindow_Click);
            // 
            // MenuItem_Compile
            // 
            this.MenuItem_Compile.Name = "MenuItem_Compile";
            this.MenuItem_Compile.Size = new System.Drawing.Size(163, 22);
            this.MenuItem_Compile.Text = "Compile";
            this.MenuItem_Compile.Click += new System.EventHandler(this.MenuItem_ShowWindow_Click);
            // 
            // MenuItem_VariableList
            // 
            this.MenuItem_VariableList.Name = "MenuItem_VariableList";
            this.MenuItem_VariableList.Size = new System.Drawing.Size(163, 22);
            this.MenuItem_VariableList.Text = "Variable list";
            this.MenuItem_VariableList.Click += new System.EventHandler(this.MenuItem_ShowWindow_Click);
            // 
            // MenuItem_UniformVariables
            // 
            this.MenuItem_UniformVariables.Name = "MenuItem_UniformVariables";
            this.MenuItem_UniformVariables.Size = new System.Drawing.Size(163, 22);
            this.MenuItem_UniformVariables.Text = "UniformVariables";
            this.MenuItem_UniformVariables.Click += new System.EventHandler(this.MenuItem_ShowWindow_Click);
            // 
            // MenuItem_TextureView
            // 
            this.MenuItem_TextureView.Name = "MenuItem_TextureView";
            this.MenuItem_TextureView.Size = new System.Drawing.Size(163, 22);
            this.MenuItem_TextureView.Text = "TextureView";
            this.MenuItem_TextureView.Click += new System.EventHandler(this.MenuItem_ShowWindow_Click);
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
            // MenuItem_OpenFile
            // 
            this.MenuItem_OpenFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Open_Project});
            this.MenuItem_OpenFile.Name = "MenuItem_OpenFile";
            this.MenuItem_OpenFile.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_OpenFile.Text = "Open";
            // 
            // MenuItem_Open_Project
            // 
            this.MenuItem_Open_Project.Name = "MenuItem_Open_Project";
            this.MenuItem_Open_Project.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_Open_Project.Text = "Project";
            this.MenuItem_Open_Project.Click += new System.EventHandler(this.MenuItem_Open_Project_Click);
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
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SaveFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Save_CurrentShaderFile;
        private WeifenLuo.WinFormsUI.Docking.DockPanel PanelDockMain;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_View;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Code;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Compile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_VariableList;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_UniformVariables;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_TextureView;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_NewProject;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ProjectFiles;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_TaskEditor;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_TaskSequence;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Save_Project;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_OpenFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Open_Project;
    }
}

