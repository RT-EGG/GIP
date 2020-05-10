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
            this.components = new System.ComponentModel.Container();
            this.PanelEditor = new System.Windows.Forms.Panel();
            this.PanelDispatchSize = new System.Windows.Forms.TableLayoutPanel();
            this.UdDispatchSizeZ = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.LabelDispatchSizeZ = new System.Windows.Forms.Label();
            this.UdDispatchSizeY = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.LabelDispatchSizeY = new System.Windows.Forms.Label();
            this.LabelDispatchSizeX = new System.Windows.Forms.Label();
            this.LabelDispatchGroupSize = new System.Windows.Forms.Label();
            this.UdDispatchSizeX = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.PanelCompile = new System.Windows.Forms.Panel();
            this.ButtonCompileAndRun = new System.Windows.Forms.Button();
            this.ButtonCompile = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.TextBoxCompileState = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_OpenFIle = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_OpenShaderFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SaveShaderFile = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.CtrlShaderVariables = new GIP.Controls.Ctrl_ShaderVariables();
            this.CtrlTextureView = new GIP.Controls.Ctrl_GLTextureView();
            this.TextBoxCode = new GIP.Controls.ComputeShaderCodeBox(this.components);
            this.PanelEditor.SuspendLayout();
            this.PanelDispatchSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeX)).BeginInit();
            this.PanelCompile.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelEditor
            // 
            this.PanelEditor.Controls.Add(this.TextBoxCode);
            this.PanelEditor.Controls.Add(this.PanelDispatchSize);
            this.PanelEditor.Controls.Add(this.PanelCompile);
            this.PanelEditor.Controls.Add(this.splitter2);
            this.PanelEditor.Controls.Add(this.TextBoxCompileState);
            this.PanelEditor.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelEditor.Location = new System.Drawing.Point(0, 24);
            this.PanelEditor.Name = "PanelEditor";
            this.PanelEditor.Padding = new System.Windows.Forms.Padding(3);
            this.PanelEditor.Size = new System.Drawing.Size(442, 524);
            this.PanelEditor.TabIndex = 0;
            // 
            // PanelDispatchSize
            // 
            this.PanelDispatchSize.ColumnCount = 7;
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelDispatchSize.Controls.Add(this.UdDispatchSizeZ, 6, 0);
            this.PanelDispatchSize.Controls.Add(this.LabelDispatchSizeZ, 5, 0);
            this.PanelDispatchSize.Controls.Add(this.UdDispatchSizeY, 4, 0);
            this.PanelDispatchSize.Controls.Add(this.LabelDispatchSizeY, 3, 0);
            this.PanelDispatchSize.Controls.Add(this.LabelDispatchSizeX, 1, 0);
            this.PanelDispatchSize.Controls.Add(this.LabelDispatchGroupSize, 0, 0);
            this.PanelDispatchSize.Controls.Add(this.UdDispatchSizeX, 2, 0);
            this.PanelDispatchSize.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDispatchSize.Location = new System.Drawing.Point(3, 370);
            this.PanelDispatchSize.Name = "PanelDispatchSize";
            this.PanelDispatchSize.RowCount = 1;
            this.PanelDispatchSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelDispatchSize.Size = new System.Drawing.Size(436, 26);
            this.PanelDispatchSize.TabIndex = 2;
            // 
            // UdDispatchSizeZ
            // 
            this.UdDispatchSizeZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UdDispatchSizeZ.Location = new System.Drawing.Point(345, 3);
            this.UdDispatchSizeZ.Name = "UdDispatchSizeZ";
            this.UdDispatchSizeZ.Size = new System.Drawing.Size(88, 19);
            this.UdDispatchSizeZ.TabIndex = 6;
            this.UdDispatchSizeZ.Tail = "";
            this.UdDispatchSizeZ.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // LabelDispatchSizeZ
            // 
            this.LabelDispatchSizeZ.AutoSize = true;
            this.LabelDispatchSizeZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelDispatchSizeZ.Location = new System.Drawing.Point(323, 0);
            this.LabelDispatchSizeZ.Name = "LabelDispatchSizeZ";
            this.LabelDispatchSizeZ.Size = new System.Drawing.Size(16, 26);
            this.LabelDispatchSizeZ.TabIndex = 5;
            this.LabelDispatchSizeZ.Text = "z :";
            this.LabelDispatchSizeZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UdDispatchSizeY
            // 
            this.UdDispatchSizeY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UdDispatchSizeY.Location = new System.Drawing.Point(229, 3);
            this.UdDispatchSizeY.Name = "UdDispatchSizeY";
            this.UdDispatchSizeY.Size = new System.Drawing.Size(88, 19);
            this.UdDispatchSizeY.TabIndex = 4;
            this.UdDispatchSizeY.Tail = "";
            this.UdDispatchSizeY.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // LabelDispatchSizeY
            // 
            this.LabelDispatchSizeY.AutoSize = true;
            this.LabelDispatchSizeY.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelDispatchSizeY.Location = new System.Drawing.Point(206, 0);
            this.LabelDispatchSizeY.Name = "LabelDispatchSizeY";
            this.LabelDispatchSizeY.Size = new System.Drawing.Size(17, 26);
            this.LabelDispatchSizeY.TabIndex = 3;
            this.LabelDispatchSizeY.Text = "y :";
            this.LabelDispatchSizeY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelDispatchSizeX
            // 
            this.LabelDispatchSizeX.AutoSize = true;
            this.LabelDispatchSizeX.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelDispatchSizeX.Location = new System.Drawing.Point(89, 0);
            this.LabelDispatchSizeX.Name = "LabelDispatchSizeX";
            this.LabelDispatchSizeX.Size = new System.Drawing.Size(17, 26);
            this.LabelDispatchSizeX.TabIndex = 1;
            this.LabelDispatchSizeX.Text = "x :";
            this.LabelDispatchSizeX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelDispatchGroupSize
            // 
            this.LabelDispatchGroupSize.AutoSize = true;
            this.LabelDispatchGroupSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelDispatchGroupSize.Location = new System.Drawing.Point(3, 0);
            this.LabelDispatchGroupSize.Name = "LabelDispatchGroupSize";
            this.LabelDispatchGroupSize.Size = new System.Drawing.Size(80, 26);
            this.LabelDispatchGroupSize.TabIndex = 0;
            this.LabelDispatchGroupSize.Text = "Dispatch size :";
            this.LabelDispatchGroupSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UdDispatchSizeX
            // 
            this.UdDispatchSizeX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UdDispatchSizeX.Location = new System.Drawing.Point(112, 3);
            this.UdDispatchSizeX.Name = "UdDispatchSizeX";
            this.UdDispatchSizeX.Size = new System.Drawing.Size(88, 19);
            this.UdDispatchSizeX.TabIndex = 2;
            this.UdDispatchSizeX.Tail = "";
            this.UdDispatchSizeX.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // PanelCompile
            // 
            this.PanelCompile.Controls.Add(this.ButtonCompileAndRun);
            this.PanelCompile.Controls.Add(this.ButtonCompile);
            this.PanelCompile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelCompile.Location = new System.Drawing.Point(3, 396);
            this.PanelCompile.Name = "PanelCompile";
            this.PanelCompile.Padding = new System.Windows.Forms.Padding(3);
            this.PanelCompile.Size = new System.Drawing.Size(436, 27);
            this.PanelCompile.TabIndex = 3;
            // 
            // ButtonCompileAndRun
            // 
            this.ButtonCompileAndRun.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonCompileAndRun.Location = new System.Drawing.Point(78, 3);
            this.ButtonCompileAndRun.Name = "ButtonCompileAndRun";
            this.ButtonCompileAndRun.Size = new System.Drawing.Size(106, 21);
            this.ButtonCompileAndRun.TabIndex = 1;
            this.ButtonCompileAndRun.Text = "Compile and Run";
            this.ButtonCompileAndRun.UseVisualStyleBackColor = true;
            this.ButtonCompileAndRun.Click += new System.EventHandler(this.ButtonCompileAndRun_Click);
            // 
            // ButtonCompile
            // 
            this.ButtonCompile.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonCompile.Location = new System.Drawing.Point(3, 3);
            this.ButtonCompile.Name = "ButtonCompile";
            this.ButtonCompile.Size = new System.Drawing.Size(75, 21);
            this.ButtonCompile.TabIndex = 0;
            this.ButtonCompile.Text = "Compile";
            this.ButtonCompile.UseVisualStyleBackColor = true;
            this.ButtonCompile.Click += new System.EventHandler(this.ButtonCompile_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(3, 423);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(436, 3);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // TextBoxCompileState
            // 
            this.TextBoxCompileState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextBoxCompileState.Location = new System.Drawing.Point(3, 426);
            this.TextBoxCompileState.Multiline = true;
            this.TextBoxCompileState.Name = "TextBoxCompileState";
            this.TextBoxCompileState.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxCompileState.Size = new System.Drawing.Size(436, 95);
            this.TextBoxCompileState.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Location = new System.Drawing.Point(442, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 524);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
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
            // splitter3
            // 
            this.splitter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter3.Location = new System.Drawing.Point(696, 24);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(6, 524);
            this.splitter3.TabIndex = 2;
            this.splitter3.TabStop = false;
            // 
            // CtrlShaderVariables
            // 
            this.CtrlShaderVariables.Dock = System.Windows.Forms.DockStyle.Left;
            this.CtrlShaderVariables.Location = new System.Drawing.Point(448, 24);
            this.CtrlShaderVariables.Name = "CtrlShaderVariables";
            this.CtrlShaderVariables.Size = new System.Drawing.Size(248, 524);
            this.CtrlShaderVariables.TabIndex = 1;
            // 
            // CtrlTextureView
            // 
            this.CtrlTextureView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlTextureView.Location = new System.Drawing.Point(702, 24);
            this.CtrlTextureView.Name = "CtrlTextureView";
            this.CtrlTextureView.Resources = null;
            this.CtrlTextureView.Size = new System.Drawing.Size(604, 524);
            this.CtrlTextureView.TabIndex = 3;
            // 
            // TextBoxCode
            // 
            this.TextBoxCode.AcceptsTab = true;
            this.TextBoxCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxCode.Location = new System.Drawing.Point(3, 3);
            this.TextBoxCode.Multiline = true;
            this.TextBoxCode.Name = "TextBoxCode";
            this.TextBoxCode.Size = new System.Drawing.Size(436, 367);
            this.TextBoxCode.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 548);
            this.Controls.Add(this.CtrlTextureView);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.CtrlShaderVariables);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.PanelEditor);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FormMain";
            this.Text = "GIP";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.PanelEditor.ResumeLayout(false);
            this.PanelEditor.PerformLayout();
            this.PanelDispatchSize.ResumeLayout(false);
            this.PanelDispatchSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeX)).EndInit();
            this.PanelCompile.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelEditor;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TextBox TextBoxCompileState;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel PanelCompile;
        private System.Windows.Forms.Button ButtonCompile;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_OpenFIle;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_OpenShaderFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SaveFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SaveShaderFile;
        private Controls.Ctrl_ShaderVariables CtrlShaderVariables;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Button ButtonCompileAndRun;
        private System.Windows.Forms.TableLayoutPanel PanelDispatchSize;
        private rtUtility.rtControl.CustomNumericUpDown UdDispatchSizeZ;
        private System.Windows.Forms.Label LabelDispatchSizeZ;
        private rtUtility.rtControl.CustomNumericUpDown UdDispatchSizeY;
        private System.Windows.Forms.Label LabelDispatchSizeY;
        private System.Windows.Forms.Label LabelDispatchSizeX;
        private System.Windows.Forms.Label LabelDispatchGroupSize;
        private rtUtility.rtControl.CustomNumericUpDown UdDispatchSizeX;
        private Controls.Ctrl_GLTextureView CtrlTextureView;
        private Controls.ComputeShaderCodeBox TextBoxCode;
    }
}

