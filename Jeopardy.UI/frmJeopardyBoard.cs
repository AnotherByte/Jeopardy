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
    public partial class frmJeopardyBoard : Form
    {
        private Button[,] arButtons;
        private cUser oCurrentUser;
        cCategories oCategories;


        public frmJeopardyBoard(cUser oUser)
        {
            InitializeComponent();

            oCurrentUser = oUser;

            #region button array

            // create array for buttons
            arButtons = new Button[6, 5];

            // fill array
            arButtons[0, 0] = btnA1;
            arButtons[0, 1] = btnA2;
            arButtons[0, 2] = btnA3;
            arButtons[0, 3] = btnA4;
            arButtons[0, 4] = btnA5;

            arButtons[1, 0] = btnB1;
            arButtons[1, 1] = btnB2;
            arButtons[1, 2] = btnB3;
            arButtons[1, 3] = btnB4;
            arButtons[1, 4] = btnB5;

            arButtons[2, 0] = btnC1;
            arButtons[2, 1] = btnC2;
            arButtons[2, 2] = btnC3;
            arButtons[2, 3] = btnC4;
            arButtons[2, 4] = btnC5;

            arButtons[3, 0] = btnD1;
            arButtons[3, 1] = btnD2;
            arButtons[3, 2] = btnD3;
            arButtons[3, 3] = btnD4;
            arButtons[3, 4] = btnD5;

            arButtons[4, 0] = btnE1;
            arButtons[4, 1] = btnE2;
            arButtons[4, 2] = btnE3;
            arButtons[4, 3] = btnE4;
            arButtons[4, 4] = btnE5;

            arButtons[5, 0] = btnF1;
            arButtons[5, 1] = btnF2;
            arButtons[5, 2] = btnF3;
            arButtons[5, 3] = btnF4;
            arButtons[5, 4] = btnF5;

            // label buttons
            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    arButtons[x,y].Text = string.Format("${0}", ((y+1)*200));
                }
            }

            #endregion
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnQuestion = (Button)sender;
                string sQuestion = btnQuestion.Name;
                sQuestion = sQuestion.Remove(0, 3);
                //MessageBox.Show(sQuestion);

            }
        }

        private void frmJeopardyBoard_Load(object sender, EventArgs e)
        {
            // bring in user name
            this.Text = string.Format("Jeopardy - {0}", oCurrentUser.Description.ToString());

            // load up categories
            oCategories = new cCategories();
            oCategories.FillCategories();

            // set up labels
            lblA.Text = oCategories.Items[0].Description;
            lblB.Text = oCategories.Items[1].Description;
            lblC.Text = oCategories.Items[2].Description;
            lblD.Text = oCategories.Items[3].Description;
            lblE.Text = oCategories.Items[4].Description;
            lblF.Text = oCategories.Items[5].Description;

        }
    }
}
