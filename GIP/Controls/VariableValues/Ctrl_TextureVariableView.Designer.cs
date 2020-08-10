namespace GIP.Controls.VariableValues
{
    partial class Ctrl_TextureVariableView
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
            this.components = new System.ComponentModel.Container();
            this.PanelInitializeInfo = new System.Windows.Forms.TableLayoutPanel();
            this.ComboDataType = new System.Windows.Forms.ComboBox();
            this.LabelFormat = new System.Windows.Forms.Label();
            this.ComboFormat = new System.Windows.Forms.ComboBox();
            this.LabelDataType = new System.Windows.Forms.Label();
            this.PanelSource = new System.Windows.Forms.Panel();
            this.ComboSource = new System.Windows.Forms.ComboBox();
            this.LabelSource = new System.Windows.Forms.Label();
            this.PanelSourceColorOptions = new System.Windows.Forms.Panel();
            this.PanelColorInitializeColors = new System.Windows.Forms.TableLayoutPanel();
            this.LabelColorInitializeRGB = new System.Windows.Forms.Label();
            this.UdColorInitializeAlpha = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.LabelColorInitializeAlpha = new System.Windows.Forms.Label();
            this.ButtonColorInitializeRGB = new System.Windows.Forms.Button();
            this.PanelColorInitializeDimensions = new System.Windows.Forms.TableLayoutPanel();
            this.UdColorInitializeHeight = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.LabelTextureInitializeColorHeight = new System.Windows.Forms.Label();
            this.LabelTextureInitializeColorWidth = new System.Windows.Forms.Label();
            this.UdColorInitializeWidth = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.PanelSourceFileOptions = new System.Windows.Forms.Panel();
            this.TextBoxFileInitializePath = new System.Windows.Forms.TextBox();
            this.ButtonFileInitializeChoosePath = new System.Windows.Forms.Button();
            this.LabelFileInitializeFile = new System.Windows.Forms.Label();
            this.PanelInitializeInfo.SuspendLayout();
            this.PanelSource.SuspendLayout();
            this.PanelSourceColorOptions.SuspendLayout();
            this.PanelColorInitializeColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdColorInitializeAlpha)).BeginInit();
            this.PanelColorInitializeDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdColorInitializeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdColorInitializeWidth)).BeginInit();
            this.PanelSourceFileOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelInitializeInfo
            // 
            this.PanelInitializeInfo.ColumnCount = 2;
            this.PanelInitializeInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelInitializeInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelInitializeInfo.Controls.Add(this.ComboDataType, 1, 1);
            this.PanelInitializeInfo.Controls.Add(this.LabelFormat, 0, 0);
            this.PanelInitializeInfo.Controls.Add(this.ComboFormat, 1, 0);
            this.PanelInitializeInfo.Controls.Add(this.LabelDataType, 0, 1);
            this.PanelInitializeInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelInitializeInfo.Location = new System.Drawing.Point(3, 22);
            this.PanelInitializeInfo.Name = "PanelInitializeInfo";
            this.PanelInitializeInfo.RowCount = 2;
            this.PanelInitializeInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelInitializeInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelInitializeInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelInitializeInfo.Size = new System.Drawing.Size(347, 56);
            this.PanelInitializeInfo.TabIndex = 5;
            // 
            // ComboDataType
            // 
            this.ComboDataType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboDataType.FormattingEnabled = true;
            this.ComboDataType.Items.AddRange(new object[] {
            "Unsigned byte"});
            this.ComboDataType.Location = new System.Drawing.Point(70, 31);
            this.ComboDataType.Name = "ComboDataType";
            this.ComboDataType.Size = new System.Drawing.Size(274, 20);
            this.ComboDataType.TabIndex = 3;
            this.ComboDataType.SelectedValueChanged += new System.EventHandler(this.ComboDataType_SelectedValueChanged);
            // 
            // LabelFormat
            // 
            this.LabelFormat.AutoSize = true;
            this.LabelFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelFormat.Location = new System.Drawing.Point(3, 0);
            this.LabelFormat.Name = "LabelFormat";
            this.LabelFormat.Size = new System.Drawing.Size(47, 28);
            this.LabelFormat.TabIndex = 0;
            this.LabelFormat.Text = "Format :";
            this.LabelFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboFormat
            // 
            this.ComboFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboFormat.FormattingEnabled = true;
            this.ComboFormat.Items.AddRange(new object[] {
            "RGB",
            "RGBA"});
            this.ComboFormat.Location = new System.Drawing.Point(70, 3);
            this.ComboFormat.Name = "ComboFormat";
            this.ComboFormat.Size = new System.Drawing.Size(274, 20);
            this.ComboFormat.TabIndex = 1;
            this.ComboFormat.SelectedValueChanged += new System.EventHandler(this.ComboFormat_SelectedValueChanged);
            // 
            // LabelDataType
            // 
            this.LabelDataType.AutoSize = true;
            this.LabelDataType.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelDataType.Location = new System.Drawing.Point(3, 28);
            this.LabelDataType.Name = "LabelDataType";
            this.LabelDataType.Size = new System.Drawing.Size(61, 28);
            this.LabelDataType.TabIndex = 2;
            this.LabelDataType.Text = "Data type :";
            this.LabelDataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelSource
            // 
            this.PanelSource.Controls.Add(this.ComboSource);
            this.PanelSource.Controls.Add(this.LabelSource);
            this.PanelSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSource.Location = new System.Drawing.Point(3, 78);
            this.PanelSource.Name = "PanelSource";
            this.PanelSource.Size = new System.Drawing.Size(347, 28);
            this.PanelSource.TabIndex = 6;
            // 
            // ComboSource
            // 
            this.ComboSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSource.FormattingEnabled = true;
            this.ComboSource.Items.AddRange(new object[] {
            "Clear color",
            "Image file"});
            this.ComboSource.Location = new System.Drawing.Point(61, 3);
            this.ComboSource.Name = "ComboSource";
            this.ComboSource.Size = new System.Drawing.Size(121, 20);
            this.ComboSource.TabIndex = 1;
            this.ComboSource.SelectedValueChanged += new System.EventHandler(this.ComboSource_SelectedValueChanged);
            // 
            // LabelSource
            // 
            this.LabelSource.AutoSize = true;
            this.LabelSource.Location = new System.Drawing.Point(3, 3);
            this.LabelSource.Name = "LabelSource";
            this.LabelSource.Padding = new System.Windows.Forms.Padding(3);
            this.LabelSource.Size = new System.Drawing.Size(52, 18);
            this.LabelSource.TabIndex = 0;
            this.LabelSource.Text = "Source :";
            // 
            // PanelSourceColorOptions
            // 
            this.PanelSourceColorOptions.AutoSize = true;
            this.PanelSourceColorOptions.Controls.Add(this.PanelColorInitializeColors);
            this.PanelSourceColorOptions.Controls.Add(this.PanelColorInitializeDimensions);
            this.PanelSourceColorOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSourceColorOptions.Location = new System.Drawing.Point(3, 106);
            this.PanelSourceColorOptions.Name = "PanelSourceColorOptions";
            this.PanelSourceColorOptions.Padding = new System.Windows.Forms.Padding(3);
            this.PanelSourceColorOptions.Size = new System.Drawing.Size(347, 57);
            this.PanelSourceColorOptions.TabIndex = 7;
            // 
            // PanelColorInitializeColors
            // 
            this.PanelColorInitializeColors.ColumnCount = 4;
            this.PanelColorInitializeColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelColorInitializeColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.PanelColorInitializeColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelColorInitializeColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.PanelColorInitializeColors.Controls.Add(this.LabelColorInitializeRGB, 0, 0);
            this.PanelColorInitializeColors.Controls.Add(this.UdColorInitializeAlpha, 3, 0);
            this.PanelColorInitializeColors.Controls.Add(this.LabelColorInitializeAlpha, 2, 0);
            this.PanelColorInitializeColors.Controls.Add(this.ButtonColorInitializeRGB, 1, 0);
            this.PanelColorInitializeColors.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelColorInitializeColors.Location = new System.Drawing.Point(3, 28);
            this.PanelColorInitializeColors.Name = "PanelColorInitializeColors";
            this.PanelColorInitializeColors.RowCount = 1;
            this.PanelColorInitializeColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelColorInitializeColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.PanelColorInitializeColors.Size = new System.Drawing.Size(341, 26);
            this.PanelColorInitializeColors.TabIndex = 4;
            // 
            // LabelColorInitializeRGB
            // 
            this.LabelColorInitializeRGB.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelColorInitializeRGB.Location = new System.Drawing.Point(3, 0);
            this.LabelColorInitializeRGB.Name = "LabelColorInitializeRGB";
            this.LabelColorInitializeRGB.Size = new System.Drawing.Size(38, 26);
            this.LabelColorInitializeRGB.TabIndex = 0;
            this.LabelColorInitializeRGB.Text = "RGB :";
            this.LabelColorInitializeRGB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UdColorInitializeAlpha
            // 
            this.UdColorInitializeAlpha.Dock = System.Windows.Forms.DockStyle.Left;
            this.UdColorInitializeAlpha.Location = new System.Drawing.Point(175, 3);
            this.UdColorInitializeAlpha.Name = "UdColorInitializeAlpha";
            this.UdColorInitializeAlpha.Size = new System.Drawing.Size(58, 19);
            this.UdColorInitializeAlpha.TabIndex = 3;
            this.UdColorInitializeAlpha.Tail = " %";
            this.UdColorInitializeAlpha.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.UdColorInitializeAlpha.ValueChanged += new System.EventHandler(this.UdColorInitializeAlpha_ValueChanged);
            // 
            // LabelColorInitializeAlpha
            // 
            this.LabelColorInitializeAlpha.AutoSize = true;
            this.LabelColorInitializeAlpha.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelColorInitializeAlpha.Location = new System.Drawing.Point(129, 0);
            this.LabelColorInitializeAlpha.Name = "LabelColorInitializeAlpha";
            this.LabelColorInitializeAlpha.Size = new System.Drawing.Size(40, 26);
            this.LabelColorInitializeAlpha.TabIndex = 2;
            this.LabelColorInitializeAlpha.Text = "Alpha :";
            this.LabelColorInitializeAlpha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonColorInitializeRGB
            // 
            this.ButtonColorInitializeRGB.BackColor = System.Drawing.Color.White;
            this.ButtonColorInitializeRGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonColorInitializeRGB.Location = new System.Drawing.Point(47, 3);
            this.ButtonColorInitializeRGB.Name = "ButtonColorInitializeRGB";
            this.ButtonColorInitializeRGB.Size = new System.Drawing.Size(76, 20);
            this.ButtonColorInitializeRGB.TabIndex = 1;
            this.ButtonColorInitializeRGB.UseVisualStyleBackColor = false;
            this.ButtonColorInitializeRGB.Click += new System.EventHandler(this.ButtonColorInitializeRGB_Click);
            // 
            // PanelColorInitializeDimensions
            // 
            this.PanelColorInitializeDimensions.ColumnCount = 5;
            this.PanelColorInitializeDimensions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelColorInitializeDimensions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.PanelColorInitializeDimensions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelColorInitializeDimensions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.PanelColorInitializeDimensions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelColorInitializeDimensions.Controls.Add(this.UdColorInitializeHeight, 3, 0);
            this.PanelColorInitializeDimensions.Controls.Add(this.LabelTextureInitializeColorHeight, 2, 0);
            this.PanelColorInitializeDimensions.Controls.Add(this.LabelTextureInitializeColorWidth, 0, 0);
            this.PanelColorInitializeDimensions.Controls.Add(this.UdColorInitializeWidth, 1, 0);
            this.PanelColorInitializeDimensions.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelColorInitializeDimensions.Location = new System.Drawing.Point(3, 3);
            this.PanelColorInitializeDimensions.Name = "PanelColorInitializeDimensions";
            this.PanelColorInitializeDimensions.RowCount = 1;
            this.PanelColorInitializeDimensions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelColorInitializeDimensions.Size = new System.Drawing.Size(341, 25);
            this.PanelColorInitializeDimensions.TabIndex = 5;
            // 
            // UdColorInitializeHeight
            // 
            this.UdColorInitializeHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UdColorInitializeHeight.Location = new System.Drawing.Point(168, 3);
            this.UdColorInitializeHeight.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.UdColorInitializeHeight.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.UdColorInitializeHeight.Name = "UdColorInitializeHeight";
            this.UdColorInitializeHeight.Size = new System.Drawing.Size(64, 19);
            this.UdColorInitializeHeight.TabIndex = 4;
            this.UdColorInitializeHeight.Tail = "";
            this.UdColorInitializeHeight.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.UdColorInitializeHeight.ValueChanged += new System.EventHandler(this.UdColorInitializeDimensions_ValueChanged);
            // 
            // LabelTextureInitializeColorHeight
            // 
            this.LabelTextureInitializeColorHeight.AutoSize = true;
            this.LabelTextureInitializeColorHeight.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelTextureInitializeColorHeight.Location = new System.Drawing.Point(118, 0);
            this.LabelTextureInitializeColorHeight.Name = "LabelTextureInitializeColorHeight";
            this.LabelTextureInitializeColorHeight.Size = new System.Drawing.Size(44, 25);
            this.LabelTextureInitializeColorHeight.TabIndex = 3;
            this.LabelTextureInitializeColorHeight.Text = "Height :";
            this.LabelTextureInitializeColorHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelTextureInitializeColorWidth
            // 
            this.LabelTextureInitializeColorWidth.AutoSize = true;
            this.LabelTextureInitializeColorWidth.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelTextureInitializeColorWidth.Location = new System.Drawing.Point(3, 0);
            this.LabelTextureInitializeColorWidth.Name = "LabelTextureInitializeColorWidth";
            this.LabelTextureInitializeColorWidth.Size = new System.Drawing.Size(39, 25);
            this.LabelTextureInitializeColorWidth.TabIndex = 1;
            this.LabelTextureInitializeColorWidth.Text = "Width :";
            this.LabelTextureInitializeColorWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UdColorInitializeWidth
            // 
            this.UdColorInitializeWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UdColorInitializeWidth.Location = new System.Drawing.Point(48, 3);
            this.UdColorInitializeWidth.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.UdColorInitializeWidth.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.UdColorInitializeWidth.Name = "UdColorInitializeWidth";
            this.UdColorInitializeWidth.Size = new System.Drawing.Size(64, 19);
            this.UdColorInitializeWidth.TabIndex = 2;
            this.UdColorInitializeWidth.Tail = "";
            this.UdColorInitializeWidth.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.UdColorInitializeWidth.ValueChanged += new System.EventHandler(this.UdColorInitializeDimensions_ValueChanged);
            // 
            // PanelSourceFileOptions
            // 
            this.PanelSourceFileOptions.Controls.Add(this.TextBoxFileInitializePath);
            this.PanelSourceFileOptions.Controls.Add(this.ButtonFileInitializeChoosePath);
            this.PanelSourceFileOptions.Controls.Add(this.LabelFileInitializeFile);
            this.PanelSourceFileOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSourceFileOptions.Location = new System.Drawing.Point(3, 163);
            this.PanelSourceFileOptions.Name = "PanelSourceFileOptions";
            this.PanelSourceFileOptions.Padding = new System.Windows.Forms.Padding(3);
            this.PanelSourceFileOptions.Size = new System.Drawing.Size(347, 27);
            this.PanelSourceFileOptions.TabIndex = 8;
            // 
            // TextBoxFileInitializePath
            // 
            this.TextBoxFileInitializePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxFileInitializePath.Location = new System.Drawing.Point(41, 3);
            this.TextBoxFileInitializePath.Name = "TextBoxFileInitializePath";
            this.TextBoxFileInitializePath.Size = new System.Drawing.Size(274, 19);
            this.TextBoxFileInitializePath.TabIndex = 2;
            this.TextBoxFileInitializePath.TextChanged += new System.EventHandler(this.TextBoxFileInitializePath_TextChanged);
            // 
            // ButtonFileInitializeChoosePath
            // 
            this.ButtonFileInitializeChoosePath.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonFileInitializeChoosePath.Location = new System.Drawing.Point(315, 3);
            this.ButtonFileInitializeChoosePath.Name = "ButtonFileInitializeChoosePath";
            this.ButtonFileInitializeChoosePath.Size = new System.Drawing.Size(29, 21);
            this.ButtonFileInitializeChoosePath.TabIndex = 3;
            this.ButtonFileInitializeChoosePath.Text = "...";
            this.ButtonFileInitializeChoosePath.UseVisualStyleBackColor = true;
            // 
            // LabelFileInitializeFile
            // 
            this.LabelFileInitializeFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelFileInitializeFile.Location = new System.Drawing.Point(3, 3);
            this.LabelFileInitializeFile.Name = "LabelFileInitializeFile";
            this.LabelFileInitializeFile.Size = new System.Drawing.Size(38, 21);
            this.LabelFileInitializeFile.TabIndex = 1;
            this.LabelFileInitializeFile.Text = "File :";
            this.LabelFileInitializeFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ctrl_TextureVariableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.PanelSourceFileOptions);
            this.Controls.Add(this.PanelSourceColorOptions);
            this.Controls.Add(this.PanelSource);
            this.Controls.Add(this.PanelInitializeInfo);
            this.Name = "Ctrl_TextureVariableView";
            this.Size = new System.Drawing.Size(353, 348);
            this.Controls.SetChildIndex(this.PanelInitializeInfo, 0);
            this.Controls.SetChildIndex(this.PanelSource, 0);
            this.Controls.SetChildIndex(this.PanelSourceColorOptions, 0);
            this.Controls.SetChildIndex(this.PanelSourceFileOptions, 0);
            this.PanelInitializeInfo.ResumeLayout(false);
            this.PanelInitializeInfo.PerformLayout();
            this.PanelSource.ResumeLayout(false);
            this.PanelSource.PerformLayout();
            this.PanelSourceColorOptions.ResumeLayout(false);
            this.PanelColorInitializeColors.ResumeLayout(false);
            this.PanelColorInitializeColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdColorInitializeAlpha)).EndInit();
            this.PanelColorInitializeDimensions.ResumeLayout(false);
            this.PanelColorInitializeDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdColorInitializeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdColorInitializeWidth)).EndInit();
            this.PanelSourceFileOptions.ResumeLayout(false);
            this.PanelSourceFileOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PanelInitializeInfo;
        private System.Windows.Forms.ComboBox ComboDataType;
        private System.Windows.Forms.Label LabelFormat;
        private System.Windows.Forms.ComboBox ComboFormat;
        private System.Windows.Forms.Label LabelDataType;
        private System.Windows.Forms.Panel PanelSource;
        private System.Windows.Forms.ComboBox ComboSource;
        private System.Windows.Forms.Label LabelSource;
        private System.Windows.Forms.Panel PanelSourceColorOptions;
        private rtUtility.rtControl.CustomNumericUpDown UdColorInitializeAlpha;
        private System.Windows.Forms.Label LabelColorInitializeAlpha;
        private System.Windows.Forms.Button ButtonColorInitializeRGB;
        private System.Windows.Forms.Label LabelColorInitializeRGB;
        private System.Windows.Forms.Panel PanelSourceFileOptions;
        private System.Windows.Forms.TextBox TextBoxFileInitializePath;
        private System.Windows.Forms.Button ButtonFileInitializeChoosePath;
        private System.Windows.Forms.Label LabelFileInitializeFile;
        private System.Windows.Forms.TableLayoutPanel PanelColorInitializeColors;
        private System.Windows.Forms.TableLayoutPanel PanelColorInitializeDimensions;
        private rtUtility.rtControl.CustomNumericUpDown UdColorInitializeHeight;
        private System.Windows.Forms.Label LabelTextureInitializeColorHeight;
        private System.Windows.Forms.Label LabelTextureInitializeColorWidth;
        private rtUtility.rtControl.CustomNumericUpDown UdColorInitializeWidth;
    }
}
