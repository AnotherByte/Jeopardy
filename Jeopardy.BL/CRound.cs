using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Jeopardy.DL;

namespace Jeopardy.BL
{
    public class cRound
    {
        #region properties

        private int iMultiplier;
        public int Multiplier
        {
          get { return iMultiplier; }
        }

        private int iScore;
        public int Score
        {
            get { return iScore; }
            set { iScore = value; }
        }

        private string sUsedIDs;
        public string UsedIDs
        {
            get { return sUsedIDs; }
        }

        private int iDDCategory;
        private int iDDQuestion;
        public string DailyDouble
        {
            get { return string.Format("{0}{1}", iDDCategory, iDDQuestion); }
        }



        private List<cCategory> mcol;
        public cCategory this[int index]
        {
            get { return mcol[index]; }
        }

        #endregion


        // constructor
        public cRound(int viMultiplier, string vsUsedIDs)
        {
            sUsedIDs = vsUsedIDs;
            iMultiplier = viMultiplier;
            mcol = new List<cCategory>();

            // set up daily double
            Random rand = new Random();
            iDDCategory = rand.Next(5);
            iDDQuestion = rand.Next(4);
        }


        // add given cCategory to collection
        private void Add(cCategory newCategory)
        {
            mcol.Add(newCategory);
        }

        // gets datatable from DB and fills collection with UNUSED single jeopardy categories
        public void FillRound()
        {
            // get list of #'s of unused categories
            List<int> iIDs = DBAccess.UnusedCategoryList(sUsedIDs);

            // remove if too many
            Random rand = new Random();
            while (iIDs.Count > 6)
            {
                iIDs.RemoveAt(rand.Next(0, iIDs.Count - 1));
            }
            rand = null;

            // biuld string of id's for sql
            sUsedIDs = "";
            foreach (int i in iIDs)
            {
                sUsedIDs += string.Format("{0}, ", i);
            }
            sUsedIDs = sUsedIDs.Remove(sUsedIDs.Length - 2);


            // get datatable
            DataTable dtCategory = DBAccess.GetCategory(sUsedIDs);

            foreach (DataRow dr in dtCategory.Rows)
            {
                cCategory oCategory = new cCategory();
                oCategory.Load(dr);
                oCategory.FillCategory();
                this.Add(oCategory);
            }
        }

        // gets question cost * multiplier
        public int GetCost(string vsIndex)
        {
            int iCat = vsIndex[0] - 48;
            int iQue = vsIndex[1] - 48;
            return mcol[iCat][iQue].Cost * iMultiplier;
        }

    }
}
