using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Jeopardy.DL;

namespace Jeopardy.BL
{
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

        //private bool bIsFinal;
        //public bool IsFinal
        //{
        //    get { return bIsFinal; }
        //    set { bIsFinal = value; }
        //}

        private string sDescription;
        public string Description
        {
            get { return sDescription; }
            set { sDescription = value; }
        }

        private List<cQuestion> mcol;
        public cQuestion this[int index]
        {
            get { return mcol[index]; }
            //set { mcol = value; }
        }

        #endregion

        // constructor
        public cCategory()
        {
            mcol = new List<cQuestion>();
        }

        // load category from dr
        public void Load(DataRow oDR)
        {
            try
            {
                int.TryParse(oDR["category_id"].ToString(), out iID);
                //bool.TryParse(oDR["category_is_final"].ToString(), out bIsFinal);
                sDescription = oDR["category_description"].ToString();
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

        // fill with final jeopardy question
        public void FillFinal()
        {
            this.Load(DBAccess.GetFinalCategory().Rows[0]);
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
}
