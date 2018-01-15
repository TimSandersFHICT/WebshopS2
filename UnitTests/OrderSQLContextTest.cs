using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class OrderSQLContextTest
    {
        OrderLogic orderlogic = new OrderLogic();

        [TestMethod()]
        public void GetAllOrdersTest()
        {
            List<Order> orderlist = orderlogic.GetAllOrders();
            Order[] orderlijst = orderlist.ToArray();
            Assert.AreEqual("Tim", orderlijst[0].BillingName);
        }

        [TestMethod()]
        public void GetAllOrderedProducts()
        {
            List<OrderedProduct> orderedproductlist = orderlogic.GetAllOrderedProducts();
            OrderedProduct[] orderedproductlijst = orderedproductlist.ToArray();
            Assert.AreEqual(3, orderedproductlijst[0].Quantity);
        }


        private class OrderLogic
        {
            private List<Order> orders;
            private List<OrderedProduct> orderedproducts;

            public OrderLogic()
            {
                orders = new List<Order>()
                {
                    new Order(1, 1, "Tim", "Tim", false)
                };

                orderedproducts = new List<OrderedProduct>()
                {
                    new OrderedProduct(1, 1, 1, 3)
                };
            }

            public bool DeleteOrder(int id)
            {
                throw new NotImplementedException();
            }

            public bool DeleteOrderedProduct(int id)
            {
                throw new NotImplementedException();
            }

            public List<Order> GetAllOrders()
            {
                return orders;
            }

            public List<OrderedProduct> GetAllOrderedProducts()
            {
                return orderedproducts;
            }

            public Order GetOrderById(int id)
            {
                throw new NotImplementedException();
            }

            public OrderedProduct GetOrderedProductById(int id)
            {
                throw new NotImplementedException();
            }

            public Order InsertOrder(Order order)
            {
                throw new NotImplementedException();
            }

            public OrderedProduct InsertOrderedProduct(OrderedProduct orderedproduct)
            {
                throw new NotImplementedException();
            }

            public bool UpdateOrder(Order order)
            {
                throw new NotImplementedException();
            }

            public bool UpdateOrderedProduct(OrderedProduct orderedproduct)
            {
                throw new NotImplementedException();
            }
        }
    }
}
