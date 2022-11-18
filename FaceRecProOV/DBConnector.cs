using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MultiFaceRec
{
    public static class DBConnector
    {
        public static MySqlConnection OpenConnection()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=hospital_management;");
            con.Open();
            return con;
        }
    }
}
