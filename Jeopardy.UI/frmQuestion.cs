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
    public partial class frmQuestion : Form
    {
        private cQuestion oCurrentQuestion;
        public int iCorrectAnswerID;
        public int iChosenAnswerID = 0;

        private Button[] arButtons;

        public frmQuestion(cQuestion oQuest)
        {
            InitializeComponent();

            oCurrentQuestion = oQuest;
            oQuest.FillQuestion();
            iCorrectAnswerID = oQuest.CorrectAnswerID;

            arButtons = new Button[4];
            arButtons[0] = btnA;
            arButtons[1] = btnB;
            arButtons[2] = btnC;
            arButtons[3] = btnD;
        }

        private void frmQuestion_Load(object sender, EventArgs e)
        {
            lblDescription.Text = oCurrentQuestion.Description;

            for (int x = 0; x < oCurrentQuestion.Items.Count; x++ )
            {
                arButtons[x].Text = oCurrentQuestion.Items[x].Description;
            }

            tmrClock.Start();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            tmrClock.Stop();
            this.Close();
        }
    }
}
