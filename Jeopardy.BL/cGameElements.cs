using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Jeopardy.DL;

namespace Jeopardy.BL
{
    // class for GROUP of categories
    public class cCategories
    {

        #region properties

        private List<cCategory> mcol;
        public List<cCategory> Items
        {
            get { return mcol; }
            //set { mcol = value; }
        }

        private cCategory tempCategory;

        #endregion

        // constructor
        public cCategories()
        {
            mcol = new List<cCategory>();
            tempCategory = new cCategory();
        }

        // add given cCategory to collection
        private void Add(cCategory newCategory)
        {
            mcol.Add(newCategory);
        }

        // return number of items in collection
        public int Count()
        {
            return mcol.Count;
        }

        // get category from category_id (null if not found)
        public cCategory Item(int vsCatID)
        {
            tempCategory = null;
            foreach (cCategory oCat in mcol)
            {
                if (oCat.ID == vsCatID)
                {
                    tempCategory = oCat;
                }
            }
            return tempCategory;
        }

        // remove Customer at index
        public bool Remove(int viIndex)
        {
            mcol.RemoveAt(viIndex);
            return true;
        }

        // gets datatable from DB and fills collection with UNUSED single jeopardy categories
        public void FillCategories()
        {
            // get list of #'s of unused categories
            List<int> iIDs = DBAccess.UnusedCategoryList();

            // remove if too many
            Random rand = new Random();
            while (iIDs.Count > 6)
            {
                iIDs.RemoveAt(rand.Next(0, iIDs.Count - 1));
            }
            rand = null;

            // biuld string of id's for sql
            string sIDs = "";
            foreach (int i in iIDs)
            {
                sIDs += string.Format("{0}, ", i);
            }
            sIDs = sIDs.Remove(sIDs.Length - 2);


            // get datatable
            DataTable dtCategory = DBAccess.GetCategory(sIDs);

            foreach (DataRow dr in dtCategory.Rows)
            {
                cCategory oCategory = new cCategory();
                oCategory.Load(dr);
                this.Add(oCategory);
            }
        }
    }

    // class for a category, contains questions
    public class cCategory
    {
        #region properties

            private int iID;
            public int ID
            {
                get { return iID; }
                set { iID = value; }
            }

            private bool bIsFinal;
            public bool IsFinal
            {
                get { return bIsFinal; }
                set { bIsFinal = value; }
            }

            private string sDescription;
            public string Description
            {
                get { return sDescription; }
                set { sDescription = value; }
            }

            private bool bUsed;
            public bool Used
            {
                get { return bUsed; }
                set { bUsed = value; }
            }


            private List<cQuestion> mcol;
            public List<cQuestion> Items
            {
                get { return mcol; }
                //set { mcol = value; }
            }

            private cQuestion tempQuestion;

        #endregion

        // constructor
        public cCategory()
        {
            mcol = new List<cQuestion>();
            tempQuestion = new cQuestion();
        }

        // load category from dr
        public void Load(DataRow oDR)
        {
            try
            {
                int.TryParse(oDR["category_id"].ToString(), out iID);
                bool.TryParse(oDR["category_is_final"].ToString(), out bIsFinal);
                sDescription = oDR["category_description"].ToString();
                bool.TryParse(oDR["category_used"].ToString(), out bUsed);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        // add given question to collection
        private void Add(cQuestion newQuestion)
        {
            mcol.Add(newQuestion);
        }

        // return number of items in collection
        public int Count()
        {
            return mcol.Count;
        }

        // fill with final jeopardy question
        public void FillFinal()
        {
            this.Load(DBAccess.GetFinalCategory().Rows[0]);
        }

        // get quetion from question_id (null if not found)
        public cQuestion Item(int vsQuestID)
        {
            tempQuestion = null;
            foreach (cQuestion oQuest in mcol)
            {
                if (oQuest.ID == vsQuestID)
                {
                    tempQuestion = oQuest;
                }
            }
            return tempQuestion;
        }

        // remove quetion at index
        public bool Remove(int viIndex)
        {
            mcol.RemoveAt(viIndex);
            return true;
        }

        // gets datatable from DB and fills collection
        public void FillCategory()
        {
            DataTable dtCategory = DBAccess.GetQuestions(this.ID.ToString());

            foreach (DataRow dr in dtCategory.Rows)
            {
                cQuestion oQuestion = new cQuestion();
                oQuestion.Load(dr);
                this.Add(oQuestion);
            }
        }
    }

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

            private int iCatID;
            public int CatID
            {
                get { return iCatID; }
                set { iCatID = value; }
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
            public List<cAnswer> Items
            {
                get { return mcol; }
                //set { mcol = value; }
            }

            private cAnswer tempAnswer;

        #endregion

        // constructor
        public cQuestion()
        {
            mcol = new List<cAnswer>();
            tempAnswer = new cAnswer();
        }

        // load question from dr
        public void Load(DataRow oDR)
        {
            try
            {
                int.TryParse(oDR["question_id"].ToString(), out iID);
                int.TryParse(oDR["category_id"].ToString(), out iCatID);
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

        // return number of items in collection
        public int Count()
        {
            return mcol.Count;
        }

        // get answer from answer_id (null if not found)
        public cAnswer Item(int vsAnsID)
        {
            tempAnswer = null;
            foreach (cAnswer oAns in mcol)
            {
                if (oAns.ID == vsAnsID)
                {
                    tempAnswer = oAns;
                }
            }
            return tempAnswer;
        }

        // remove answer at index
        public bool Remove(int viIndex)
        {
            mcol.RemoveAt(viIndex);
            return true;
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
                    this.CorrectAnswerID = this.Items.Count - 1;
                }
            }
        }
    }

    // class for an answer, belongs to a question
    public class cAnswer
    {
        #region properties

        private int iID;
        public int ID
        {
            get { return iID; }
            set { iID = value; }
        }

        private int iQuestID;
        public int QuestID
        {
            get { return iQuestID; }
            set { iQuestID = value; }
        }

        private string sDescription;
        public string Description
        {
            get { return sDescription; }
            set { sDescription = value; }
        }

        private bool bIsCorrect;
        public bool IsCorrect
        {
            get { return bIsCorrect; }
            set { bIsCorrect = value; }
        }

        #endregion

        // load answer from dr
        public void Load(DataRow oDR)
        {
            try
            {
                int.TryParse(oDR["answer_id"].ToString(), out iID);
                int.TryParse(oDR["question_id"].ToString(), out iQuestID);
                sDescription = oDR["answer_description"].ToString();
                bool.TryParse(oDR["answer_is_correct"].ToString(), out bIsCorrect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
