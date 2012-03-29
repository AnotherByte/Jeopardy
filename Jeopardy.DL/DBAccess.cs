using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Xml;

namespace Jeopardy.DL
{
    static public class DBAccess
    {
        static private string sDataSource = "Data Source=db_jeopardy.s3db";


        // used for select
        static private DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                SQLiteConnection cnn = new SQLiteConnection(sDataSource);
                cnn.Open();

                SQLiteCommand cmd = new SQLiteCommand(cnn);
                cmd.CommandText = (sql);

                SQLiteDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                reader.Close();
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }


        // used for insert update delete
        static private int ExecuteNonQuery(string sql)
        {
            int rowsUpdated;

            try
            {
                SQLiteConnection cnn = new SQLiteConnection(sDataSource);
                cnn.Open();
 
                SQLiteCommand cmd = new SQLiteCommand(cnn);
                cmd.CommandText = sql;
 
                rowsUpdated = cmd.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return rowsUpdated;
        }




        // returns datatable of tbl_user
        static public DataTable GetUsers()
        {
            return ExecuteQuery("select * from tbl_user");
        }

        // returns datatable of tbl_category (UNUSED category and NOT final jeopardy)
        static public DataTable GetCategory(string sIDs)
        {
            // set categories used
            ExecuteNonQuery(string.Format("update tbl_category set category_used = 1 where category_id in ({0})", sIDs));
            return ExecuteQuery(string.Format("select * from tbl_category where category_id in ({0}) order by random()", sIDs));
        }

        // returns datatable of tbl_category (UNUSED category and IS final jeopardy)
        static public DataTable GetFinalCategory()
        {
            // check if enough unused
            if (GetUnusedCategory(1) < 1)
            {
                // too few categories remain, reset
                ResetCategories(1);
            }

            // get random unused, final jeopardy category id
            int id;
            int.TryParse(ExecuteQuery("SELECT category_id FROM tbl_category WHERE category_is_final=1 and category_used = 0 ORDER BY RANDOM() LIMIT 1").Rows[0]["category_id"].ToString(), out id);

            // mark used
            ExecuteNonQuery(string.Format("update tbl_category set category_used = 1 where category_id = {0}", id));
            //get datatable with random id
            return ExecuteQuery(string.Format("SELECT * FROM tbl_category WHERE category_id = {0}", id));
        }

        // returns datatable of tbl_question
        static public DataTable GetQuestions(string ID)
        {
            return ExecuteQuery(string.Format("select * from tbl_question where category_id = {0}", ID));
        }

        // returns datatable of tbl_answer
        static public DataTable GetAnswers(string ID)
        {
            return ExecuteQuery(string.Format("select * from tbl_answer where question_id = {0} order by random()", ID));
        }

        // get # of UNUSED categories
        static private int GetUnusedCategory(int viFinal)
        {
            return ExecuteNonQuery(string.Format("select count(category_used) from tbl_category where category_used = 0 and category_is_final = {0}", viFinal));
        }

        // reset used categories
        static private int ResetCategories(int viFinal)
        {
            return ExecuteNonQuery(string.Format("update tbl_category set category_used = 0 where category_is_final = {0}", viFinal));
        }

        // get array of unused categories
        static public List<int> UnusedCategoryList(string sIDs)
        {
            // check if enough unused
            if (GetUnusedCategory(0) < 6)
            {
                // too few categories remain, reset
                ResetCategories(0);
            }

            DataTable dtUnusedID = ExecuteQuery(string.Format("select category_id from tbl_category where (category_used = 0 AND category_is_final = 0 AND category_id Not in ({0})) order by random()", sIDs));
            List<int> unused = new List<int>();

            // fill list with cat_id's
            for (int i = 0; i < dtUnusedID.Rows.Count; i++)  
            {
                int temp;
                int.TryParse(dtUnusedID.Rows[i]["category_id"].ToString(), out temp);
                unused.Add(temp);
            }

            return unused;
        }

        // add data to database
        static public bool SQLInsert(string sql)
        {
            return (ExecuteNonQuery(sql) == 1);
        }

        // add game to database and return game id
        static public int SaveGame(int viUserID)
        {
            string sql = string.Format("insert into tbl_game (user_id) values ({0})", viUserID);
            ExecuteNonQuery(sql);

            DataTable dt = ExecuteQuery(string.Format("select game_id from tbl_game where user_id = {0} order by game_id desc", viUserID));


            return int.Parse(dt.Rows[0][0].ToString());
        }

        // add round to database
        static public void SaveRound(int GameID, int Score)
        {
            string sql = string.Format("insert into tbl_round (game_id, round_score) values ({0}, {1})", GameID, Score);
            ExecuteNonQuery(sql);
        }

        // get highscore based on ID
        static public int GetHighScore(int UserID)
        {
            DataTable dt = ExecuteQuery(string.Format("select user_high_score from tbl_user where user_id = {0}", UserID));

            return int.Parse(dt.Rows[0][0].ToString());
        }

        public static void SetHighScore(int Score, int UserID)
        {
            ExecuteNonQuery(string.Format("update tbl_user set user_high_score = {0} where user_id = {1}", Score, UserID));
        }
    }
}
