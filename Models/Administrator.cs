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

        public Administrator(string adminname, string username, string password, string email) : base(username, password, email)
        {
            this.adminname = adminname;
        }

        public Administrator(int id, string adminname) : base(id)
        {
            this.adminname = adminname;
        }

        public Administrator(string adminname) : this(-1, adminname)
        {

        }

       
    }
}