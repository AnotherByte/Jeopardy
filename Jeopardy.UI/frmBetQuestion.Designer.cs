namespace Jeopardy.UI
{
    partial class frmBetQuestion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStartScore = new System.Windows.Forms.Label();
            this.lblCategoryText = new System.Windows.Forms.Label();
            this.txtBet = new System.Windows.Forms.TextBox();
            this.lblBetText = new System.Windows.Forms.Label();
            this.btnAcceptBet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStartScore
            // 
            this.lblStartScore.AutoSize = true;
            this.lblStartScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartScore.ForeColor = System.Drawing.SystemColors.Control;
            this.lblStartScore.Location = new System.Drawing.Point(14, 159);
            this.lblStartScore.Name = "lblStartScore";
            this.lblStartScore.Size = new System.Drawing.Size(127, 24);
            this.lblStartScore.TabIndex = 0;
            this.lblStartScore.Text = "Current Score";
            // 
            // lblCategoryText
            // 
            this.lblCategoryText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryText.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCategoryText.Location = new System.Drawing.Point(12, 9);
            this.lblCategoryText.Name = "lblCategoryText";
            this.lblCategoryText.Size = new System.Drawing.Size(350, 150);
            this.lblCategoryText.TabIndex = 1;
            this.lblCategoryText.Text = "Category";
            this.lblCategoryText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBet
            // 
            this.txtBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBet.Location = new System.Drawing.Point(145, 248);
            this.txtBet.Name = "txtBet";
            this.txtBet.Size = new System.Drawing.Size(100, 26);
            this.txtBet.TabIndex = 2;
            this.txtBet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBetText
            // 
            this.lblBetText.AutoSize = true;
            this.lblBetText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBetText.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBetText.Location = new System.Drawing.Point(14, 212);
            this.lblBetText.Name = "lblBetText";
            this.lblBetText.Size = new System.Drawing.Size(231, 20);
            this.lblBetText.TabIndex = 3;
            this.lblBetText.Text = "Bet up to your current winnings:";
            // 
            // btnAcceptBet
            // 
            this.btnAcceptBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptBet.Location = new System.Drawing.Point(268, 240);
            this.btnAcceptBet.Name = "btnAcceptBet";
            this.btnAcceptBet.Size = new System.Drawing.Size(64, 39);
            this.btnAcceptBet.TabIndex = 4;
            this.btnAcceptBet.Text = "Bet";
            this.btnAcceptBet.UseVisualStyleBackColor = true;
            this.btnAcceptBet.Click += new System.EventHandler(this.btnAcceptBet_Click);
            // 
            // frmBetQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(374, 302);
            this.ControlBox = false;
            this.Controls.Add(this.btnAcceptBet);
            this.Controls.Add(this.lblBetText);
            this.Controls.Add(this.txtBet);
            this.Controls.Add(this.lblCategoryText);
            this.Controls.Add(this.lblStartScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmBetQuestion";
            this.Text = "Bet Question";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStartScore;
        private System.Windows.Forms.Label lblCategoryText;
        private System.Windows.Forms.TextBox txtBet;
        private System.Windows.Forms.Label lblBetText;
        private System.Windows.Forms.Button btnAcceptBet;
    }
}