namespace GIP.Controls
{
    partial class Ctrl_UniformVariableInfoView
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
            this.LabelType = new System.Windows.Forms.Label();
            this.LabelName = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.ComboType = new System.Windows.Forms.ComboBox();
            this.PanelVariableValueArea = new System.Windows.Forms.Panel();
            this.PanelProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelProperties
            // 
            this.PanelProperties.ColumnCount = 2;
            this.PanelProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelProperties.Controls.Add(this.LabelType, 0, 1);
            this.PanelProperties.Controls.Add(this.LabelName, 0, 0);
            this.PanelProperties.Controls.Add(this.TextBoxName, 1, 0);
            this.PanelProperties.Controls.Add(this.ComboType, 1, 1);
            this.PanelProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelProperties.Location = new System.Drawing.Point(0, 0);
            this.PanelProperties.Name = "PanelProperties";
            this.PanelProperties.RowCount = 2;
            this.PanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelProperties.Size = new System.Drawing.Size(422, 53);
            this.PanelProperties.TabIndex = 0;
            // 
            // LabelType
            // 
            this.LabelType.AutoSize = true;
            this.LabelType.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelType.Location = new System.Drawing.Point(3, 26);
            this.LabelType.Name = "LabelType";
            this.LabelType.Size = new System.Drawing.Size(36, 27);
            this.LabelType.TabIndex = 2;
            this.LabelType.Text = "Type :";
            this.LabelType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelName.Location = new System.Drawing.Point(3, 0);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(40, 26);
            this.LabelName.TabIndex = 0;
            this.LabelName.Text = "Name :";
            this.LabelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxName
            // 
            this.TextBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxName.Location = new System.Drawing.Point(49, 3);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(370, 19);
            this.TextBoxName.TabIndex = 1;
            this.TextBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // ComboType
            // 
            this.ComboType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboType.FormattingEnabled = true;
            this.ComboType.Items.AddRange(new object[] {
            "Texture"});
            this.ComboType.Location = new System.Drawing.Point(49, 29);
            this.ComboType.Name = "ComboType";
            this.ComboType.Size = new System.Drawing.Size(370, 20);
            this.ComboType.TabIndex = 3;
            this.ComboType.SelectedValueChanged += new System.EventHandler(this.ComboType_SelectedValueChanged);
            // 
            // PanelVariableValueArea
            // 
            this.PanelVariableValueArea.AutoSize = true;
            this.PanelVariableValueArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelVariableValueArea.Location = new System.Drawing.Point(0, 53);
            this.PanelVariableValueArea.Name = "PanelVariableValueArea";
            this.PanelVariableValueArea.Size = new System.Drawing.Size(422, 0);
            this.PanelVariableValueArea.TabIndex = 1;
            // 
            // Ctrl_UniformVariableInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.PanelVariableValueArea);
            this.Controls.Add(this.PanelProperties);
            this.Name = "Ctrl_UniformVariableInfoView";
            this.Size = new System.Drawing.Size(422, 205);
            this.PanelProperties.ResumeLayout(false);
            this.PanelProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PanelProperties;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label LabelType;
        private System.Windows.Forms.ComboBox ComboType;
        private System.Windows.Forms.Panel PanelVariableValueArea;
    }
}
