using System;
using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ProductSQLContextTest
    {

        ProductLogic productlogic = new ProductLogic();

        [TestMethod()]
        public void ProductTest()
        {
            Product product = new Product(1, 1, "Overwatch", "Nerf Junkrat", Convert.ToDecimal(49.55), 10);
            Assert.AreEqual(1, product.Id, "Id is not equal");
            Assert.AreEqual(1, product.ManufacturerId, "ManufacturerId is not equal");
            Assert.AreEqual("Overwatch", product.Name, "Name is not equal");
            Assert.AreEqual("Nerf Junkrat", product.Description, "Description is not equal");
            Assert.AreEqual(Convert.ToDecimal(49.55), product.Price, "Price is not equal");
            Assert.AreEqual(10, product.Stock, "Stock is not equal");

        }


        [TestMethod()]
        public void GetAllProductsTest()
        {
            List<Product> productlist = productlogic.GetAllProducts();
            Product[] productenlijst = productlist.ToArray();
            Assert.AreEqual("Overwatch", productenlijst[0].Name);
        }

        [TestMethod()]
        public void GetAllReviewsTest()
        {
            List<Review> reviewlist = productlogic.GetAllReviews();
            Review[] reviewlijst = reviewlist.ToArray();
            Assert.AreEqual("***", reviewlijst[0].Rating);
        }

        private class ProductLogic
        {
            private List<Product> producten;
            private List<Review> reviews;

            public ProductLogic()
            {
                producten = new List<Product>()
                {
                    new Product(1, 1, "Overwatch", "Nerf Junkrat", Convert.ToDecimal(49.55), 10)
                };
                reviews = new List<Review>()
                {
                    new Review(1, 1, 1, "***", "Het is een redelijk product")
                };

            }

            public bool DeleteProduct(int id)
            {
                throw new NotImplementedException();
            }

            public bool DeleteReview(int id)
            {
                throw new NotImplementedException();
            }

            public List<Product> GetAllProducts()
            {
                return producten;
            }

            public List<Review> GetAllReviews()
            {
                return reviews;
            }

            public Product GetProductById(int id)
            {
                throw new NotImplementedException();
            }

            public Review GetReviewById(int id)
            {
                throw new NotImplementedException();
            }

            public Product InsertProduct(Product product)
            {
                throw new NotImplementedException();
            }

            public Review InsertReview(Review review)
            {
                throw new NotImplementedException();
            }

            public bool UpdateProduct(Product product)
            {
                throw new NotImplementedException();
            }

            public bool UpdateReview(Review review)
            {
                throw new NotImplementedException();
            }
        }
    }
}
