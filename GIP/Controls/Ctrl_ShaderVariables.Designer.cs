namespace GIP.Controls
{
    partial class Ctrl_ShaderVariables
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
            this.LabelUniformVariables = new System.Windows.Forms.Label();
            this.LabelGlobalTextures = new System.Windows.Forms.Label();
            this.CtrlUniformVariableListView = new GIP.Controls.Ctrl_UniformVariableListView();
            this.CtrlGlobalTextureListView = new GIP.Controls.Ctrl_GlobalTextureListView();
            this.SuspendLayout();
            // 
            // LabelUniformVariables
            // 
            this.LabelUniformVariables.AutoSize = true;
            this.LabelUniformVariables.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelUniformVariables.Location = new System.Drawing.Point(0, 246);
            this.LabelUniformVariables.Name = "LabelUniformVariables";
            this.LabelUniformVariables.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.LabelUniformVariables.Size = new System.Drawing.Size(95, 18);
            this.LabelUniformVariables.TabIndex = 6;
            this.LabelUniformVariables.Text = "Uniform variables";
            // 
            // LabelGlobalTextures
            // 
            this.LabelGlobalTextures.AutoSize = true;
            this.LabelGlobalTextures.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelGlobalTextures.Location = new System.Drawing.Point(0, 0);
            this.LabelGlobalTextures.Name = "LabelGlobalTextures";
            this.LabelGlobalTextures.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.LabelGlobalTextures.Size = new System.Drawing.Size(89, 18);
            this.LabelGlobalTextures.TabIndex = 8;
            this.LabelGlobalTextures.Text = "Global textures :";
            // 
            // CtrlUniformVariableListView
            // 
            this.CtrlUniformVariableListView.AutoSize = true;
            this.CtrlUniformVariableListView.Data = null;
            this.CtrlUniformVariableListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtrlUniformVariableListView.Location = new System.Drawing.Point(0, 264);
            this.CtrlUniformVariableListView.Name = "CtrlUniformVariableListView";
            this.CtrlUniformVariableListView.Resources = null;
            this.CtrlUniformVariableListView.Size = new System.Drawing.Size(350, 172);
            this.CtrlUniformVariableListView.TabIndex = 9;
            // 
            // CtrlGlobalTextureListView
            // 
            this.CtrlGlobalTextureListView.AutoSize = true;
            this.CtrlGlobalTextureListView.Data = null;
            this.CtrlGlobalTextureListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.CtrlGlobalTextureListView.Location = new System.Drawing.Point(0, 18);
            this.CtrlGlobalTextureListView.Name = "CtrlGlobalTextureListView";
            this.CtrlGlobalTextureListView.Size = new System.Drawing.Size(350, 228);
            this.CtrlGlobalTextureListView.TabIndex = 7;
            // 
            // Ctrl_ShaderVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CtrlUniformVariableListView);
            this.Controls.Add(this.LabelUniformVariables);
            this.Controls.Add(this.CtrlGlobalTextureListView);
            this.Controls.Add(this.LabelGlobalTextures);
            this.Name = "Ctrl_ShaderVariables";
            this.Size = new System.Drawing.Size(350, 480);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelUniformVariables;
        private Ctrl_GlobalTextureListView CtrlGlobalTextureListView;
        private System.Windows.Forms.Label LabelGlobalTextures;
        private Ctrl_UniformVariableListView CtrlUniformVariableListView;
    }
}
