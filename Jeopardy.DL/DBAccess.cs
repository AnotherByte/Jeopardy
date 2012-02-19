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
            return ExecuteQuery(string.Format("select * from tbl_category where category_id in ({0})", sIDs));
        }

        // returns datatable of tbl_question
        static public DataTable GetQuestions(string ID)
        {
            return ExecuteQuery(string.Format("select * from tbl_question where category_id = {0}", ID));
        }

        // returns datatable of tbl_answer
        static public DataTable GetAnswers(string ID)
        {
            return ExecuteQuery(string.Format("select * from tbl_answer where question_id = {0}", ID));
        }


        // get # of UNUSED categories
        static private int GetUnusedCategory()
        {
            return ExecuteNonQuery("select count(category_used) from tbl_category where category_used = 0");
        }

        // reset used categories
        static private int ResetCategories()
        {
            return ExecuteNonQuery("update tbl_category set category_used = 0");
        }

        // get array of unused categories
        static public List<int> UnusedCategoryList()
        {
            // check if enough unused
            if (GetUnusedCategory() < 6)
            {
                // too few categories remain, reset
                ResetCategories();
            }

            DataTable dtUnusedID = ExecuteQuery("select category_id from tbl_category where (category_used = 0 AND category_is_final = 0)");
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
    }
}
