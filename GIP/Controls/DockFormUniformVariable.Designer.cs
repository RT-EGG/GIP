namespace GIP.Controls
{
    partial class DockFormUniformVariable
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
            this.CtrlUniformVariableListView = new GIP.Controls.Ctrl_UniformVariableListView();
            this.SuspendLayout();
            // 
            // CtrlUniformVariableListView
            // 
            this.CtrlUniformVariableListView.Data = null;
            this.CtrlUniformVariableListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlUniformVariableListView.Location = new System.Drawing.Point(0, 0);
            this.CtrlUniformVariableListView.Name = "CtrlUniformVariableListView";
            this.CtrlUniformVariableListView.Resources = null;
            this.CtrlUniformVariableListView.Size = new System.Drawing.Size(284, 261);
            this.CtrlUniformVariableListView.TabIndex = 0;
            // 
            // DockFormUniformVariable
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CtrlUniformVariableListView);
            this.Name = "DockFormUniformVariable";
            this.Text = "UniformVariables";
            this.ResumeLayout(false);

        }

        #endregion

        private Ctrl_UniformVariableListView CtrlUniformVariableListView;
    }
}
