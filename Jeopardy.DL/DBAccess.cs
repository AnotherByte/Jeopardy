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

        static public DataTable ReadDB(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                SQLiteConnection cnn = new SQLiteConnection("Data Source=db_jeopardy.s3db");
                cnn.Open();

                SQLiteCommand mycommand = new SQLiteCommand(cnn);
                mycommand.CommandText = (sql);

                SQLiteDataReader reader = mycommand.ExecuteReader();
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
    }
}
