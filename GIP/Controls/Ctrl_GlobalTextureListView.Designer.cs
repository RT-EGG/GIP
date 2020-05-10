namespace GIP.Controls
{
    partial class Ctrl_GlobalTextureListView
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
            this.CtrlTextureInfoView = new GIP.Controls.Ctrl_TextureInfoView();
            this.SuspendLayout();
            // 
            // CtrlTextureInfoView
            // 
            this.CtrlTextureInfoView.AutoSize = true;
            this.CtrlTextureInfoView.Data = null;
            this.CtrlTextureInfoView.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtrlTextureInfoView.Location = new System.Drawing.Point(0, 99);
            this.CtrlTextureInfoView.Name = "CtrlTextureInfoView";
            this.CtrlTextureInfoView.Size = new System.Drawing.Size(469, 129);
            this.CtrlTextureInfoView.TabIndex = 6;
            // 
            // Ctrl_GlobalTextureListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.CtrlTextureInfoView);
            this.Name = "Ctrl_GlobalTextureListView";
            this.Size = new System.Drawing.Size(469, 245);
            this.Controls.SetChildIndex(this.CtrlTextureInfoView, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Ctrl_TextureInfoView CtrlTextureInfoView;
    }
}
