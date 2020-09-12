namespace GIP.Controls.ProcessTaskEditor
{
    partial class Ctrl_TextureExportTaskEditor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelTexture = new System.Windows.Forms.Label();
            this.LabelFilePath = new System.Windows.Forms.Label();
            this.ButtonChooseFilePath = new System.Windows.Forms.Button();
            this.ComboTexture = new System.Windows.Forms.ComboBox();
            this.CheckOverwriteExistFile = new System.Windows.Forms.CheckBox();
            this.TextBoxFilePath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Controls.Add(this.LabelTexture, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelFilePath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonChooseFilePath, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ComboTexture, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.CheckOverwriteExistFile, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxFilePath, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 73);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // LabelTexture
            // 
            this.LabelTexture.AutoSize = true;
            this.LabelTexture.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelTexture.Location = new System.Drawing.Point(3, 24);
            this.LabelTexture.Name = "LabelTexture";
            this.LabelTexture.Size = new System.Drawing.Size(50, 24);
            this.LabelTexture.TabIndex = 3;
            this.LabelTexture.Text = "Texture :";
            this.LabelTexture.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelFilePath
            // 
            this.LabelFilePath.AutoSize = true;
            this.LabelFilePath.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelFilePath.Location = new System.Drawing.Point(19, 0);
            this.LabelFilePath.Name = "LabelFilePath";
            this.LabelFilePath.Size = new System.Drawing.Size(34, 24);
            this.LabelFilePath.TabIndex = 0;
            this.LabelFilePath.Text = "Path :";
            this.LabelFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ButtonChooseFilePath
            // 
            this.ButtonChooseFilePath.Location = new System.Drawing.Point(364, 3);
            this.ButtonChooseFilePath.Name = "ButtonChooseFilePath";
            this.ButtonChooseFilePath.Size = new System.Drawing.Size(22, 18);
            this.ButtonChooseFilePath.TabIndex = 2;
            this.ButtonChooseFilePath.Text = "...";
            this.ButtonChooseFilePath.UseVisualStyleBackColor = true;
            this.ButtonChooseFilePath.Click += new System.EventHandler(this.ButtonChooseFilePath_Click);
            // 
            // ComboTexture
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ComboTexture, 2);
            this.ComboTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboTexture.FormattingEnabled = true;
            this.ComboTexture.Location = new System.Drawing.Point(59, 27);
            this.ComboTexture.Name = "ComboTexture";
            this.ComboTexture.Size = new System.Drawing.Size(327, 20);
            this.ComboTexture.TabIndex = 4;
            this.ComboTexture.SelectionChangeCommitted += new System.EventHandler(this.ComboTexture_SelectionChangeCommitted);
            // 
            // CheckOverwriteExistFile
            // 
            this.CheckOverwriteExistFile.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.CheckOverwriteExistFile, 3);
            this.CheckOverwriteExistFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckOverwriteExistFile.Location = new System.Drawing.Point(3, 51);
            this.CheckOverwriteExistFile.Name = "CheckOverwriteExistFile";
            this.CheckOverwriteExistFile.Size = new System.Drawing.Size(383, 19);
            this.CheckOverwriteExistFile.TabIndex = 5;
            this.CheckOverwriteExistFile.Text = "Overwrite if exists already";
            this.CheckOverwriteExistFile.UseVisualStyleBackColor = true;
            this.CheckOverwriteExistFile.CheckedChanged += new System.EventHandler(this.CheckOverwriteExistFile_CheckedChanged);
            // 
            // TextBoxFilePath
            // 
            this.TextBoxFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxFilePath.Location = new System.Drawing.Point(59, 3);
            this.TextBoxFilePath.Name = "TextBoxFilePath";
            this.TextBoxFilePath.Size = new System.Drawing.Size(299, 19);
            this.TextBoxFilePath.TabIndex = 6;
            this.TextBoxFilePath.TextChanged += new System.EventHandler(this.TextBoxFilePath_TextChanged);
            // 
            // Ctrl_TextureExportTaskEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Ctrl_TextureExportTaskEditor";
            this.Size = new System.Drawing.Size(395, 106);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabelTexture;
        private System.Windows.Forms.Label LabelFilePath;
        private System.Windows.Forms.Button ButtonChooseFilePath;
        private System.Windows.Forms.ComboBox ComboTexture;
        private System.Windows.Forms.CheckBox CheckOverwriteExistFile;
        private System.Windows.Forms.TextBox TextBoxFilePath;
    }
}
