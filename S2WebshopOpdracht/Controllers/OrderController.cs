using Logic;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2WebshopOpdracht.Controllers
{
    public class OrderController : Controller
    {
        private OrderLogic orderLogic = new OrderLogic();

        // GET: Order
        public ActionResult IndexOrder()
        {
            List<Order> orders = orderLogic.GetAllOrders();
            return View(orders);
        }

        // GET: Order/Details/5
        public ActionResult DetailsOrder(int id)
        {
            Order order = orderLogic.GetOrderById(id);
            if (order != null)
            {
                return View(order);
            }
            else return HttpNotFound();
        }

        // GET: Order/Create
        public ActionResult CreateOrder()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult CreateOrder(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Order order = new Order(Convert.ToInt32(collection["AccountID"]), collection["DeliveryName"], collection["BillingName"], false);
                orderLogic.InsertOrder(order);
                return RedirectToAction("IndexOrder");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult EditOrder(int id)
        {
            Order order = orderLogic.GetOrderById(id);
            if (order != null)
            {
                return View(order);
            }
            else return HttpNotFound();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult EditOrder(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Order order = new Order(id, Convert.ToInt32(collection["AccountID"]), collection["DeliveryName"], collection["BillingName"], Convert.ToBoolean(collection["OrderStatus"]));
                orderLogic.UpdateOrder(order);
                return RedirectToAction("IndexOrder");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult DeleteOrder(int id)
        {
            Order order = orderLogic.GetOrderById(id);
            if (order != null)
            {
                return View(order);
            }
            else return HttpNotFound();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult DeleteOrder(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                orderLogic.DeleteOrder(id);
                return RedirectToAction("IndexOrder");
            }
            catch
            {
                return View();
            }
        }
    }
}
