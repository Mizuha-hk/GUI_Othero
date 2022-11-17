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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InGame));
            this.TurnShow = new System.Windows.Forms.Label();
            this.FinishButton = new System.Windows.Forms.Button();
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
            // FinishButton
            // 
            this.FinishButton.Font = new System.Drawing.Font("HG創英角ｺﾞｼｯｸUB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FinishButton.Location = new System.Drawing.Point(405, 546);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(145, 45);
            this.FinishButton.TabIndex = 1;
            this.FinishButton.Text = "ゲーム終了";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // InGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 603);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.TurnShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.Name = "InGame";
            this.Text = "InGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TurnShow;
        private System.Windows.Forms.Button FinishButton;
    }
}

