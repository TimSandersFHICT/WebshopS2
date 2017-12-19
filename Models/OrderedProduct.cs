using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class OrderedProduct
    {
        private int id;
        private int orderid;
        private int productid;
        private int quantity;

        public int Id { get { return id; } set { id = value; } }
        public int OrderId { get { return orderid; } set { orderid = value; } }
        public int ProductId { get { return productid; } set { productid = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }

        public OrderedProduct(int id, int orderid, int productid, int quantity)
        {
            this.id = id;
            this.orderid = orderid;
            this.productid = productid;
            this.quantity = quantity;
        }

        public OrderedProduct(int orderid, int productid, int quantity):this(-1, orderid, productid, quantity)
        {

        }
    }
}