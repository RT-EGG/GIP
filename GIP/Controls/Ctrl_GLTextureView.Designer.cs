namespace GIP.Controls
{
    partial class Ctrl_GLTextureView
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
            this.PanelCurrentTexture = new System.Windows.Forms.TableLayoutPanel();
            this.LabelCurrentTexture = new System.Windows.Forms.Label();
            this.ComboCurrentTexture = new System.Windows.Forms.ComboBox();
            this.PanelDisplayOptions = new System.Windows.Forms.Panel();
            this.ButtonBgColor = new System.Windows.Forms.Button();
            this.GLView = new GIP.Controls.Ctrl_GLControl();
            this.PanelCurrentTexture.SuspendLayout();
            this.PanelDisplayOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelCurrentTexture
            // 
            this.PanelCurrentTexture.ColumnCount = 2;
            this.PanelCurrentTexture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelCurrentTexture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelCurrentTexture.Controls.Add(this.LabelCurrentTexture, 0, 0);
            this.PanelCurrentTexture.Controls.Add(this.ComboCurrentTexture, 1, 0);
            this.PanelCurrentTexture.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelCurrentTexture.Location = new System.Drawing.Point(0, 0);
            this.PanelCurrentTexture.Name = "PanelCurrentTexture";
            this.PanelCurrentTexture.RowCount = 1;
            this.PanelCurrentTexture.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelCurrentTexture.Size = new System.Drawing.Size(501, 27);
            this.PanelCurrentTexture.TabIndex = 1;
            // 
            // LabelCurrentTexture
            // 
            this.LabelCurrentTexture.AutoSize = true;
            this.LabelCurrentTexture.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelCurrentTexture.Location = new System.Drawing.Point(3, 0);
            this.LabelCurrentTexture.Name = "LabelCurrentTexture";
            this.LabelCurrentTexture.Size = new System.Drawing.Size(46, 27);
            this.LabelCurrentTexture.TabIndex = 1;
            this.LabelCurrentTexture.Text = "Texture:";
            this.LabelCurrentTexture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboCurrentTexture
            // 
            this.ComboCurrentTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboCurrentTexture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCurrentTexture.FormattingEnabled = true;
            this.ComboCurrentTexture.Location = new System.Drawing.Point(55, 3);
            this.ComboCurrentTexture.Name = "ComboCurrentTexture";
            this.ComboCurrentTexture.Size = new System.Drawing.Size(443, 20);
            this.ComboCurrentTexture.TabIndex = 2;
            this.ComboCurrentTexture.SelectedValueChanged += new System.EventHandler(this.ComboCurrentTexture_SelectedValueChanged);
            // 
            // PanelDisplayOptions
            // 
            this.PanelDisplayOptions.Controls.Add(this.ButtonBgColor);
            this.PanelDisplayOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDisplayOptions.Location = new System.Drawing.Point(0, 486);
            this.PanelDisplayOptions.Name = "PanelDisplayOptions";
            this.PanelDisplayOptions.Padding = new System.Windows.Forms.Padding(3);
            this.PanelDisplayOptions.Size = new System.Drawing.Size(501, 27);
            this.PanelDisplayOptions.TabIndex = 3;
            // 
            // ButtonBgColor
            // 
            this.ButtonBgColor.BackColor = System.Drawing.Color.Black;
            this.ButtonBgColor.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonBgColor.Location = new System.Drawing.Point(445, 3);
            this.ButtonBgColor.Name = "ButtonBgColor";
            this.ButtonBgColor.Size = new System.Drawing.Size(53, 21);
            this.ButtonBgColor.TabIndex = 0;
            this.ButtonBgColor.UseVisualStyleBackColor = false;
            // 
            // GLView
            // 
            this.GLView.BackColor = System.Drawing.Color.Black;
            this.GLView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GLView.Location = new System.Drawing.Point(0, 27);
            this.GLView.Name = "GLView";
            this.GLView.Size = new System.Drawing.Size(501, 459);
            this.GLView.TabIndex = 2;
            this.GLView.VSync = false;
            this.GLView.OnGLPaint += new GIP.Controls.GLControlEvent(this.GLView_OnGLPaint);
            // 
            // Ctrl_GLTextureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GLView);
            this.Controls.Add(this.PanelDisplayOptions);
            this.Controls.Add(this.PanelCurrentTexture);
            this.Name = "Ctrl_GLTextureView";
            this.Size = new System.Drawing.Size(501, 513);
            this.PanelCurrentTexture.ResumeLayout(false);
            this.PanelCurrentTexture.PerformLayout();
            this.PanelDisplayOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PanelCurrentTexture;
        private System.Windows.Forms.Label LabelCurrentTexture;
        private System.Windows.Forms.ComboBox ComboCurrentTexture;
        private Ctrl_GLControl GLView;
        private System.Windows.Forms.Panel PanelDisplayOptions;
        private System.Windows.Forms.Button ButtonBgColor;
    }
}
