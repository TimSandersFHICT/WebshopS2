using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2WebshopOpdracht.Models
{
    public class Administrator 
    {
        private int id;
        private string adminname;

        public int Id { get { return id; } set { id = value; } }
        public string AdminName { get { return adminname; } set { adminname = value; } }

        public Administrator(int id, string adminname)
        {
            this.id = id;
            this.adminname = adminname;
        }

        public Administrator(string adminname):this(-1, adminname)
        {

        }
    }
}