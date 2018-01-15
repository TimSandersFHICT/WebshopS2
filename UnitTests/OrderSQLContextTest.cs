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
            //Fill list with all orders stored in logic
            List<Order> orderlist = orderlogic.GetAllOrders();
            Order[] orderlijst = orderlist.ToArray();

            //Check first entry in array if expected bullingname is seen
            Assert.AreEqual("Tim", orderlijst[0].BillingName);
        }

        [TestMethod()]
        public void GetOrderByIdTest()
        {
            //Get order with id
            Order order = orderlogic.GetOrderById(1);

            //Check if order is what expected
            Assert.AreEqual("Tim", order.BillingName);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            //Delete order at with same id
            //Returns true if it worked
            Assert.AreEqual(true, orderlogic.DeleteOrder(1));
        }

        [TestMethod()]
        public void InsertOrderTest()
        {
            //Add new order to list
            Order order = new Order(2, 2, "Luc", "Luc", false);
            orderlogic.InsertOrder(order);

            //Check list if new order is added
            List<Order> orderlist = orderlogic.GetAllOrders();
            Order[] orderlijst = orderlist.ToArray();
            Assert.AreEqual("Luc", orderlijst[1].BillingName);
        }

        [TestMethod()]
        public void UpdateOrderTest()
        {
            //Make changes to existing order 
            Order order = new Order(1, 1, "Tim Sanders", "Tim Sanders", false);
            orderlogic.UpdateOrder(order);

            //Check list if changes have been made
            List<Order> orderlist = orderlogic.GetAllOrders();
            Order[] orderlijst = orderlist.ToArray();
            Assert.AreEqual("Tim Sanders", orderlijst[0].BillingName);
        }

        [TestMethod()]
        public void GetAllOrderedProducts()
        {
            //Fill list with all orderedproducts stored in logic
            List<OrderedProduct> orderedproductlist = orderlogic.GetAllOrderedProducts();
            OrderedProduct[] orderedproductlijst = orderedproductlist.ToArray();

            //Check first entry in array if expected quantity is seen
            Assert.AreEqual(3, orderedproductlijst[0].Quantity);
        }

        [TestMethod()]
        public void GetOrderedProductByIdTest()
        {
            //Get orderedproduct with id
            OrderedProduct orderedproduct = orderlogic.GetOrderedProductById(1);

            //Check if orderedproduct is what expected
            Assert.AreEqual(3, orderedproduct.Quantity);
        }

        [TestMethod()]
        public void DeleteOrderedProductTest()
        {
            //Delete orderedproduct at with same id
            //Returns true if it worked
            Assert.AreEqual(true, orderlogic.DeleteOrderedProduct(1));
        }

        [TestMethod()]
        public void InsertOrderedProductTest()
        {
            //Add new orderedproduct to list
            OrderedProduct orderedproduct = new OrderedProduct(2, 2, 3, 10);
            orderlogic.InsertOrderedProduct(orderedproduct);

            //Check list if new orderedproduct is added
            List<OrderedProduct> orderedproductlist = orderlogic.GetAllOrderedProducts();
            OrderedProduct[] orderedproductlijst = orderedproductlist.ToArray();
            Assert.AreEqual(10, orderedproductlijst[1].Quantity);
        }

        [TestMethod()]
        public void UpdateOrderedProductTest()
        {
            //Make changes to existing orderedproduct
            OrderedProduct orderedproduct = new OrderedProduct(1, 1, 1, 5);
            orderlogic.UpdateOrderedProduct(orderedproduct);

            //Check list if changes have been made
            List<OrderedProduct> orderedproductlist = orderlogic.GetAllOrderedProducts();
            OrderedProduct[] orderedproductlijst = orderedproductlist.ToArray();
            Assert.AreEqual(5, orderedproductlijst[0].Quantity);
        }

        private class OrderLogic
        {
            private List<Order> orders;
            private List<OrderedProduct> orderedproducts;

            public OrderLogic()
            {
                //Make new order list
                orders = new List<Order>()
                {
                    new Order(1, 1, "Tim", "Tim", false)
                };
                //Make new orderedproduct list
                orderedproducts = new List<OrderedProduct>()
                {
                    new OrderedProduct(1, 1, 1, 3)
                };
            }

            public bool DeleteOrder(int id)
            {
                if (id != 0)
                {
                    //Remove order at index id - 1
                    orders.RemoveAt(id - 1);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool DeleteOrderedProduct(int id)
            {
                if (id != 0)
                {
                    //Remove orderedproduct at index id - 1
                    orderedproducts.RemoveAt(id - 1);
                    return true;
                }
                else
                {
                    return false;
                }
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
                //List to array
                Order[] orderlist = orders.ToArray();
                if (id != 0)
                {
                    //Return order at index id - 1 because array index starts at 0
                    return orderlist[id - 1];
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            public OrderedProduct GetOrderedProductById(int id)
            {
                //List to array
                OrderedProduct[] orderedproductlist = orderedproducts.ToArray();
                if (id != 0)
                {
                    //Return orderedproduct at index id - 1 because array index starts at 0
                    return orderedproductlist[id - 1];
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            public Order InsertOrder(Order order)
            {
                //Add order to the list
                orders.Add(order);
                return order;
            }

            public OrderedProduct InsertOrderedProduct(OrderedProduct orderedproduct)
            {
                //Add orderedproduct to the list
                orderedproducts.Add(orderedproduct);
                return orderedproduct;
            }

            public bool UpdateOrder(Order order)
            {
                //List to array
                Order[] orderlist = orders.ToArray();

                //Check array for same id as inserted order
                if (Convert.ToBoolean(order.Id = orderlist[order.Id - 1].Id))
                {
                    //Update order in array with same id
                    orderlist[order.Id - 1].BillingName = order.BillingName;
                    orderlist[order.Id - 1].DeliveryName = order.DeliveryName;
                    orderlist[order.Id - 1].OrderStatus = order.OrderStatus;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool UpdateOrderedProduct(OrderedProduct orderedproduct)
            {
                //List to array
                OrderedProduct[] orderedproductlist = orderedproducts.ToArray();

                //Check array for same id as inserted orderedproduct
                if (Convert.ToBoolean(orderedproduct.Id = orderedproductlist[orderedproduct.Id - 1].Id))
                {
                    //Update orderedproduct in array with same id
                    orderedproductlist[orderedproduct.Id - 1].Quantity = orderedproduct.Quantity;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
