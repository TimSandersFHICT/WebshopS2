using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IOrderContext
    {
        List<Order> GetAllOrders();
        Order InsertOrder(Order order);
        bool DeleteOrder(int id);
        bool UpdateOrder(Order order);
        Order GetOrderById(int id);
        List<OrderedProduct> GetAllOrderedProducts();
        OrderedProduct InsertOrderedProduct(OrderedProduct orderedproduct);
        bool DeleteOrderedProduct(int id);
        bool UpdateOrderedProduct(OrderedProduct orderedproduct);
        OrderedProduct GetOrderedProductById(int id);
    }
}
