using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Jeopardy.BL
{
    // class for an answer, belongs to a question
    public class cAnswer
    {
        #region properties

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
