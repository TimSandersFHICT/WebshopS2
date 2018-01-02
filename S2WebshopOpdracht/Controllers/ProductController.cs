using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using Logic;
using System.Web.Mvc;

namespace S2WebshopOpdracht.Controllers
{
    public class ProductController : Controller
    {
        private ProductLogic productLogic = new ProductLogic();
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = productLogic.GetAllProducts();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product product = productLogic.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            else return HttpNotFound();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Product product = new Product(Convert.ToInt32(collection["ManufacturerID"]), collection["Name"], collection["Description"], Convert.ToDecimal(collection["Price"]), Convert.ToInt32(collection["Stock"]));
                productLogic.InsertProduct(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = productLogic.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            else return HttpNotFound();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Product product = new Product(id, Convert.ToInt32(collection["ManufacturerID"]), collection["Name"], collection["Description"], Convert.ToDecimal(collection["Price"]), Convert.ToInt32(collection["Stock"]));
                productLogic.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = productLogic.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            else return HttpNotFound();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                productLogic.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
