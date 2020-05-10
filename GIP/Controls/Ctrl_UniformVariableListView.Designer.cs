namespace GIP.Controls
{
    partial class Ctrl_UniformVariableListView
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
            this.CtrlVariableInfoView = new GIP.Controls.Ctrl_UniformVariableInfoView();
            this.SuspendLayout();
            // 
            // CtrlVariableInfoView
            // 
            this.CtrlVariableInfoView.Data = null;
            this.CtrlVariableInfoView.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtrlVariableInfoView.Location = new System.Drawing.Point(0, 99);
            this.CtrlVariableInfoView.Name = "CtrlVariableInfoView";
            this.CtrlVariableInfoView.Size = new System.Drawing.Size(383, 73);
            this.CtrlVariableInfoView.TabIndex = 5;
            // 
            // Ctrl_UniformVariableListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CtrlVariableInfoView);
            this.Name = "Ctrl_UniformVariableListView";
            this.Size = new System.Drawing.Size(383, 372);
            this.Controls.SetChildIndex(this.CtrlVariableInfoView, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Ctrl_UniformVariableInfoView CtrlVariableInfoView;
    }
}
