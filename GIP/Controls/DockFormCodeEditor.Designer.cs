namespace GIP.Controls
{
    partial class DockFormCodeEditor
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
            this.PanelCompile = new System.Windows.Forms.Panel();
            this.ButtonCompile = new System.Windows.Forms.Button();
            this.CodeEditor = new GIP.Controls.Ctrl_ComputeShaderCodeEditor();
            this.PanelCompile.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelCompile
            // 
            this.PanelCompile.Controls.Add(this.ButtonCompile);
            this.PanelCompile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelCompile.Location = new System.Drawing.Point(0, 266);
            this.PanelCompile.Name = "PanelCompile";
            this.PanelCompile.Padding = new System.Windows.Forms.Padding(3);
            this.PanelCompile.Size = new System.Drawing.Size(328, 29);
            this.PanelCompile.TabIndex = 1;
            // 
            // ButtonCompile
            // 
            this.ButtonCompile.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonCompile.Location = new System.Drawing.Point(3, 3);
            this.ButtonCompile.Name = "ButtonCompile";
            this.ButtonCompile.Size = new System.Drawing.Size(75, 23);
            this.ButtonCompile.TabIndex = 0;
            this.ButtonCompile.Text = "Compile";
            this.ButtonCompile.UseVisualStyleBackColor = true;
            this.ButtonCompile.Click += new System.EventHandler(this.ButtonCompile_Click);
            // 
            // CodeEditor
            // 
            this.CodeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeEditor.Location = new System.Drawing.Point(0, 0);
            this.CodeEditor.Name = "CodeEditor";
            this.CodeEditor.Size = new System.Drawing.Size(328, 266);
            this.CodeEditor.TabIndex = 2;
            // 
            // DockFormCodeEditor
            // 
            this.ClientSize = new System.Drawing.Size(328, 295);
            this.Controls.Add(this.CodeEditor);
            this.Controls.Add(this.PanelCompile);
            this.Name = "DockFormCodeEditor";
            this.Text = "CodeEditor";
            this.PanelCompile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelCompile;
        private System.Windows.Forms.Button ButtonCompile;
        private Ctrl_ComputeShaderCodeEditor CodeEditor;
    }
}
