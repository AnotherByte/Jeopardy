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



        // returns datatable of tbl_category
        static public DataTable GetCategory()
        {
            return ExecuteQuery("select * from tbl_category");
        }

        // returns datatable of tbl_category
        static public DataTable GetUsers()
        {
            return ExecuteQuery("select * from tbl_user");
        }
    }
}
