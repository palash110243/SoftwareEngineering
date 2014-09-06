using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Library
{
    class Databaseconnection
    {
        public static SqlConnection Get_con()
        {
            string con = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\palash\Documents\GitHub\SoftwareEngineering\DigitalLibrary\Digital_Library\Book_List.mdf;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(con);
            Conn.Open();
            return Conn;
        }

        public static SqlConnection disconnect(SqlConnection conn)
        {
            conn.Close();
            return conn;
        }
    }
}
