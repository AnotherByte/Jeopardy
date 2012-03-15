using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Jeopardy.DL;

namespace Jeopardy.BL
{
    // class for a question, belongs to a category, contains answers
    public class cQuestion
    {
        #region properties

        private int iID;
        public int ID
        {
            get { return iID; }
            set { iID = value; }
        }

        private string sDescription;
        public string Description
        {
            get { return sDescription; }
            set { sDescription = value; }
        }

        private int iCost;
        public int Cost
        {
            get { return iCost; }
            set { iCost = value; }
        }

        private int iCorrectAnswerID;
        public int CorrectAnswerID
        {
            get { return iCorrectAnswerID; }
            set { iCorrectAnswerID = value; }
        }


        private List<cAnswer> mcol;
        public cAnswer this[int index]
        {
            get { return mcol[index]; }
            //set { mcol = value; }
        }

        #endregion

        // constructor
        public cQuestion()
        {
            mcol = new List<cAnswer>();
        }

        // load question from dr
        public void Load(DataRow oDR)
        {
            try
            {
                int.TryParse(oDR["question_id"].ToString(), out iID);
                sDescription = oDR["question_description"].ToString();
                int.TryParse(oDR["question_cost"].ToString(), out iCost);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // add given cAnswer to collection
        private void Add(cAnswer newAnswer)
        {
            mcol.Add(newAnswer);
        }

        // gets datatable from DB and fills collection
        public void FillQuestion()
        {
            DataTable dtQuestion = DBAccess.GetAnswers(this.ID.ToString());

            foreach (DataRow dr in dtQuestion.Rows)
            {
                cAnswer oAnswer = new cAnswer();
                oAnswer.Load(dr);
                this.Add(oAnswer);

                // check if correct answer
                if (oAnswer.IsCorrect)
                {
                    this.CorrectAnswerID = this.mcol.Count - 1;
                }
            }
        }
    }
}
