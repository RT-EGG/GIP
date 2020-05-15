namespace GIP.Controls
{
    partial class DockFormCompile
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
            this.TextBoxState = new System.Windows.Forms.TextBox();
            this.ButtonCompile = new System.Windows.Forms.Button();
            this.ButtonCompileAndRun = new System.Windows.Forms.Button();
            this.PanelCompile.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelCompile
            // 
            this.PanelCompile.Controls.Add(this.ButtonCompileAndRun);
            this.PanelCompile.Controls.Add(this.ButtonCompile);
            this.PanelCompile.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelCompile.Location = new System.Drawing.Point(0, 0);
            this.PanelCompile.Name = "PanelCompile";
            this.PanelCompile.Padding = new System.Windows.Forms.Padding(3);
            this.PanelCompile.Size = new System.Drawing.Size(547, 29);
            this.PanelCompile.TabIndex = 0;
            // 
            // TextBoxState
            // 
            this.TextBoxState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxState.Location = new System.Drawing.Point(0, 29);
            this.TextBoxState.Multiline = true;
            this.TextBoxState.Name = "TextBoxState";
            this.TextBoxState.ReadOnly = true;
            this.TextBoxState.Size = new System.Drawing.Size(547, 230);
            this.TextBoxState.TabIndex = 1;
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
            // ButtonCompileAndRun
            // 
            this.ButtonCompileAndRun.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonCompileAndRun.Location = new System.Drawing.Point(78, 3);
            this.ButtonCompileAndRun.Name = "ButtonCompileAndRun";
            this.ButtonCompileAndRun.Size = new System.Drawing.Size(102, 23);
            this.ButtonCompileAndRun.TabIndex = 1;
            this.ButtonCompileAndRun.Text = "Compile and Run";
            this.ButtonCompileAndRun.UseVisualStyleBackColor = true;
            this.ButtonCompileAndRun.Click += new System.EventHandler(this.ButtonCompileAndRun_Click);
            // 
            // DockFormCompile
            // 
            this.ClientSize = new System.Drawing.Size(547, 259);
            this.Controls.Add(this.TextBoxState);
            this.Controls.Add(this.PanelCompile);
            this.Name = "DockFormCompile";
            this.Text = "Compile";
            this.PanelCompile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelCompile;
        private System.Windows.Forms.Button ButtonCompileAndRun;
        private System.Windows.Forms.Button ButtonCompile;
        private System.Windows.Forms.TextBox TextBoxState;
    }
}
