namespace GIP.Controls
{
    partial class DockFormTextureList
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
            this.CtrlTextureList = new GIP.Controls.Ctrl_GlobalTextureListView();
            this.SuspendLayout();
            // 
            // CtrlTextureList
            // 
            this.CtrlTextureList.AutoSize = true;
            this.CtrlTextureList.Data = null;
            this.CtrlTextureList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlTextureList.Location = new System.Drawing.Point(0, 0);
            this.CtrlTextureList.Name = "CtrlTextureList";
            this.CtrlTextureList.Size = new System.Drawing.Size(284, 261);
            this.CtrlTextureList.TabIndex = 0;
            // 
            // DockFormTextureList
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CtrlTextureList);
            this.Name = "DockFormTextureList";
            this.Text = "TextureList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctrl_GlobalTextureListView CtrlTextureList;
    }
}
