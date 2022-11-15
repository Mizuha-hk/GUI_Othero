namespace GUI_Osero
{
    partial class InGame
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
            if (disposing && (components != null))
            {
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
            this.TurnShow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TurnShow
            // 
            this.TurnShow.AutoSize = true;
            this.TurnShow.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TurnShow.Location = new System.Drawing.Point(0, 0);
            this.TurnShow.Name = "TurnShow";
            this.TurnShow.Size = new System.Drawing.Size(0, 28);
            this.TurnShow.TabIndex = 0;
            // 
            // InGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 553);
            this.Controls.Add(this.TurnShow);
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "InGame";
            this.Text = "InGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TurnShow;
    }
}

