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

        private int iAnswerState;
        public int AnswerState
        {
            get { return iAnswerState; }
           // set { AnsweredCorrect = value; }
        }
        private Button[] arButtons;

        public frmQuestion(cQuestion oQuest, bool bFinal)
        {
            InitializeComponent();

            oCurrentQuestion = oQuest;
            btnPass.Visible = bFinal;

            arButtons = new Button[4];
            arButtons[0] = btn1;
            arButtons[1] = btn2;
            arButtons[2] = btn3;
            arButtons[3] = btn4;
        }

        private void frmQuestion_Load(object sender, EventArgs e)
        {
            oCurrentQuestion.FillQuestion();
            this.Text = string.Format("${0} Question", oCurrentQuestion.Cost);
            lblDescription.Text = oCurrentQuestion.Description;

            for (int x = 0; x < 4; x++ )
            {
                arButtons[x].Text = oCurrentQuestion[x].Description;
            }

            tmrClock.Start();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            tmrClock.Stop();
            //this.Close();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnAnswer = (Button)sender;

                if (btnAnswer.Name.Remove(0, 3) == "Pass")
                {
                    iAnswerState = 0;
                }
                else if (btnAnswer.Name.Remove(0, 3) == oCurrentQuestion.CorrectAnswerID.ToString())
                {
                    iAnswerState = 1;
                }
                else
                {
                    iAnswerState = -1;
                }
            }
            this.Close();
        }
    }
}
