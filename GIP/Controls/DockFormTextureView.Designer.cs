namespace GIP.Controls
{
    partial class DockFormTextureView
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
            this.CtrlTextureView = new GIP.Controls.Ctrl_GLTextureView();
            this.SuspendLayout();
            // 
            // CtrlTextureView
            // 
            this.CtrlTextureView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlTextureView.Location = new System.Drawing.Point(0, 0);
            this.CtrlTextureView.Name = "CtrlTextureView";
            this.CtrlTextureView.Size = new System.Drawing.Size(548, 530);
            this.CtrlTextureView.TabIndex = 0;
            // 
            // DockFormTextureView
            // 
            this.ClientSize = new System.Drawing.Size(548, 530);
            this.Controls.Add(this.CtrlTextureView);
            this.Name = "DockFormTextureView";
            this.Text = "TxtureView";
            this.ResumeLayout(false);

        }

        #endregion

        private Ctrl_GLTextureView CtrlTextureView;
    }
}
