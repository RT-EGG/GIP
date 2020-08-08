namespace GIP.Controls
{
    partial class DockFormConsole
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
            this.TextBoxState = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBoxState
            // 
            this.TextBoxState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxState.Location = new System.Drawing.Point(0, 0);
            this.TextBoxState.Multiline = true;
            this.TextBoxState.Name = "TextBoxState";
            this.TextBoxState.ReadOnly = true;
            this.TextBoxState.Size = new System.Drawing.Size(547, 259);
            this.TextBoxState.TabIndex = 1;
            // 
            // DockFormConsole
            // 
            this.ClientSize = new System.Drawing.Size(547, 259);
            this.Controls.Add(this.TextBoxState);
            this.Name = "DockFormConsole";
            this.Text = "Console";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextBoxState;
    }
}
