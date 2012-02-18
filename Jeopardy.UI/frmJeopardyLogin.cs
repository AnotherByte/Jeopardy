using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jeopardy.BL;

namespace Jeopardy.UI
{
    public partial class frmJeopardyLogin : Form
    {
        public frmJeopardyLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cCategories oCategories = new cCategories();
            oCategories.FillCategories();

            for (int x = 0; x < oCategories.Count(); x++)
            {
                lstUsers.Items.Add(oCategories.Items[x].Description.ToString());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmJeopardyBoard oBoard = new frmJeopardyBoard();
            oBoard.ShowDialog();
        }
    }
}
