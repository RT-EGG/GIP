namespace GIP.Controls
{
    partial class Ctrl_ComputeShaderCodeEditor
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
            this.EditorHost = new System.Windows.Forms.Integration.ElementHost();
            this.avalonTextEditor1 = new GIP.Controls.AvalonTextEditor();
            this.SuspendLayout();
            // 
            // EditorHost
            // 
            this.EditorHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditorHost.Location = new System.Drawing.Point(0, 0);
            this.EditorHost.Name = "EditorHost";
            this.EditorHost.Size = new System.Drawing.Size(439, 345);
            this.EditorHost.TabIndex = 0;
            this.EditorHost.Text = "elementHost1";
            this.EditorHost.Child = this.avalonTextEditor1;
            // 
            // Ctrl_ComputeShaderCodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EditorHost);
            this.Name = "Ctrl_ComputeShaderCodeEditor";
            this.Size = new System.Drawing.Size(439, 345);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost EditorHost;
        private AvalonTextEditor avalonTextEditor1;
    }
}
