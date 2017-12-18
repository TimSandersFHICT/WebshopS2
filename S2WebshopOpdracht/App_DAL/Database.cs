﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace S2WebshopOpdracht.App_DAL
{
    public class Database
    {
        private static readonly string connectionString = "Data Source=TIMPC;Initial Catalog=SharingPlatformS2;Integrated Security=True";


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