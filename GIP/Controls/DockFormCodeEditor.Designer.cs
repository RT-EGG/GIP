namespace GIP.Controls
{
    partial class DockFormCodeEditor
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
            this.components = new System.ComponentModel.Container();
            this.TextBoxCodeEditor = new GIP.Controls.ComputeShaderCodeBox(this.components);
            this.PanelDispatchSize = new System.Windows.Forms.TableLayoutPanel();
            this.UdDispatchSizeZ = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.LabelDispatchSizeZ = new System.Windows.Forms.Label();
            this.UdDispatchSizeY = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.LabelDispatchSizeY = new System.Windows.Forms.Label();
            this.LabelDispatchSizeX = new System.Windows.Forms.Label();
            this.LabelDispatchGroupSize = new System.Windows.Forms.Label();
            this.UdDispatchSizeX = new rtUtility.rtControl.CustomNumericUpDown(this.components);
            this.PanelDispatchSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeX)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxCodeEditor
            // 
            this.TextBoxCodeEditor.AcceptsTab = true;
            this.TextBoxCodeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxCodeEditor.Location = new System.Drawing.Point(0, 0);
            this.TextBoxCodeEditor.Multiline = true;
            this.TextBoxCodeEditor.Name = "TextBoxCodeEditor";
            this.TextBoxCodeEditor.Size = new System.Drawing.Size(328, 295);
            this.TextBoxCodeEditor.TabIndex = 0;
            // 
            // PanelDispatchSize
            // 
            this.PanelDispatchSize.ColumnCount = 7;
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelDispatchSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelDispatchSize.Controls.Add(this.UdDispatchSizeZ, 6, 0);
            this.PanelDispatchSize.Controls.Add(this.LabelDispatchSizeZ, 5, 0);
            this.PanelDispatchSize.Controls.Add(this.UdDispatchSizeY, 4, 0);
            this.PanelDispatchSize.Controls.Add(this.LabelDispatchSizeY, 3, 0);
            this.PanelDispatchSize.Controls.Add(this.LabelDispatchSizeX, 1, 0);
            this.PanelDispatchSize.Controls.Add(this.LabelDispatchGroupSize, 0, 0);
            this.PanelDispatchSize.Controls.Add(this.UdDispatchSizeX, 2, 0);
            this.PanelDispatchSize.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDispatchSize.Location = new System.Drawing.Point(0, 269);
            this.PanelDispatchSize.Name = "PanelDispatchSize";
            this.PanelDispatchSize.RowCount = 1;
            this.PanelDispatchSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelDispatchSize.Size = new System.Drawing.Size(328, 26);
            this.PanelDispatchSize.TabIndex = 3;
            // 
            // UdDispatchSizeZ
            // 
            this.UdDispatchSizeZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UdDispatchSizeZ.Location = new System.Drawing.Point(273, 3);
            this.UdDispatchSizeZ.Name = "UdDispatchSizeZ";
            this.UdDispatchSizeZ.Size = new System.Drawing.Size(52, 19);
            this.UdDispatchSizeZ.TabIndex = 6;
            this.UdDispatchSizeZ.Tail = "";
            this.UdDispatchSizeZ.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // LabelDispatchSizeZ
            // 
            this.LabelDispatchSizeZ.AutoSize = true;
            this.LabelDispatchSizeZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelDispatchSizeZ.Location = new System.Drawing.Point(251, 0);
            this.LabelDispatchSizeZ.Name = "LabelDispatchSizeZ";
            this.LabelDispatchSizeZ.Size = new System.Drawing.Size(16, 26);
            this.LabelDispatchSizeZ.TabIndex = 5;
            this.LabelDispatchSizeZ.Text = "z :";
            this.LabelDispatchSizeZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UdDispatchSizeY
            // 
            this.UdDispatchSizeY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UdDispatchSizeY.Location = new System.Drawing.Point(193, 3);
            this.UdDispatchSizeY.Name = "UdDispatchSizeY";
            this.UdDispatchSizeY.Size = new System.Drawing.Size(52, 19);
            this.UdDispatchSizeY.TabIndex = 4;
            this.UdDispatchSizeY.Tail = "";
            this.UdDispatchSizeY.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // LabelDispatchSizeY
            // 
            this.LabelDispatchSizeY.AutoSize = true;
            this.LabelDispatchSizeY.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelDispatchSizeY.Location = new System.Drawing.Point(170, 0);
            this.LabelDispatchSizeY.Name = "LabelDispatchSizeY";
            this.LabelDispatchSizeY.Size = new System.Drawing.Size(17, 26);
            this.LabelDispatchSizeY.TabIndex = 3;
            this.LabelDispatchSizeY.Text = "y :";
            this.LabelDispatchSizeY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelDispatchSizeX
            // 
            this.LabelDispatchSizeX.AutoSize = true;
            this.LabelDispatchSizeX.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelDispatchSizeX.Location = new System.Drawing.Point(89, 0);
            this.LabelDispatchSizeX.Name = "LabelDispatchSizeX";
            this.LabelDispatchSizeX.Size = new System.Drawing.Size(17, 26);
            this.LabelDispatchSizeX.TabIndex = 1;
            this.LabelDispatchSizeX.Text = "x :";
            this.LabelDispatchSizeX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelDispatchGroupSize
            // 
            this.LabelDispatchGroupSize.AutoSize = true;
            this.LabelDispatchGroupSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelDispatchGroupSize.Location = new System.Drawing.Point(3, 0);
            this.LabelDispatchGroupSize.Name = "LabelDispatchGroupSize";
            this.LabelDispatchGroupSize.Size = new System.Drawing.Size(80, 26);
            this.LabelDispatchGroupSize.TabIndex = 0;
            this.LabelDispatchGroupSize.Text = "Dispatch size :";
            this.LabelDispatchGroupSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UdDispatchSizeX
            // 
            this.UdDispatchSizeX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UdDispatchSizeX.Location = new System.Drawing.Point(112, 3);
            this.UdDispatchSizeX.Name = "UdDispatchSizeX";
            this.UdDispatchSizeX.Size = new System.Drawing.Size(52, 19);
            this.UdDispatchSizeX.TabIndex = 2;
            this.UdDispatchSizeX.Tail = "";
            this.UdDispatchSizeX.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // DockFormCodeEditor
            // 
            this.ClientSize = new System.Drawing.Size(328, 295);
            this.Controls.Add(this.PanelDispatchSize);
            this.Controls.Add(this.TextBoxCodeEditor);
            this.Name = "DockFormCodeEditor";
            this.Text = "CodeEditor";
            this.PanelDispatchSize.ResumeLayout(false);
            this.PanelDispatchSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdDispatchSizeX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComputeShaderCodeBox TextBoxCodeEditor;
        private System.Windows.Forms.TableLayoutPanel PanelDispatchSize;
        private rtUtility.rtControl.CustomNumericUpDown UdDispatchSizeZ;
        private System.Windows.Forms.Label LabelDispatchSizeZ;
        private rtUtility.rtControl.CustomNumericUpDown UdDispatchSizeY;
        private System.Windows.Forms.Label LabelDispatchSizeY;
        private System.Windows.Forms.Label LabelDispatchSizeX;
        private System.Windows.Forms.Label LabelDispatchGroupSize;
        private rtUtility.rtControl.CustomNumericUpDown UdDispatchSizeX;
    }
}
