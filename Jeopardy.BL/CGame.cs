using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeopardy.DL;

namespace Jeopardy.BL
{
    public class cGame
    {
        #region properties

        private cUser oUser;
        public string UserName
        {
            get { return oUser.Description; }
        }

        private int GameID;


        private cCategory oFinalCategory;

        private int iScore;
        public int Score
        {
            get { return iScore; }
        }

        private int iNumberOfRounds;

        private string sUsedIDs;

        private List<cRound> mcol;
        private cRound CurrentRound
        {
            get { return mcol[mcol.Count - 1]; }
        }

        #endregion

        // constructor
        public cGame(cUser voUser, int viNumberOfRounds)
        {
            mcol = new List<cRound>();
            oUser = voUser;
            iNumberOfRounds = viNumberOfRounds;

        }


        public void NewRound()
        {
            cRound oRound = new cRound(mcol.Count + 1, sUsedIDs);
            oRound.FillRound();

            if (sUsedIDs == null)
            {
                sUsedIDs = oRound.UsedIDs;
            }
            else
            {
                sUsedIDs += ", " + oRound.UsedIDs;
            }

            mcol.Add(oRound);
        }

        // true = time for final jeopardy, false = new round
        public bool EndGame()
        {
            return mcol.Count == iNumberOfRounds;
        }


        public bool IsQuestionDailyDouble(string vsIndex)
        {
            return (this.CurrentRound.DailyDouble == vsIndex);
        }

        public int GetCost(string vsIndex)
        {
            return CurrentRound.GetCost(vsIndex);
        }

        private void ChangeScore(int viAmountChanged)
        {
            CurrentRound.Score += viAmountChanged;

            iScore = 0;
            foreach (cRound oR in mcol)
            {
                iScore += oR.Score;
            }
        }

        public string GetCatDescription(char vcIndex)
        {
            int iCat = vcIndex - 48;
            return CurrentRound[iCat].Description;
        }
        public string GetCatDescription(int vIndex)
        {
            return CurrentRound[vIndex].Description;
        }

        public cQuestion GetQuestion(string vsIndex)
        {
            int iCat = vsIndex[0] - 48;
            int iQue = vsIndex[1] - 48;
            return CurrentRound[iCat][iQue];
        }


        public string GetAnswerState(string vsIndex, int iAnswerIndex, int viCost)
        {
            string sAnswerState;
            int iCat = vsIndex[0] - 48;
            int iQue = vsIndex[1] - 48;

            if (iAnswerIndex == -1)
            {
                // didnt answer
                string sAnswerDescription = GetCorrectAnsDescription(iCat, iQue);
                sAnswerState = string.Format("Passed, answer was: {0}", sAnswerDescription);
            }
            else if (iAnswerIndex == CurrentRound[iCat][iQue].CorrectAnswerIndex)
            {
                // answer good
                ChangeScore(viCost);
                string sAnswerDescription = GetCorrectAnsDescription(iCat, iQue);
                sAnswerState = string.Format("{0} is Correct!", sAnswerDescription);
            }
            else
            {
                // bad answer
                ChangeScore(-1 * viCost);
                string sAnswerDescription1 = GetAnsDescription(iCat, iQue, iAnswerIndex);
                string sAnswerDescription2 = GetCorrectAnsDescription(iCat, iQue);
                sAnswerState = string.Format("{0} is incorrect, answer was: {1}", sAnswerDescription1, sAnswerDescription2);
            }

            return sAnswerState;
        }

        private string GetAnsDescription(int iCat, int iQue, int viAnsIndex)
        {
            cQuestion oQuestion = CurrentRound[iCat][iQue];
            return oQuestion[viAnsIndex].Description;
        }

        private string GetCorrectAnsDescription(int iCat, int iQue)
        {
            int iCorrectIndex = CurrentRound[iCat][iQue].CorrectAnswerIndex;
            return GetAnsDescription(iCat, iQue, iCorrectIndex);
        }


        public cCategory FinalJeopardy()
        {
            // all questions used, final jeopardy

            oFinalCategory = new cCategory();
            oFinalCategory.FillFinal();

            return oFinalCategory;
        }
        
        public string GetFinalAnswerState(int iAnswerIndex, int viCost)
        {
            string sAnswerState;

            if (iAnswerIndex == -1)
            {
                // didnt answer
                string sAnswerDescription = oFinalCategory[0][oFinalCategory[0].CorrectAnswerIndex].Description;
                sAnswerState = string.Format("Passed, answer was: {0}", sAnswerDescription);
            }
            else if (iAnswerIndex == oFinalCategory[0].CorrectAnswerIndex)
            {
                // answer good
                ChangeScore(viCost);
                string sAnswerDescription = oFinalCategory[0][oFinalCategory[0].CorrectAnswerIndex].Description;
                sAnswerState = string.Format("{0} is Correct!", sAnswerDescription);
            }
            else
            {
                // bad answer
                ChangeScore(-1 * viCost);
                string sAnswerDescription1 = oFinalCategory[0][iAnswerIndex].Description;
                string sAnswerDescription2 = oFinalCategory[0][oFinalCategory[0].CorrectAnswerIndex].Description;
                sAnswerState = string.Format("{0} is incorrect, answer was: {1}", sAnswerDescription1, sAnswerDescription2);
            }

            return sAnswerState;
        }

        public void Save()
        {
            // add game in db
            GameID = DBAccess.SaveGame(oUser.ID);

            // add round in db
            foreach (cRound oRound in mcol)
            {
                oRound.Save(GameID);
            }

            // add to score
            iScore += DBAccess.GetHighScore(oUser.ID);
            DBAccess.SetHighScore(iScore, oUser.ID);
        }

    }
}
