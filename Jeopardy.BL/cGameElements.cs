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

        private DataTable dtUsers;

        public DataTable users
        {
            get { return dtUsers; }
            set { dtUsers = value; }
        }


        public void FillUsers()
        {
            dtUsers = DBAccess.ReadDB("select * from tbl_user");
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
