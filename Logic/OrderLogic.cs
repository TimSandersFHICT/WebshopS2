using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Models;

namespace Logic
{
    public class OrderLogic
    {
        private OrderRepository orderrepo = new OrderRepository(new OrderSQLContext());

        //Logic for getting all orders
        public List<Order> GetAllOrders()
        {
            return orderrepo.GetAllOrders();
        }

        //Logic for inserting order
        public Order InsertOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentException($"No order found.");
            }
            else
            {
                return orderrepo.InsertOrder(order);
            }
        }

        //Logic for deleting a order
        public bool DeleteOrder(int id)
        {
            Order order = orderrepo.GetOrderById(id);
            if (order == null)
            {
                throw new ArgumentException($"No order found with id {id}.");
            }
            else
            {
                return orderrepo.DeleteOrder(id);
            }
        }

        //Logic for updating order
        public bool UpdateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentException($"No order found.");
            }
            else
            {
                return orderrepo.UpdateOrder(order);
            }
        }

        //Logic for getting order by id
        public Order GetOrderById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"No order found.");
            }
            else
            {
                return orderrepo.GetOrderById(id);
            }
        }

        //Logic for getting all ordered products
        public List<OrderedProduct> GetAllOrderedProducts()
        {
            return orderrepo.GetAllOrderedProducts();
        }

        //Logic for inserting a orderedproduct
        public OrderedProduct InsertOrderedProduct(OrderedProduct orderedproduct)
        {
            if (orderedproduct == null)
            {
                throw new ArgumentException($"No ordered product found.");
            }
            else
            {
                return orderrepo.InsertOrderedProduct(orderedproduct);
            }
        }

        //Logic for deleting a orderedproduct
        public bool DeleteOrderedProduct(int id)
        {
            OrderedProduct orderedproduct = orderrepo.GetOrderedProductById(id);
            if (orderedproduct == null)
            {
                throw new ArgumentException($"No ordered product found with id {id}.");
            }
            else
            {
                return orderrepo.DeleteOrderedProduct(id);
            }
        }

        //Logic for updating orderedproduct
        public bool UpdateOrderedProduct(OrderedProduct orderedproduct)
        {
            if (orderedproduct == null)
            {
                throw new ArgumentException($"No ordered product found.");
            }
            else
            {
                return orderrepo.UpdateOrderedProduct(orderedproduct);
            }
        }

        public OrderedProduct GetOrderedProductById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"No ordered product found.");
            }
            else
            {
                return orderrepo.GetOrderedProductById(id);
            }
        }
    }
}
