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

        private bool bAnsweredCorrect;
        public bool AnsweredCorrect
        {
            get { return bAnsweredCorrect; }
           // set { AnsweredCorrect = value; }
        }

        private Button[] arButtons;

        public frmQuestion(cQuestion oQuest)
        {
            InitializeComponent();

            oCurrentQuestion = oQuest;
            oQuest.FillQuestion();

            arButtons = new Button[4];
            arButtons[0] = btn1;
            arButtons[1] = btn2;
            arButtons[2] = btn4;
            arButtons[3] = btn3;
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnAnswer = (Button)sender;
                int iAnswer;
                int.TryParse(btnAnswer.Name.Remove(0,3), out iAnswer);

                bAnsweredCorrect = oCurrentQuestion.Items[iAnswer-1].IsCorrect;
            }
            this.Close();
        }
    }
}
