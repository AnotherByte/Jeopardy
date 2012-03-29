namespace Jeopardy.UI
{
    partial class frmJeopardyLogin
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
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnInputForm = new System.Windows.Forms.Button();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(26, 54);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(227, 121);
            this.lstUsers.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(26, 12);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnInputForm
            // 
            this.btnInputForm.Location = new System.Drawing.Point(178, 12);
            this.btnInputForm.Name = "btnInputForm";
            this.btnInputForm.Size = new System.Drawing.Size(75, 23);
            this.btnInputForm.TabIndex = 4;
            this.btnInputForm.Text = "DB Stuff";
            this.btnInputForm.UseVisualStyleBackColor = true;
            this.btnInputForm.Click += new System.EventHandler(this.btnInputForm_Click);
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(139, 194);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(114, 20);
            this.txtNewName.TabIndex = 5;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(26, 192);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 23);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "Add New User";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmJeopardyLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 248);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.btnInputForm);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lstUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmJeopardyLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jeopardy Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnInputForm;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Button btnNew;
    }
}

