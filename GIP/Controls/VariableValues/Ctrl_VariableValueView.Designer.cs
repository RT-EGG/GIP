namespace GIP.Controls.VariableValues
{
    partial class Ctrl_VariableValueView
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
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBoxName
            // 
            this.TextBoxName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBoxName.Location = new System.Drawing.Point(3, 3);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(473, 19);
            this.TextBoxName.TabIndex = 0;
            this.TextBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // Ctrl_VariableValueView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxName);
            this.Name = "Ctrl_VariableValueView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(479, 119);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxName;
    }
}
