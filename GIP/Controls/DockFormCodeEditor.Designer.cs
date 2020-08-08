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
            this.components = new System.ComponentModel.Container();
            this.TextBoxCodeEditor = new GIP.Controls.ComputeShaderCodeBox(this.components);
            this.PanelCompile = new System.Windows.Forms.Panel();
            this.ButtonCompile = new System.Windows.Forms.Button();
            this.PanelCompile.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxCodeEditor
            // 
            this.TextBoxCodeEditor.AcceptsTab = true;
            this.TextBoxCodeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxCodeEditor.Location = new System.Drawing.Point(0, 0);
            this.TextBoxCodeEditor.Multiline = true;
            this.TextBoxCodeEditor.Name = "TextBoxCodeEditor";
            this.TextBoxCodeEditor.Size = new System.Drawing.Size(328, 266);
            this.TextBoxCodeEditor.TabIndex = 0;
            this.TextBoxCodeEditor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxCodeEditor_KeyUp);
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
            // DockFormCodeEditor
            // 
            this.ClientSize = new System.Drawing.Size(328, 295);
            this.Controls.Add(this.TextBoxCodeEditor);
            this.Controls.Add(this.PanelCompile);
            this.Name = "DockFormCodeEditor";
            this.Text = "CodeEditor";
            this.PanelCompile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComputeShaderCodeBox TextBoxCodeEditor;
        private System.Windows.Forms.Panel PanelCompile;
        private System.Windows.Forms.Button ButtonCompile;
    }
}
