﻿namespace GIP.Controls.ProcessTaskEditor
{
    partial class Ctrl_ComputeTaskEditor
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
            this.Ctrl_UniformVariables = new GIP.Controls.Ctrl_UniformVariableListView();
            this.PanelDispatchGroupSize = new System.Windows.Forms.Panel();
            this.PanelDispatchGroupSizeValues = new System.Windows.Forms.TableLayoutPanel();
            this.UdDispatchGroupSizeZ = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.LabelDispatchGroupSizeZ = new System.Windows.Forms.Label();
            this.UdDispatchGroupSizeY = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.LabelDispatchGroupSizeY = new System.Windows.Forms.Label();
            this.LabelDispatchGroupSizeX = new System.Windows.Forms.Label();
            this.UdDispatchGroupSizeX = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.LabelDispatchGroupSize = new System.Windows.Forms.Label();
            this.PanelSource = new System.Windows.Forms.TableLayoutPanel();
            this.LabelShaderSource = new System.Windows.Forms.Label();
            this.ComboShaderSource = new System.Windows.Forms.ComboBox();
            this.PanelDispatchGroupSize.SuspendLayout();
            this.PanelDispatchGroupSizeValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchGroupSizeZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchGroupSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchGroupSizeX)).BeginInit();
            this.PanelSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ctrl_UniformVariables
            // 
            this.Ctrl_UniformVariables.Data = null;
            this.Ctrl_UniformVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ctrl_UniformVariables.Location = new System.Drawing.Point(3, 95);
            this.Ctrl_UniformVariables.Name = "Ctrl_UniformVariables";
            this.Ctrl_UniformVariables.Size = new System.Drawing.Size(373, 198);
            this.Ctrl_UniformVariables.TabIndex = 4;
            this.Ctrl_UniformVariables.Variables = null;
            // 
            // PanelDispatchGroupSize
            // 
            this.PanelDispatchGroupSize.Controls.Add(this.PanelDispatchGroupSizeValues);
            this.PanelDispatchGroupSize.Controls.Add(this.LabelDispatchGroupSize);
            this.PanelDispatchGroupSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDispatchGroupSize.Location = new System.Drawing.Point(3, 51);
            this.PanelDispatchGroupSize.Name = "PanelDispatchGroupSize";
            this.PanelDispatchGroupSize.Size = new System.Drawing.Size(373, 44);
            this.PanelDispatchGroupSize.TabIndex = 5;
            // 
            // PanelDispatchGroupSizeValues
            // 
            this.PanelDispatchGroupSizeValues.ColumnCount = 6;
            this.PanelDispatchGroupSizeValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelDispatchGroupSizeValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelDispatchGroupSizeValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelDispatchGroupSizeValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelDispatchGroupSizeValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelDispatchGroupSizeValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelDispatchGroupSizeValues.Controls.Add(this.UdDispatchGroupSizeZ, 5, 0);
            this.PanelDispatchGroupSizeValues.Controls.Add(this.LabelDispatchGroupSizeZ, 4, 0);
            this.PanelDispatchGroupSizeValues.Controls.Add(this.UdDispatchGroupSizeY, 3, 0);
            this.PanelDispatchGroupSizeValues.Controls.Add(this.LabelDispatchGroupSizeY, 2, 0);
            this.PanelDispatchGroupSizeValues.Controls.Add(this.LabelDispatchGroupSizeX, 0, 0);
            this.PanelDispatchGroupSizeValues.Controls.Add(this.UdDispatchGroupSizeX, 1, 0);
            this.PanelDispatchGroupSizeValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDispatchGroupSizeValues.Location = new System.Drawing.Point(0, 18);
            this.PanelDispatchGroupSizeValues.Name = "PanelDispatchGroupSizeValues";
            this.PanelDispatchGroupSizeValues.RowCount = 1;
            this.PanelDispatchGroupSizeValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelDispatchGroupSizeValues.Size = new System.Drawing.Size(373, 26);
            this.PanelDispatchGroupSizeValues.TabIndex = 1;
            // 
            // UdDispatchGroupSizeZ
            // 
            this.UdDispatchGroupSizeZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UdDispatchGroupSizeZ.Location = new System.Drawing.Point(275, 3);
            this.UdDispatchGroupSizeZ.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.UdDispatchGroupSizeZ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UdDispatchGroupSizeZ.Name = "UdDispatchGroupSizeZ";
            this.UdDispatchGroupSizeZ.Size = new System.Drawing.Size(95, 19);
            this.UdDispatchGroupSizeZ.TabIndex = 5;
            this.UdDispatchGroupSizeZ.Tail = "";
            this.UdDispatchGroupSizeZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UdDispatchGroupSizeZ.ValueChanged += new System.EventHandler(this.UdDispatchGroupSizeZ_ValueChanged);
            // 
            // LabelDispatchGroupSizeZ
            // 
            this.LabelDispatchGroupSizeZ.AutoSize = true;
            this.LabelDispatchGroupSizeZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelDispatchGroupSizeZ.Location = new System.Drawing.Point(251, 0);
            this.LabelDispatchGroupSizeZ.Name = "LabelDispatchGroupSizeZ";
            this.LabelDispatchGroupSizeZ.Size = new System.Drawing.Size(18, 26);
            this.LabelDispatchGroupSizeZ.TabIndex = 4;
            this.LabelDispatchGroupSizeZ.Text = "Z :";
            this.LabelDispatchGroupSizeZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UdDispatchGroupSizeY
            // 
            this.UdDispatchGroupSizeY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UdDispatchGroupSizeY.Location = new System.Drawing.Point(151, 3);
            this.UdDispatchGroupSizeY.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.UdDispatchGroupSizeY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UdDispatchGroupSizeY.Name = "UdDispatchGroupSizeY";
            this.UdDispatchGroupSizeY.Size = new System.Drawing.Size(94, 19);
            this.UdDispatchGroupSizeY.TabIndex = 3;
            this.UdDispatchGroupSizeY.Tail = "";
            this.UdDispatchGroupSizeY.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.UdDispatchGroupSizeY.ValueChanged += new System.EventHandler(this.UdDispatchGroupSizeY_ValueChanged);
            // 
            // LabelDispatchGroupSizeY
            // 
            this.LabelDispatchGroupSizeY.AutoSize = true;
            this.LabelDispatchGroupSizeY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelDispatchGroupSizeY.Location = new System.Drawing.Point(127, 0);
            this.LabelDispatchGroupSizeY.Name = "LabelDispatchGroupSizeY";
            this.LabelDispatchGroupSizeY.Size = new System.Drawing.Size(18, 26);
            this.LabelDispatchGroupSizeY.TabIndex = 2;
            this.LabelDispatchGroupSizeY.Text = "Y :";
            this.LabelDispatchGroupSizeY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelDispatchGroupSizeX
            // 
            this.LabelDispatchGroupSizeX.AutoSize = true;
            this.LabelDispatchGroupSizeX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelDispatchGroupSizeX.Location = new System.Drawing.Point(3, 0);
            this.LabelDispatchGroupSizeX.Name = "LabelDispatchGroupSizeX";
            this.LabelDispatchGroupSizeX.Size = new System.Drawing.Size(18, 26);
            this.LabelDispatchGroupSizeX.TabIndex = 0;
            this.LabelDispatchGroupSizeX.Text = "X :";
            this.LabelDispatchGroupSizeX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UdDispatchGroupSizeX
            // 
            this.UdDispatchGroupSizeX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UdDispatchGroupSizeX.Location = new System.Drawing.Point(27, 3);
            this.UdDispatchGroupSizeX.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.UdDispatchGroupSizeX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UdDispatchGroupSizeX.Name = "UdDispatchGroupSizeX";
            this.UdDispatchGroupSizeX.Size = new System.Drawing.Size(94, 19);
            this.UdDispatchGroupSizeX.TabIndex = 1;
            this.UdDispatchGroupSizeX.Tail = "";
            this.UdDispatchGroupSizeX.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.UdDispatchGroupSizeX.ValueChanged += new System.EventHandler(this.UdDispatchGroupSizeX_ValueChanged);
            // 
            // LabelDispatchGroupSize
            // 
            this.LabelDispatchGroupSize.AutoSize = true;
            this.LabelDispatchGroupSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelDispatchGroupSize.Location = new System.Drawing.Point(0, 0);
            this.LabelDispatchGroupSize.Name = "LabelDispatchGroupSize";
            this.LabelDispatchGroupSize.Padding = new System.Windows.Forms.Padding(3);
            this.LabelDispatchGroupSize.Size = new System.Drawing.Size(118, 18);
            this.LabelDispatchGroupSize.TabIndex = 0;
            this.LabelDispatchGroupSize.Text = "Dispatch group size :";
            // 
            // PanelSource
            // 
            this.PanelSource.ColumnCount = 2;
            this.PanelSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelSource.Controls.Add(this.LabelShaderSource, 0, 0);
            this.PanelSource.Controls.Add(this.ComboShaderSource, 1, 0);
            this.PanelSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSource.Location = new System.Drawing.Point(3, 22);
            this.PanelSource.Name = "PanelSource";
            this.PanelSource.RowCount = 1;
            this.PanelSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelSource.Size = new System.Drawing.Size(373, 29);
            this.PanelSource.TabIndex = 6;
            // 
            // LabelShaderSource
            // 
            this.LabelShaderSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelShaderSource.Location = new System.Drawing.Point(3, 0);
            this.LabelShaderSource.Name = "LabelShaderSource";
            this.LabelShaderSource.Size = new System.Drawing.Size(46, 29);
            this.LabelShaderSource.TabIndex = 0;
            this.LabelShaderSource.Text = "Source :";
            this.LabelShaderSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ComboShaderSource
            // 
            this.ComboShaderSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboShaderSource.FormattingEnabled = true;
            this.ComboShaderSource.Location = new System.Drawing.Point(55, 3);
            this.ComboShaderSource.Name = "ComboShaderSource";
            this.ComboShaderSource.Size = new System.Drawing.Size(315, 20);
            this.ComboShaderSource.TabIndex = 1;
            this.ComboShaderSource.SelectedIndexChanged += new System.EventHandler(this.ComboShaderSource_SelectedIndexChanged);
            // 
            // Ctrl_ComputeTaskEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Ctrl_UniformVariables);
            this.Controls.Add(this.PanelDispatchGroupSize);
            this.Controls.Add(this.PanelSource);
            this.Name = "Ctrl_ComputeTaskEditor";
            this.Size = new System.Drawing.Size(379, 296);
            this.Controls.SetChildIndex(this.PanelSource, 0);
            this.Controls.SetChildIndex(this.PanelDispatchGroupSize, 0);
            this.Controls.SetChildIndex(this.Ctrl_UniformVariables, 0);
            this.PanelDispatchGroupSize.ResumeLayout(false);
            this.PanelDispatchGroupSize.PerformLayout();
            this.PanelDispatchGroupSizeValues.ResumeLayout(false);
            this.PanelDispatchGroupSizeValues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchGroupSizeZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchGroupSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchGroupSizeX)).EndInit();
            this.PanelSource.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctrl_UniformVariableListView Ctrl_UniformVariables;
        private System.Windows.Forms.Panel PanelDispatchGroupSize;
        private System.Windows.Forms.TableLayoutPanel PanelDispatchGroupSizeValues;
        private rtUtility.rtControl.CustomNumericUpDown UdDispatchGroupSizeZ;
        private System.Windows.Forms.Label LabelDispatchGroupSizeZ;
        private rtUtility.rtControl.CustomNumericUpDown UdDispatchGroupSizeY;
        private System.Windows.Forms.Label LabelDispatchGroupSizeY;
        private System.Windows.Forms.Label LabelDispatchGroupSizeX;
        private rtUtility.rtControl.CustomNumericUpDown UdDispatchGroupSizeX;
        private System.Windows.Forms.Label LabelDispatchGroupSize;
        private System.Windows.Forms.TableLayoutPanel PanelSource;
        private System.Windows.Forms.Label LabelShaderSource;
        private System.Windows.Forms.ComboBox ComboShaderSource;
    }
}
