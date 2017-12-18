using S2WebshopOpdracht.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace S2WebshopOpdracht.App_DAL
{
    public class OrderSQLContext:IOrderContext
    {
        Order order;
        OrderedProduct orderedproduct;

        //Get all orders
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Orders ORDER BY ID";

                //commit
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(CreateOrderFromReader(reader));
                        }
                    }
                }
            }
            return orders;
        }

        //Insert a order object
        public Order InsertOrder(Order order)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Orders (AccountID, DeliveryName, BillingName, OrderStatus)" +
                    "VALUES (@accountid, @deliveryname, @billingname, @orderstatus)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@accountid", order.AccountId);
                    command.Parameters.AddWithValue("@deliveryname", order.DeliveryName);
                    command.Parameters.AddWithValue("@billingname", order.BillingName);
                    command.Parameters.AddWithValue("@orderstatus", order.OrderStatus);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return order;
            }
        }

        //Delete a order object
        public bool DeleteOrder(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Orders WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Update a order object
        public bool UpdateOrder(Order order)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE Orders" +
                    " SET AccountID=@accountid, DeliveryName=@deliveryname, BillingName=@billingname, OrderStatus=@orderstatus" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", order.Id);
                    command.Parameters.AddWithValue("@accountid", order.AccountId);
                    command.Parameters.AddWithValue("@deliveryname", order.DeliveryName);
                    command.Parameters.AddWithValue("@billingname", order.BillingName);
                    command.Parameters.AddWithValue("@orderstatus", order.OrderStatus);
                    try
                    {
                        if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
                        {
                            return true;
                        }
                    }
                    catch (SqlException e)
                    {

                    }
                }
            }
            return false;
        }

        //Get a order object by id
        public Order GetOrderById(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Orders WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            order = CreateOrderFromReader(reader);
                        }
                    }
                }
            }
            return order;
        }

        private Order CreateOrderFromReader(SqlDataReader reader)
        {
            return new Order(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToInt32(reader["AccountID"]),
                 Convert.ToString(reader["DeliveryName"]),
                 Convert.ToString(reader["BillingName"]),
                 Convert.ToBoolean(reader["OrderStatus"]));
        }

        //Get all orderedproducts
        public List<OrderedProduct> GetAllOrderedProducts()
        {
            List<OrderedProduct> orderedproducts = new List<OrderedProduct>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM OrderedProduct ORDER BY ID";

                //commit
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderedproducts.Add(CreateOrderedProductFromReader(reader));
                        }
                    }
                }
            }
            return orderedproducts;
        }

        //Insert a orderedproduct object
        public OrderedProduct InsertOrderedProduct(OrderedProduct orderedproduct)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO OrderedProduct (OrderID, ProductID, Quantity)" +
                    "VALUES (@orderid, @productid, @quantity)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@orderid", orderedproduct.OrderId);
                    command.Parameters.AddWithValue("@productid", orderedproduct.ProductId);
                    command.Parameters.AddWithValue("@quantity", orderedproduct.Quantity);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return orderedproduct;
            }
        }

        //Delete a orderedproduct object
        public bool DeleteOrderedProduct(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM OrderedProduct WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Update a orderedproduct object
        public bool UpdateOrderedProduct(OrderedProduct orderedproduct)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE OrderedProduct" +
                    " SET OrderID=@orderid, ProductID=@productid, Quantity=@quantity" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", order.Id);
                    command.Parameters.AddWithValue("@orderid", order.AccountId);
                    command.Parameters.AddWithValue("@productid", order.DeliveryName);
                    command.Parameters.AddWithValue("@quantity", order.BillingName);
                    try
                    {
                        if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
                        {
                            return true;
                        }
                    }
                    catch (SqlException e)
                    {

                    }
                }
            }
            return false;
        }

        //Get a orderedproduct object by id
        public OrderedProduct GetOrderedProductById(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM OrderedProduct WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            order = CreateOrderFromReader(reader);
                        }
                    }
                }
            }
            return orderedproduct;
        }

        private OrderedProduct CreateOrderedProductFromReader(SqlDataReader reader)
        {
            return new OrderedProduct(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToInt32(reader["OrderID"]),
                 Convert.ToInt32(reader["ProductID"]),
                 Convert.ToInt32(reader["Quantity"]));
        }
    }
}