using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Manufacturer
    {
        private int id;
        private string manufacturername;

        public int Id { get { return id; } set { id = value; } }
        public string ManufacturerName { get { return manufacturername; } set { manufacturername = value; } }

        public Manufacturer(int id, string manufacturername)
        {
            this.id = id;
            this.manufacturername = manufacturername;
        }

        public Manufacturer(string manufacturername):this(-1, manufacturername)
        {

        }
    }
}