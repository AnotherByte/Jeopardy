using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Jeopardy.DL;

namespace Jeopardy.BL
{
    // class for GROUP of users
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
}
