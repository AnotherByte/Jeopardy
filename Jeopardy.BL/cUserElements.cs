using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Jeopardy.DL;

namespace Jeopardy.BL
{
    public class cUsers
    {
        #region properties

        private List<cUser> mcol;
        public List<cUser> Items
        {
            get { return mcol; }
        }

        private cUser tempUser;

        #endregion

        // constructor
        public cUsers()
        {
            mcol = new List<cUser>();
            tempUser = new cUser();
        }

        // add given cUser to list
        private void Add(cUser newUser)
        {
            mcol.Add(newUser);
        }

        // return number of items in collection
        public int Count()
        {
            return mcol.Count;
        }

        // get user from user_id (null if not found)
        public cUser Item(int vsCatID)
        {
            tempUser = null;
            foreach (cUser oUser in mcol)
            {
                if (oUser.ID == vsCatID)
                {
                    tempUser = oUser;
                }
            }
            return tempUser;
        }

        // remove user at index
        public bool Remove(int viIndex)
        {
            mcol.RemoveAt(viIndex);
            return true;
        }

        // get users from database and fill list
        public void FillUsers()
        {
            DataTable dtUsers = DBAccess.GetUsers();

            foreach (DataRow dr in dtUsers.Rows)
            {
                cUser oUser = new cUser();
                oUser.Load(dr);
                this.Add(oUser);
            }
        }

    }

    public class cUser
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

        private int iHighScore;
        public int HighScore
        {
            get { return iHighScore; }
            set { iHighScore = value; }
        }

        #endregion

        // get user info from dr
        public void Load(DataRow oDR)
        {
            try
            {
                int.TryParse(oDR["user_id"].ToString(), out iID);
                sDescription = oDR["user_description"].ToString();
                int.TryParse(oDR["user_high_score"].ToString(), out iHighScore);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
