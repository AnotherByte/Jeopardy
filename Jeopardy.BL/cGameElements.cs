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

        // gets datatable from DB and fills collection
        public void FillCategories()
        {
            DataTable dtCategory = DBAccess.GetCategory();

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

        #endregion



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
        
    }

    // class for a question, belongs to a category, contains answers
    public class cQuestion
    {

    }

    // class for an answer, belongs to a question
    public class cAnswer
    {

    }

}
