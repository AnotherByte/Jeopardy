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

    // class for a user, contains games
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

    // Extra class deffinitions, TODO
    //// class for a question, belongs to a category, contains answers
    //public class cQuestion
    //{
    //    #region properties

    //    private int iID;
    //    public int ID
    //    {
    //        get { return iID; }
    //        set { iID = value; }
    //    }

    //    private int iCatID;
    //    public int CatID
    //    {
    //        get { return iCatID; }
    //        set { iCatID = value; }
    //    }

    //    private string sDescription;
    //    public string Description
    //    {
    //        get { return sDescription; }
    //        set { sDescription = value; }
    //    }

    //    private int iCost;
    //    public int Cost
    //    {
    //        get { return iCost; }
    //        set { iCost = value; }
    //    }



    //    private List<cAnswer> mcol;
    //    public List<cAnswer> Items
    //    {
    //        get { return mcol; }
    //        //set { mcol = value; }
    //    }

    //    private cAnswer tempAnswer;

    //    #endregion

    //    // constructor
    //    public cQuestion()
    //    {
    //        mcol = new List<cAnswer>();
    //        tempAnswer = new cAnswer();
    //    }

    //    // load question from dr
    //    public void Load(DataRow oDR)
    //    {
    //        try
    //        {
    //            int.TryParse(oDR["question_id"].ToString(), out iID);
    //            int.TryParse(oDR["category_id"].ToString(), out iCatID);
    //            sDescription = oDR["question_description"].ToString();
    //            int.TryParse(oDR["question_cost"].ToString(), out iCost);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    //    // add given cAnswer to collection
    //    private void Add(cAnswer newAnswer)
    //    {
    //        mcol.Add(newAnswer);
    //    }

    //    // return number of items in collection
    //    public int Count()
    //    {
    //        return mcol.Count;
    //    }

    //    // get answer from answer_id (null if not found)
    //    public cAnswer Item(int vsAnsID)
    //    {
    //        tempAnswer = null;
    //        foreach (cAnswer oAns in mcol)
    //        {
    //            if (oAns.ID == vsAnsID)
    //            {
    //                tempAnswer = oAns;
    //            }
    //        }
    //        return tempAnswer;
    //    }

    //    // remove answer at index
    //    public bool Remove(int viIndex)
    //    {
    //        mcol.RemoveAt(viIndex);
    //        return true;
    //    }

    //    // gets datatable from DB and fills collection
    //    public void FillQuestions()
    //    {
    //        DataTable dtQuestion = DBAccess.GetAnswers();

    //        foreach (DataRow dr in dtQuestion.Rows)
    //        {
    //            cAnswer oAnswer = new cAnswer();
    //            oAnswer.Load(dr);
    //            this.Add(oAnswer);
    //        }
    //    }
    //}

    //// class for an answer, belongs to a question
    //public class cAnswer
    //{
    //    #region properties

    //    private int iID;
    //    public int ID
    //    {
    //        get { return iID; }
    //        set { iID = value; }
    //    }

    //    private int iQuestID;
    //    public int QuestID
    //    {
    //        get { return iQuestID; }
    //        set { iQuestID = value; }
    //    }

    //    private string sDescription;
    //    public string Description
    //    {
    //        get { return sDescription; }
    //        set { sDescription = value; }
    //    }

    //    private bool bIsCorrect;
    //    public bool IsCorrect
    //    {
    //        get { return bIsCorrect; }
    //        set { bIsCorrect = value; }
    //    }

    //    #endregion

    //    // load answer from dr
    //    public void Load(DataRow oDR)
    //    {
    //        try
    //        {
    //            int.TryParse(oDR["answer_id"].ToString(), out iID);
    //            int.TryParse(oDR["question_id"].ToString(), out iQuestID);
    //            sDescription = oDR["answer_description"].ToString();
    //            bool.TryParse(oDR["answer_correct"].ToString(), out bIsCorrect);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }
    //}
}
