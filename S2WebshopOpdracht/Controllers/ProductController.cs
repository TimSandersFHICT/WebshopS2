using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using Logic;
using System.Web.Mvc;
using S2WebshopOpdracht.ViewModels;

namespace S2WebshopOpdracht.Controllers
{
    public class ProductController : Controller
    {
        private ProductLogic productLogic = new ProductLogic();
        private ProductViewModel viewmodelProduct = new ProductViewModel();

        // GET: Product
        public ActionResult IndexProduct()
        {
            
            List<Product> products = productLogic.GetAllProducts();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult DetailsProduct(int id)
        {
            Product product = productLogic.GetProductById(id);
            Review review = productLogic.GetReviewByProductId(id);

            viewmodelProduct.Rating = review.Rating;
            viewmodelProduct.ReviewText = review.ReviewText;
            viewmodelProduct.Name = product.Name;
            viewmodelProduct.Description = product.Description;
            viewmodelProduct.Price = product.Price;
            viewmodelProduct.Stock = product.Stock;
            if (viewmodelProduct != null)
            {
                return View(viewmodelProduct);
            }
            else return HttpNotFound();
        }

        // GET: Product/Create
        public ActionResult CreateProduct()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult CreateProduct(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Product product = new Product(Convert.ToInt32(collection["ManufacturerID"]), collection["Name"], collection["Description"], Convert.ToDecimal(collection["Price"]), Convert.ToInt32(collection["Stock"]));
                productLogic.InsertProduct(product);
                return RedirectToAction("IndexProduct");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult EditProduct(int id)
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
        public ActionResult EditProduct(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Product product = new Product(id, Convert.ToInt32(collection["ManufacturerID"]), collection["Name"], collection["Description"], Convert.ToDecimal(collection["Price"]), Convert.ToInt32(collection["Stock"]));
                productLogic.UpdateProduct(product);
                return RedirectToAction("IndexProduct");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult DeleteProduct(int id)
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
        public ActionResult DeleteProduct(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                productLogic.DeleteProduct(id);
                return RedirectToAction("IndexProduct");
            }
            catch
            {
                return View();
            }
        }

        // GET: Review
        public ActionResult IndexReview()
        {
            List<Review> reviews = productLogic.GetAllReviews();
            return View(reviews);
        }

        // GET: Review/Details/5
        public ActionResult DetailsReview(int id)
        {
            Review review = productLogic.GetReviewById(id);
            if (review != null)
            {
                return View(review);
            }
            else return HttpNotFound();
        }

        // GET: Review/Create
        public ActionResult CreateReview()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult CreateReview(FormCollection collection, int id)
        {
            try
            {
                // TODO: Add insert logic here
                Review review = new Review(Convert.ToInt32(Session["AccountID"]), id, collection["Rating"], collection["ReviewText"]);
                productLogic.InsertReview(review);
                return RedirectToAction("IndexProduct");
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Edit/5
        public ActionResult EditReview(int id)
        {
            Review review = productLogic.GetReviewById(id);
            if (review != null)
            {
                return View(review);
            }
            else return HttpNotFound();
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult EditReview(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Review review = new Review(id, Convert.ToInt32(collection["AccountID"]), Convert.ToInt32(collection["ProductID"]), collection["Rating"], collection["ReviewText"]);
                productLogic.UpdateReview(review);
                return RedirectToAction("IndexReview");
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Delete/5
        public ActionResult DeleteReview(int id)
        {
            Review review = productLogic.GetReviewById(id);
            if (review != null)
            {
                return View(review);
            }
            else return HttpNotFound();
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult DeleteReview(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                productLogic.DeleteReview(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
