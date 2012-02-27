namespace Jeopardy.Input
{
    partial class frmInput
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtAID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAQID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtADescription = new System.Windows.Forms.TextBox();
            this.chkACorrect = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkCUsed = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCID = new System.Windows.Forms.TextBox();
            this.chkCFinal = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQCID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQCost = new System.Windows.Forms.TextBox();
            this.btnAddCat = new System.Windows.Forms.Button();
            this.btnAddQuest = new System.Windows.Forms.Button();
            this.btnAddAns = new System.Windows.Forms.Button();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.slblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Answer ID";
            // 
            // txtAID
            // 
            this.txtAID.Location = new System.Drawing.Point(133, 29);
            this.txtAID.Name = "txtAID";
            this.txtAID.Size = new System.Drawing.Size(46, 20);
            this.txtAID.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.btnAddAns);
            this.groupBox1.Controls.Add(this.chkACorrect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtADescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAQID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAID);
            this.groupBox1.Location = new System.Drawing.Point(12, 349);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 158);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Answer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Question ID";
            // 
            // txtAQID
            // 
            this.txtAQID.Location = new System.Drawing.Point(133, 55);
            this.txtAQID.Name = "txtAQID";
            this.txtAQID.Size = new System.Drawing.Size(46, 20);
            this.txtAQID.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Answer Description";
            // 
            // txtADescription
            // 
            this.txtADescription.Location = new System.Drawing.Point(133, 81);
            this.txtADescription.Name = "txtADescription";
            this.txtADescription.Size = new System.Drawing.Size(251, 20);
            this.txtADescription.TabIndex = 6;
            // 
            // chkACorrect
            // 
            this.chkACorrect.AutoSize = true;
            this.chkACorrect.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkACorrect.Location = new System.Drawing.Point(41, 107);
            this.chkACorrect.Name = "chkACorrect";
            this.chkACorrect.Size = new System.Drawing.Size(109, 17);
            this.chkACorrect.TabIndex = 7;
            this.chkACorrect.Text = "Answer Is Correct";
            this.chkACorrect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkACorrect.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.btnAddCat);
            this.groupBox2.Controls.Add(this.chkCFinal);
            this.groupBox2.Controls.Add(this.chkCUsed);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCDescription);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCID);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 167);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Category";
            // 
            // chkCUsed
            // 
            this.chkCUsed.AutoSize = true;
            this.chkCUsed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCUsed.Location = new System.Drawing.Point(54, 107);
            this.chkCUsed.Name = "chkCUsed";
            this.chkCUsed.Size = new System.Drawing.Size(96, 17);
            this.chkCUsed.TabIndex = 7;
            this.chkCUsed.Text = "Category Used";
            this.chkCUsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCUsed.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Category Description";
            // 
            // txtCDescription
            // 
            this.txtCDescription.Location = new System.Drawing.Point(133, 81);
            this.txtCDescription.Name = "txtCDescription";
            this.txtCDescription.Size = new System.Drawing.Size(251, 20);
            this.txtCDescription.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "CategoryID";
            // 
            // txtCID
            // 
            this.txtCID.Location = new System.Drawing.Point(133, 29);
            this.txtCID.Name = "txtCID";
            this.txtCID.Size = new System.Drawing.Size(46, 20);
            this.txtCID.TabIndex = 2;
            // 
            // chkCFinal
            // 
            this.chkCFinal.AutoSize = true;
            this.chkCFinal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCFinal.Location = new System.Drawing.Point(46, 55);
            this.chkCFinal.Name = "chkCFinal";
            this.chkCFinal.Size = new System.Drawing.Size(104, 17);
            this.chkCFinal.TabIndex = 8;
            this.chkCFinal.Text = "Category Is Final";
            this.chkCFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCFinal.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox3.Controls.Add(this.btnAddQuest);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtQCost);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtQDescription);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtQCID);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtQID);
            this.groupBox3.Location = new System.Drawing.Point(12, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 158);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Question";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Question Description";
            // 
            // txtQDescription
            // 
            this.txtQDescription.Location = new System.Drawing.Point(133, 81);
            this.txtQDescription.Name = "txtQDescription";
            this.txtQDescription.Size = new System.Drawing.Size(251, 20);
            this.txtQDescription.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Category ID";
            // 
            // txtQCID
            // 
            this.txtQCID.Location = new System.Drawing.Point(133, 55);
            this.txtQCID.Name = "txtQCID";
            this.txtQCID.Size = new System.Drawing.Size(46, 20);
            this.txtQCID.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Question ID";
            // 
            // txtQID
            // 
            this.txtQID.Location = new System.Drawing.Point(133, 29);
            this.txtQID.Name = "txtQID";
            this.txtQID.Size = new System.Drawing.Size(46, 20);
            this.txtQID.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Question Cost";
            // 
            // txtQCost
            // 
            this.txtQCost.Location = new System.Drawing.Point(133, 107);
            this.txtQCost.Name = "txtQCost";
            this.txtQCost.Size = new System.Drawing.Size(46, 20);
            this.txtQCost.TabIndex = 8;
            // 
            // btnAddCat
            // 
            this.btnAddCat.Location = new System.Drawing.Point(309, 122);
            this.btnAddCat.Name = "btnAddCat";
            this.btnAddCat.Size = new System.Drawing.Size(75, 23);
            this.btnAddCat.TabIndex = 9;
            this.btnAddCat.Text = "Add";
            this.btnAddCat.UseVisualStyleBackColor = true;
            this.btnAddCat.Click += new System.EventHandler(this.btnAddCat_Click);
            // 
            // btnAddQuest
            // 
            this.btnAddQuest.Location = new System.Drawing.Point(309, 120);
            this.btnAddQuest.Name = "btnAddQuest";
            this.btnAddQuest.Size = new System.Drawing.Size(75, 23);
            this.btnAddQuest.TabIndex = 10;
            this.btnAddQuest.Text = "Add";
            this.btnAddQuest.UseVisualStyleBackColor = true;
            this.btnAddQuest.Click += new System.EventHandler(this.btnAddQuest_Click);
            // 
            // btnAddAns
            // 
            this.btnAddAns.Location = new System.Drawing.Point(309, 119);
            this.btnAddAns.Name = "btnAddAns";
            this.btnAddAns.Size = new System.Drawing.Size(75, 23);
            this.btnAddAns.TabIndex = 11;
            this.btnAddAns.Text = "Add";
            this.btnAddAns.UseVisualStyleBackColor = true;
            this.btnAddAns.Click += new System.EventHandler(this.btnAddAns_Click);
            // 
            // stsMain
            // 
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblStatus});
            this.stsMain.Location = new System.Drawing.Point(0, 526);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(553, 22);
            this.stsMain.TabIndex = 9;
            this.stsMain.Text = "statusStrip1";
            // 
            // slblStatus
            // 
            this.slblStatus.Name = "slblStatus";
            this.slblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(454, 63);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(553, 548);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmInput";
            this.Text = "Input Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddAns;
        private System.Windows.Forms.CheckBox chkACorrect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtADescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAQID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddCat;
        private System.Windows.Forms.CheckBox chkCFinal;
        private System.Windows.Forms.CheckBox chkCUsed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddQuest;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQCID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQID;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel slblStatus;
        private System.Windows.Forms.Button btnClear;
    }
}

