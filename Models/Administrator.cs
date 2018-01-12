using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Administrator : Account
    {

        private string adminname;


        public string AdminName { get { return adminname; } set { adminname = value; } }

        public Administrator(string adminname,int id, int addressid, string username, string password, string email) : base(id, addressid, username, password, email)
        {
            this.adminname = adminname;
        }

    

        public Administrator(string adminname, int addressid, string username, string password, string email) : this(adminname, -1, addressid, username, password, email)
        {

        }

       
    }
}