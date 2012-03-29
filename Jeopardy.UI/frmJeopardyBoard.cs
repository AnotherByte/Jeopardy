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
        private cGame oGame;


        public frmJeopardyBoard(cUser oUser)
        {
            InitializeComponent();
            
            oGame = new cGame(oUser, 2);        // <--- NUMBER OF ROUNDS
            oGame.NewRound();

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

            #endregion

            // bring in user name
            this.Text = string.Format("Jeopardy - {0}", oGame.UserName);
            lblLastQuestion.Text = string.Empty;

            NewRound();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnQuestion = (Button)sender;
                string sIndex = btnQuestion.Tag.ToString();
                int iCost;

                // check for daily double
                if (oGame.IsQuestionDailyDouble(sIndex))
                {
                    // is daily double
                    frmBetQuestion oBetQuestionForm = new frmBetQuestion(oGame.GetCatDescription(sIndex[0]), oGame.GetQuestion(sIndex), oGame.Score, false);
                    oBetQuestionForm.ShowDialog();

                    iCost = oBetQuestionForm.Bet;
                }
                else
                {
                    iCost = oGame.GetCost(sIndex);
                }

                frmQuestion oQuestionForm = new frmQuestion(oGame.GetQuestion(sIndex), iCost, false);
                oQuestionForm.ShowDialog();

                // manage score
                lblLastQuestion.Text = oGame.GetAnswerState(sIndex, oQuestionForm.AnswerIndex, iCost);
                lblScore.Text = string.Format("Score: {0}", oGame.Score);

                btnQuestion.Enabled = false;
            }

            if (CheckForEnd())
            {
                EndRound();
            }
        }

        private bool CheckForEnd()  // true if game over
        {
            bool end = true;    // set that game is over

            foreach (Button btn in arButtons)
            {
                if (btn.Enabled)
                {
                    // button/question not yet used
                    end = false;    // game not over yet
                }
            }
            return end;
        }

        private void EndRound()  // quick round end for demo
        {
            if (oGame.EndGame())
            {
                // final jeopardy
                cCategory oCategory = oGame.FinalJeopardy();

                frmBetQuestion oFinalQuestionForm = new frmBetQuestion(oCategory.Description, oCategory[0], oGame.Score, true);
                oFinalQuestionForm.ShowDialog();

                int iCost = oFinalQuestionForm.Bet;

                frmQuestion oQuestionForm = new frmQuestion(oCategory[0], iCost, true);
                oQuestionForm.ShowDialog();

                // manage score
                lblLastQuestion.Text = oGame.GetFinalAnswerState(oQuestionForm.AnswerIndex, iCost);
                lblScore.Text = string.Format("Score: {0}", oGame.Score);
            }
            else
            {
                // new round
                NewRound();
            }
        }

        private void NewRound()
        {
            oGame.NewRound();

            // set up labels
            lblA.Text = oGame.GetCatDescription(0);
            lblB.Text = oGame.GetCatDescription(1);
            lblC.Text = oGame.GetCatDescription(2);
            lblD.Text = oGame.GetCatDescription(3);
            lblE.Text = oGame.GetCatDescription(4);
            lblF.Text = oGame.GetCatDescription(5);

            // label buttons
            for (int x = 0; x < 6; x++)         // x is cat
            {
                for (int y = 0; y < 5; y++)     // y is ques
                {
                    string sIndex = string.Format("{0}{1}", x, y);
                    if (oGame.IsQuestionDailyDouble(sIndex))
                    {
                        // label daily double
                        arButtons[x, y].Text = sIndex;
                    }
                    else
                    {
                        arButtons[x, y].Text = string.Format("${0}", oGame.GetCost(sIndex));
                    }
                }
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            EndRound();
        }
    }
}
