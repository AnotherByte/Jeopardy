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
    public partial class frmBetQuestion : Form
    {
        private int iUserScore;
        public int UserScore
        {
            get { return iUserScore; }
            //set { iUserScore = value; }
        }

        private int iBet;
        public int Bet
        {
            get { return iBet; }
            //set { iBet = value; }
        }

        private bool bFinal;
        private cQuestion oQuestion;


        public frmBetQuestion(string vsCatDescription, cQuestion voQuestion, int viScore, bool vbIsFinal)
        {
            InitializeComponent();

            lblCategoryText.Text = vsCatDescription;

            bFinal = vbIsFinal;
            oQuestion = voQuestion;

            iUserScore = viScore;
            lblStartScore.Text = string.Format( "Current Score: {0}", iUserScore);

            if (iUserScore <= 0)
            {
                lblBetText.Text = "You don't have any money.\nYou can bet $1000 or $0.";
            }

            if (bFinal)
            {
                this.Text = "Final Jeopardy";
            }
            else
            {
                this.Text = "Daily Double";
            }
        }

        private void btnAcceptBet_Click(object sender, EventArgs e)
        {
            if (iUserScore > 0 && int.TryParse(txtBet.Text, out iBet) && iBet <= iUserScore && iBet >= 0)
            {
                // has money
                // valid input
                Close();
            }
            else if (iUserScore <= 0 && int.TryParse(txtBet.Text, out iBet) && ( iBet == 1000 || iBet == 0 ))
            {
                // no money
                // valid input
                Close();
            }
            else if (iUserScore > 0)
            {
                // invaild input
                lblBetText.ForeColor = Color.Red;
                lblBetText.Text = string.Format("Must bet ${0} or less (bet must be positive).", iUserScore);
            }
            else
            {
                // invaild input
                lblBetText.ForeColor = Color.Red;
                lblBetText.Text = string.Format("Must bet $1000 or $0.");
            }
        }
    }
}
