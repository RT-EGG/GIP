namespace GIP.Controls.ProcessTaskEditor
{
    partial class Ctrl_CountingForLoopTaskEditor
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
            this.LabelMaxLoopCount = new System.Windows.Forms.Label();
            this.UdMaxLoopCount = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdMaxLoopCount)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LabelMaxLoopCount, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.UdMaxLoopCount, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(282, 26);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // LabelMaxLoopCount
            // 
            this.LabelMaxLoopCount.AutoSize = true;
            this.LabelMaxLoopCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelMaxLoopCount.Location = new System.Drawing.Point(3, 0);
            this.LabelMaxLoopCount.Name = "LabelMaxLoopCount";
            this.LabelMaxLoopCount.Size = new System.Drawing.Size(94, 26);
            this.LabelMaxLoopCount.TabIndex = 0;
            this.LabelMaxLoopCount.Text = "Max Loop Count :";
            this.LabelMaxLoopCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UdMaxLoopCount
            // 
            this.UdMaxLoopCount.Location = new System.Drawing.Point(103, 3);
            this.UdMaxLoopCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.UdMaxLoopCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UdMaxLoopCount.Name = "UdMaxLoopCount";
            this.UdMaxLoopCount.Size = new System.Drawing.Size(120, 19);
            this.UdMaxLoopCount.TabIndex = 1;
            this.UdMaxLoopCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UdMaxLoopCount.ValueChanged += new System.EventHandler(this.UdMaxLoopCount_ValueChanged);
            // 
            // Ctrl_CountingForLoopTaskEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Ctrl_CountingForLoopTaskEditor";
            this.Size = new System.Drawing.Size(288, 181);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdMaxLoopCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabelMaxLoopCount;
        private System.Windows.Forms.NumericUpDown UdMaxLoopCount;
    }
}
