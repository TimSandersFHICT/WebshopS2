using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Database
{
    public class Database
    {
        private static readonly string connectionString = "Data Source=mssql.fhict.local;Initial Catalog=dbi334556;Persist Security Info=True;User ID=dbi334556;Password=banjer297";


        public static SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    connection.Close();
                }
                return connection;
            }
        }
    }
}