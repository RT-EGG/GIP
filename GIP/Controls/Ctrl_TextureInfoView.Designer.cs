﻿namespace GIP.Controls
{
    partial class Ctrl_TextureInfoView
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.PanelSource = new System.Windows.Forms.Panel();
            this.ComboSource = new System.Windows.Forms.ComboBox();
            this.LabelSource = new System.Windows.Forms.Label();
            this.PanelSourceColorOptions = new System.Windows.Forms.Panel();
            this.UdColorInitializeAlpha = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.LabelColorInitializeAlpha = new System.Windows.Forms.Label();
            this.ButtonColorInitializeRGB = new System.Windows.Forms.Button();
            this.LabelColorInitializeRGB = new System.Windows.Forms.Label();
            this.PanelSourceFileOptions = new System.Windows.Forms.Panel();
            this.TextBoxFileInitializePath = new System.Windows.Forms.TextBox();
            this.ButtonFileInitializeChoosePath = new System.Windows.Forms.Button();
            this.LabelFileInitializeFile = new System.Windows.Forms.Label();
            this.PanelInitializeInfo.SuspendLayout();
            this.PanelSource.SuspendLayout();
            this.PanelSourceColorOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdColorInitializeAlpha)).BeginInit();
            this.PanelSourceFileOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelInitializeInfo
            // 
            this.PanelInitializeInfo.ColumnCount = 2;
            this.PanelInitializeInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelInitializeInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelInitializeInfo.Controls.Add(this.ComboDataType, 1, 2);
            this.PanelInitializeInfo.Controls.Add(this.LabelFormat, 0, 1);
            this.PanelInitializeInfo.Controls.Add(this.ComboFormat, 1, 1);
            this.PanelInitializeInfo.Controls.Add(this.LabelDataType, 0, 2);
            this.PanelInitializeInfo.Controls.Add(this.label1, 0, 0);
            this.PanelInitializeInfo.Controls.Add(this.TextBoxName, 1, 0);
            this.PanelInitializeInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelInitializeInfo.Location = new System.Drawing.Point(0, 0);
            this.PanelInitializeInfo.Name = "PanelInitializeInfo";
            this.PanelInitializeInfo.RowCount = 3;
            this.PanelInitializeInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelInitializeInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelInitializeInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelInitializeInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelInitializeInfo.Size = new System.Drawing.Size(353, 76);
            this.PanelInitializeInfo.TabIndex = 5;
            // 
            // ComboDataType
            // 
            this.ComboDataType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboDataType.FormattingEnabled = true;
            this.ComboDataType.Items.AddRange(new object[] {
            "Unsigned byte"});
            this.ComboDataType.Location = new System.Drawing.Point(70, 53);
            this.ComboDataType.Name = "ComboDataType";
            this.ComboDataType.Size = new System.Drawing.Size(280, 20);
            this.ComboDataType.TabIndex = 3;
            this.ComboDataType.SelectedValueChanged += new System.EventHandler(this.ComboDataType_SelectedValueChanged);
            // 
            // LabelFormat
            // 
            this.LabelFormat.AutoSize = true;
            this.LabelFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelFormat.Location = new System.Drawing.Point(3, 25);
            this.LabelFormat.Name = "LabelFormat";
            this.LabelFormat.Size = new System.Drawing.Size(47, 25);
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
            this.ComboFormat.Location = new System.Drawing.Point(70, 28);
            this.ComboFormat.Name = "ComboFormat";
            this.ComboFormat.Size = new System.Drawing.Size(280, 20);
            this.ComboFormat.TabIndex = 1;
            this.ComboFormat.SelectedValueChanged += new System.EventHandler(this.ComboFormat_SelectedValueChanged);
            // 
            // LabelDataType
            // 
            this.LabelDataType.AutoSize = true;
            this.LabelDataType.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelDataType.Location = new System.Drawing.Point(3, 50);
            this.LabelDataType.Name = "LabelDataType";
            this.LabelDataType.Size = new System.Drawing.Size(61, 26);
            this.LabelDataType.TabIndex = 2;
            this.LabelDataType.Text = "Data type :";
            this.LabelDataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxName
            // 
            this.TextBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxName.Location = new System.Drawing.Point(70, 3);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(280, 19);
            this.TextBoxName.TabIndex = 5;
            this.TextBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // PanelSource
            // 
            this.PanelSource.Controls.Add(this.ComboSource);
            this.PanelSource.Controls.Add(this.LabelSource);
            this.PanelSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSource.Location = new System.Drawing.Point(0, 76);
            this.PanelSource.Name = "PanelSource";
            this.PanelSource.Size = new System.Drawing.Size(353, 28);
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
            this.PanelSourceColorOptions.Controls.Add(this.UdColorInitializeAlpha);
            this.PanelSourceColorOptions.Controls.Add(this.LabelColorInitializeAlpha);
            this.PanelSourceColorOptions.Controls.Add(this.ButtonColorInitializeRGB);
            this.PanelSourceColorOptions.Controls.Add(this.LabelColorInitializeRGB);
            this.PanelSourceColorOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSourceColorOptions.Location = new System.Drawing.Point(0, 104);
            this.PanelSourceColorOptions.Name = "PanelSourceColorOptions";
            this.PanelSourceColorOptions.Padding = new System.Windows.Forms.Padding(3);
            this.PanelSourceColorOptions.Size = new System.Drawing.Size(353, 25);
            this.PanelSourceColorOptions.TabIndex = 7;
            // 
            // UdColorInitializeAlpha
            // 
            this.UdColorInitializeAlpha.Dock = System.Windows.Forms.DockStyle.Left;
            this.UdColorInitializeAlpha.Location = new System.Drawing.Point(156, 3);
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
            this.LabelColorInitializeAlpha.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelColorInitializeAlpha.Location = new System.Drawing.Point(116, 3);
            this.LabelColorInitializeAlpha.Name = "LabelColorInitializeAlpha";
            this.LabelColorInitializeAlpha.Size = new System.Drawing.Size(40, 19);
            this.LabelColorInitializeAlpha.TabIndex = 2;
            this.LabelColorInitializeAlpha.Text = "Alpha :";
            this.LabelColorInitializeAlpha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonColorInitializeRGB
            // 
            this.ButtonColorInitializeRGB.BackColor = System.Drawing.Color.White;
            this.ButtonColorInitializeRGB.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonColorInitializeRGB.Location = new System.Drawing.Point(41, 3);
            this.ButtonColorInitializeRGB.Name = "ButtonColorInitializeRGB";
            this.ButtonColorInitializeRGB.Size = new System.Drawing.Size(75, 19);
            this.ButtonColorInitializeRGB.TabIndex = 1;
            this.ButtonColorInitializeRGB.UseVisualStyleBackColor = false;
            this.ButtonColorInitializeRGB.Click += new System.EventHandler(this.ButtonColorInitializeRGB_Click);
            // 
            // LabelColorInitializeRGB
            // 
            this.LabelColorInitializeRGB.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelColorInitializeRGB.Location = new System.Drawing.Point(3, 3);
            this.LabelColorInitializeRGB.Name = "LabelColorInitializeRGB";
            this.LabelColorInitializeRGB.Size = new System.Drawing.Size(38, 19);
            this.LabelColorInitializeRGB.TabIndex = 0;
            this.LabelColorInitializeRGB.Text = "Color :";
            this.LabelColorInitializeRGB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelSourceFileOptions
            // 
            this.PanelSourceFileOptions.Controls.Add(this.TextBoxFileInitializePath);
            this.PanelSourceFileOptions.Controls.Add(this.ButtonFileInitializeChoosePath);
            this.PanelSourceFileOptions.Controls.Add(this.LabelFileInitializeFile);
            this.PanelSourceFileOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSourceFileOptions.Location = new System.Drawing.Point(0, 129);
            this.PanelSourceFileOptions.Name = "PanelSourceFileOptions";
            this.PanelSourceFileOptions.Padding = new System.Windows.Forms.Padding(3);
            this.PanelSourceFileOptions.Size = new System.Drawing.Size(353, 27);
            this.PanelSourceFileOptions.TabIndex = 8;
            // 
            // TextBoxFileInitializePath
            // 
            this.TextBoxFileInitializePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxFileInitializePath.Location = new System.Drawing.Point(41, 3);
            this.TextBoxFileInitializePath.Name = "TextBoxFileInitializePath";
            this.TextBoxFileInitializePath.Size = new System.Drawing.Size(280, 19);
            this.TextBoxFileInitializePath.TabIndex = 2;
            // 
            // ButtonFileInitializeChoosePath
            // 
            this.ButtonFileInitializeChoosePath.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonFileInitializeChoosePath.Location = new System.Drawing.Point(321, 3);
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
            // Ctrl_TextureInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.PanelSourceFileOptions);
            this.Controls.Add(this.PanelSourceColorOptions);
            this.Controls.Add(this.PanelSource);
            this.Controls.Add(this.PanelInitializeInfo);
            this.Name = "Ctrl_TextureInfoView";
            this.Size = new System.Drawing.Size(353, 348);
            this.PanelInitializeInfo.ResumeLayout(false);
            this.PanelInitializeInfo.PerformLayout();
            this.PanelSource.ResumeLayout(false);
            this.PanelSource.PerformLayout();
            this.PanelSourceColorOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UdColorInitializeAlpha)).EndInit();
            this.PanelSourceFileOptions.ResumeLayout(false);
            this.PanelSourceFileOptions.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxName;
    }
}
