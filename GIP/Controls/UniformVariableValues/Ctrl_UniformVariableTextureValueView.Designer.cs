namespace GIP.Controls.UniformVariableValues
{
    partial class Ctrl_UniformVariableTextureValueView
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
            this.PanelProperties = new System.Windows.Forms.TableLayoutPanel();
            this.LabelInternalFormat = new System.Windows.Forms.Label();
            this.ComboInternalFormat = new System.Windows.Forms.ComboBox();
            this.ComboTextureAccess = new System.Windows.Forms.ComboBox();
            this.LabelAccess = new System.Windows.Forms.Label();
            this.LabelTexture = new System.Windows.Forms.Label();
            this.ComboTexture = new System.Windows.Forms.ComboBox();
            this.PanelProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelProperties
            // 
            this.PanelProperties.ColumnCount = 2;
            this.PanelProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelProperties.Controls.Add(this.LabelInternalFormat, 0, 2);
            this.PanelProperties.Controls.Add(this.ComboInternalFormat, 0, 2);
            this.PanelProperties.Controls.Add(this.ComboTextureAccess, 1, 1);
            this.PanelProperties.Controls.Add(this.LabelAccess, 0, 1);
            this.PanelProperties.Controls.Add(this.LabelTexture, 0, 0);
            this.PanelProperties.Controls.Add(this.ComboTexture, 1, 0);
            this.PanelProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelProperties.Location = new System.Drawing.Point(0, 0);
            this.PanelProperties.Name = "PanelProperties";
            this.PanelProperties.RowCount = 3;
            this.PanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelProperties.Size = new System.Drawing.Size(388, 78);
            this.PanelProperties.TabIndex = 0;
            // 
            // LabelInternalFormat
            // 
            this.LabelInternalFormat.AutoSize = true;
            this.LabelInternalFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelInternalFormat.Location = new System.Drawing.Point(3, 52);
            this.LabelInternalFormat.Name = "LabelInternalFormat";
            this.LabelInternalFormat.Size = new System.Drawing.Size(47, 26);
            this.LabelInternalFormat.TabIndex = 4;
            this.LabelInternalFormat.Text = "Format :";
            this.LabelInternalFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboInternalFormat
            // 
            this.ComboInternalFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboInternalFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboInternalFormat.FormattingEnabled = true;
            this.ComboInternalFormat.Location = new System.Drawing.Point(59, 55);
            this.ComboInternalFormat.Name = "ComboInternalFormat";
            this.ComboInternalFormat.Size = new System.Drawing.Size(326, 20);
            this.ComboInternalFormat.TabIndex = 5;
            this.ComboInternalFormat.SelectedValueChanged += new System.EventHandler(this.ComboInternalFormat_SelectedValueChanged);
            // 
            // ComboTextureAccess
            // 
            this.ComboTextureAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboTextureAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTextureAccess.FormattingEnabled = true;
            this.ComboTextureAccess.Location = new System.Drawing.Point(59, 29);
            this.ComboTextureAccess.Name = "ComboTextureAccess";
            this.ComboTextureAccess.Size = new System.Drawing.Size(326, 20);
            this.ComboTextureAccess.TabIndex = 3;
            this.ComboTextureAccess.SelectedValueChanged += new System.EventHandler(this.ComboTextureAccess_SelectedValueChanged);
            // 
            // LabelAccess
            // 
            this.LabelAccess.AutoSize = true;
            this.LabelAccess.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelAccess.Location = new System.Drawing.Point(3, 26);
            this.LabelAccess.Name = "LabelAccess";
            this.LabelAccess.Size = new System.Drawing.Size(49, 26);
            this.LabelAccess.TabIndex = 2;
            this.LabelAccess.Text = "Access :";
            this.LabelAccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelTexture
            // 
            this.LabelTexture.AutoSize = true;
            this.LabelTexture.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelTexture.Location = new System.Drawing.Point(3, 0);
            this.LabelTexture.Name = "LabelTexture";
            this.LabelTexture.Size = new System.Drawing.Size(50, 26);
            this.LabelTexture.TabIndex = 0;
            this.LabelTexture.Text = "Texture :";
            this.LabelTexture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboTexture
            // 
            this.ComboTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboTexture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTexture.FormattingEnabled = true;
            this.ComboTexture.Location = new System.Drawing.Point(59, 3);
            this.ComboTexture.Name = "ComboTexture";
            this.ComboTexture.Size = new System.Drawing.Size(326, 20);
            this.ComboTexture.TabIndex = 1;
            this.ComboTexture.SelectedValueChanged += new System.EventHandler(this.ComboTexture_SelectedValueChanged);
            // 
            // Ctrl_UniformVariableTextureValueView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.PanelProperties);
            this.Name = "Ctrl_UniformVariableTextureValueView";
            this.Size = new System.Drawing.Size(388, 80);
            this.PanelProperties.ResumeLayout(false);
            this.PanelProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PanelProperties;
        private System.Windows.Forms.Label LabelTexture;
        private System.Windows.Forms.ComboBox ComboTexture;
        private System.Windows.Forms.Label LabelAccess;
        private System.Windows.Forms.Label LabelInternalFormat;
        private System.Windows.Forms.ComboBox ComboInternalFormat;
        private System.Windows.Forms.ComboBox ComboTextureAccess;
    }
}
