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

        public frmBetQuestion()
        {
        }

        public frmBetQuestion(string vsDescription, cQuestion voQuestion, int viScore, bool vbIsFinal)
        {
            InitializeComponent();

            lblCategoryText.Text = vsDescription;

            bFinal = vbIsFinal;
            oQuestion = voQuestion;

            iUserScore = viScore;
            lblStartScore.Text = string.Format( "Current Score: {0}", iUserScore);

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
            int.TryParse(txtBet.Text, out iBet);

            if (iBet <= iUserScore || iBet == 1000)
            {
                Close();
            }
            else
            {
                lblBetText.ForeColor = Color.Red;
                lblBetText.Text = string.Format("Must bet ${0}, less than ${0}, or $1000", iUserScore);
            }
        }
    }
}
