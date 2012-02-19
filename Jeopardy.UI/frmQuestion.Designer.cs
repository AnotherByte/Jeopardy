namespace Jeopardy.UI
{
    partial class frmQuestion
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
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnA
            // 
            this.btnA.BackColor = System.Drawing.SystemColors.Control;
            this.btnA.Location = new System.Drawing.Point(80, 255);
            this.btnA.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(145, 70);
            this.btnA.TabIndex = 0;
            this.btnA.Text = "button1";
            this.btnA.UseVisualStyleBackColor = false;
            // 
            // btnB
            // 
            this.btnB.BackColor = System.Drawing.SystemColors.Control;
            this.btnB.Location = new System.Drawing.Point(258, 255);
            this.btnB.Margin = new System.Windows.Forms.Padding(6);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(145, 70);
            this.btnB.TabIndex = 1;
            this.btnB.Text = "button2";
            this.btnB.UseVisualStyleBackColor = false;
            // 
            // btnD
            // 
            this.btnD.BackColor = System.Drawing.SystemColors.Control;
            this.btnD.Location = new System.Drawing.Point(80, 356);
            this.btnD.Margin = new System.Windows.Forms.Padding(6);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(145, 70);
            this.btnD.TabIndex = 3;
            this.btnD.Text = "button3";
            this.btnD.UseVisualStyleBackColor = false;
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.SystemColors.Control;
            this.btnC.Location = new System.Drawing.Point(258, 356);
            this.btnC.Margin = new System.Windows.Forms.Padding(6);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(145, 70);
            this.btnC.TabIndex = 2;
            this.btnC.Text = "button4";
            this.btnC.UseVisualStyleBackColor = false;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.SlateGray;
            this.lblDescription.ForeColor = System.Drawing.Color.Snow;
            this.lblDescription.Location = new System.Drawing.Point(80, 25);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(323, 192);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "label1";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(482, 451);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmQuestion";
            this.Text = "frmQuestion";
            this.Load += new System.EventHandler(this.frmQuestion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Label lblDescription;
    }
}