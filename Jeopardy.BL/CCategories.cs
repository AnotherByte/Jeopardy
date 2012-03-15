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
        public cCategory this[int index]
        {
            get { return mcol[index]; }
            //set { mcol = value; }
        }

        #endregion

        // constructor
        public cCategories()
        {
            mcol = new List<cCategory>();
        }

        // add given cCategory to collection
        private void Add(cCategory newCategory)
        {
            mcol.Add(newCategory);
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

        // fill each category
        public void LoadQuestions()
        {
            foreach (cCategory oCat in mcol)
            {
                oCat.FillCategory();
            }
        }
    }
}
