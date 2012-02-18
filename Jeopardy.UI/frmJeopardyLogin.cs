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
            cCategory Category = new cCategory();

            Category.FillUsers();
            dataGridView1.DataSource = Category.users;
        }
    }
}
