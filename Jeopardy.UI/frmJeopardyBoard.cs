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
        private string sDailyDouble;
        cCategories oCategories;
        cCategory oCategory;

        private int iScore = 0;


        public frmJeopardyBoard(cUser oUser)
        {
            InitializeComponent();

            oCurrentUser = oUser;
            Random rand = new Random();
            sDailyDouble = char.ConvertFromUtf32(rand.Next(65, 70)) + rand.Next(1,6).ToString();
            
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

            // display daily double
            int iQuestNum, iCatNum;
            iCatNum = char.ConvertToUtf32(sDailyDouble, 0) - 65;
            int.TryParse(sDailyDouble[1].ToString(), out iQuestNum);
            iQuestNum--;
            arButtons[iCatNum, iQuestNum].Text = string.Format("{0}, {1}{2}", sDailyDouble, iCatNum, iQuestNum);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnQuestion = (Button)sender;
                string sQuestion = btnQuestion.Name;
                sQuestion = sQuestion.Remove(0, 3);
                //MessageBox.Show(sQuestion);

                // get category of selected question
                switch (sQuestion[0])
                {
                    case 'A':
                        oCategory = oCategories[0];
                        break;
                    case 'B':
                        oCategory = oCategories[1];
                        break;
                    case 'C':
                        oCategory = oCategories[2];
                        break;
                    case 'D':
                        oCategory = oCategories[3];
                        break;
                    case 'E':
                        oCategory = oCategories[4];
                        break;
                    case 'F':
                        oCategory = oCategories[5];
                        break;
                }
                int iQuestID;
                int.TryParse(sQuestion.Remove(0, 1), out iQuestID);

                int iCost;

                // check for daily double
                if (sQuestion == sDailyDouble)
                {
                    // is daily double
                    frmBetQuestion oBetQuestionForm = new frmBetQuestion(oCategories[char.ConvertToUtf32(sQuestion, 0) - 65].Description, oCategory[iQuestID - 1], iScore, false);
                    oBetQuestionForm.ShowDialog();

                    iCost = oBetQuestionForm.Bet;
                }
                else
                {
                    iCost = oCategory[iQuestID - 1].Cost;
                }


                frmQuestion oQuestionForm = new frmQuestion(oCategory[iQuestID - 1], false);
                oQuestionForm.ShowDialog();

                // manage score
                if (oQuestionForm.AnswerState == 0)
                {
                    // didnt answer
                    string sAnswerDescription = oCategory[iQuestID - 1][oCategory[iQuestID - 1].CorrectAnswerID].Description;
                    lblLastQuestion.Text = string.Format("Passed, answer was: {0}", sAnswerDescription);
                }
                else if (oQuestionForm.AnswerState == 1)
                {
                    // answer good
                    iScore += iCost;
                    string sAnswerDescription = oCategory[iQuestID - 1][oCategory[iQuestID - 1].CorrectAnswerID].Description;
                    lblLastQuestion.Text = string.Format("{0} is Correct!", sAnswerDescription);
                }
                else
                {
                    // bad answer
                    iScore -= iCost;
                    string sAnswerDescription = oCategory[iQuestID - 1][oCategory[iQuestID - 1].CorrectAnswerID].Description;
                    lblLastQuestion.Text = string.Format("Incorrect, answer was: {0}", sAnswerDescription);
                }
                lblScore.Text = string.Format("Score: {0}", iScore);

                btnQuestion.Enabled = false;

                if (CheckForEnd())
                {
                    // all questions used, final jeopardy

                    oCategory = new cCategory();
                    oCategory.FillFinal();
                    oCategory.FillCategory();

                    frmBetQuestion oFinalQuestionForm = new frmBetQuestion(oCategory.Description, oCategory[0], iScore, true);
                    oFinalQuestionForm.ShowDialog();

                    iCost = oFinalQuestionForm.Bet;

                    oQuestionForm = new frmQuestion(oCategory[0], true);
                    oQuestionForm.ShowDialog();

                    // manage score
                    if (oQuestionForm.AnswerState == 0)
                    {
                        // didnt answer
                        string sAnswerDescription = oCategory[iQuestID - 1][oCategory[iQuestID - 1].CorrectAnswerID].Description;
                        lblLastQuestion.Text = string.Format("Passed, answer was: {0}", sAnswerDescription);
                    }
                    else if (oQuestionForm.AnswerState == 1)
                    {
                        // answer good
                        iScore += iCost;
                        string sAnswerDescription = oCategory[iQuestID - 1][oCategory[iQuestID - 1].CorrectAnswerID].Description;
                        lblLastQuestion.Text = string.Format("{0} is Correct!", sAnswerDescription);
                    }
                    else
                    {
                        // bad answer
                        iScore -= iCost;
                        string sAnswerDescription = oCategory[iQuestID - 1][oCategory[iQuestID - 1].CorrectAnswerID].Description;
                        lblLastQuestion.Text = string.Format("Incorrect, answer was: {0}", sAnswerDescription);
                    }

                    lblScore.Text = string.Format("Score: {0}", iScore);
                }
            }
        }

        private void frmJeopardyBoard_Load(object sender, EventArgs e)
        {
            // bring in user name
            this.Text = string.Format("Jeopardy - {0}", oCurrentUser.Description.ToString());
            lblLastQuestion.Text = string.Empty;

            // load up categories
            oCategories = new cCategories();
            oCategories.FillCategories();

            // set up labels
            lblA.Text = oCategories[0].Description;
            lblB.Text = oCategories[1].Description;
            lblC.Text = oCategories[2].Description;
            lblD.Text = oCategories[3].Description;
            lblE.Text = oCategories[4].Description;
            lblF.Text = oCategories[5].Description;

            // load questions
            oCategories.LoadQuestions();

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
    }
}
