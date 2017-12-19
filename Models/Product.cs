using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Product
    {
        private int id;
        private int manufacturerid;
        private string name;
        private string description;
        private decimal price;
        private int stock;

        public int Id { get { return id; } set { id = value; } }
        public int ManufacturerId { get { return manufacturerid; } set { manufacturerid = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public decimal Price { get { return price; } set { price = value; } }
        public int Stock { get { return stock; } set { stock = value; } }

        public Product(int id, int manufacturerid, string name, string description, decimal price, int stock)
        {
            this.id = id;
            this.manufacturerid = manufacturerid;
            this.name = name;
            this.description = description;
            this.price = price;
            this.stock = stock;
        }

        public Product(int manufacturerid, string name, string description, decimal price, int stock):this(-1, manufacturerid, name, description, price, stock)
        {

        }
    }
}