using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Jeopardy.DL;

namespace Jeopardy.BL
{
    // class for a user, contains games
    public class cUser
    {
        #region properties

        private int iID;
        public int ID
        {
            get { return iID; }
        }

        private string sDescription;
        public string Description
        {
            get { return sDescription; }
        }

        private int iHighScore;
        public int HighScore
        {
            get { return iHighScore; }
        }

        public string Display
        {
            get { return sDescription + "\t\t$" + iHighScore; }
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

        // new user
        public void New(string Name)
        {
            Load( DBAccess.NewUser(Name));
        }
    }
}
