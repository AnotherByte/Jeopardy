using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jeopardy.BL;
using Jeopardy.Input;

namespace Jeopardy.UI
{
    public partial class frmJeopardyLogin : Form
    {
        private cUsers oUsers;

        public frmJeopardyLogin()
        {
            InitializeComponent();

            LoadList();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (lstUsers.SelectedIndex >= 0)
            {
                frmJeopardyBoard oBoard = new frmJeopardyBoard(oUsers.Items[lstUsers.SelectedIndex]);
                this.Hide();
                oBoard.ShowDialog();

                if (oBoard.GameState)
                {
                    btnLogin_Click(sender, e);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnInputForm_Click(object sender, EventArgs e)
        {
            frmInput oInputForm = new frmInput();
            this.Hide();
            oInputForm.ShowDialog();
            this.Close();
        }

        private void LoadList()
        {
            oUsers = new cUsers();
            oUsers.FillUsers();

            foreach (cUser oUser in oUsers.Items)
            {
                lstUsers.DataSource = oUsers.Items;
                lstUsers.DisplayMember = "Display";
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtNewName.Text != "")
            {
                cUser oUser = new cUser();
                oUser.New(txtNewName.Text);

                LoadList();
            }
        }
    }
}
