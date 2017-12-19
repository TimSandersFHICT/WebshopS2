using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database
{
    public class OrderRepository
    {
        private IOrderContext context;

        public OrderRepository(IOrderContext context)
        {
            this.context = context;
        }

        public List<Order> GetAllOrders()
        {
            return context.GetAllOrders();
        }

        public Order InsertOrder(Order order)
        {
            return context.InsertOrder(order);
        }

        public bool DeleteOrder(int id)
        {
            return context.DeleteOrder(id);
        }

        public bool UpdateOrder(Order order)
        {
            return context.UpdateOrder(order);
        }

        public Order GetOrderById(int id)
        {
            return context.GetOrderById(id);
        }

        public List<OrderedProduct> GetAllOrderedProducts()
        {
            return context.GetAllOrderedProducts();
        }

        public OrderedProduct InsertOrderedProduct(OrderedProduct orderedproduct)
        {
            return context.InsertOrderedProduct(orderedproduct);
        }

        public bool DeleteOrderedProduct(int id)
        {
            return context.DeleteOrderedProduct(id);
        }

        public bool UpdateOrderedProduct(OrderedProduct orderedproduct)
        {
            return context.UpdateOrderedProduct(orderedproduct);
        }

        public OrderedProduct GetOrderedProductById(int id)
        {
            return context.GetOrderedProductById(id);
        }
    }
}