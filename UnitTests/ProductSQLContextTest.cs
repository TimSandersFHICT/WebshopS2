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
            //Constructor test
            Product product = new Product(1, 1, "Overwatch", "Fun multiplayer game", Convert.ToDecimal(49.55), 10);

            Assert.AreEqual(1, product.Id, "Id is not equal");
            Assert.AreEqual(1, product.ManufacturerId, "ManufacturerId is not equal");
            Assert.AreEqual("Overwatch", product.Name, "Name is not equal");
            Assert.AreEqual("Fun multiplayer game", product.Description, "Description is not equal");
            Assert.AreEqual(Convert.ToDecimal(49.55), product.Price, "Price is not equal");
            Assert.AreEqual(10, product.Stock, "Stock is not equal");
        }


        [TestMethod()]
        public void GetAllProductsTest()
        {
            //Fill list with all products stored in logic
            List<Product> productlist = productlogic.GetAllProducts();
            Product[] productenlijst = productlist.ToArray();

            //Check first entry in array if expected name is seen
            Assert.AreEqual("Overwatch", productenlijst[0].Name);
        }

        [TestMethod()]
        public void GetProductByIdTest()
        {
            //Get product with id
            Product product = productlogic.GetProductById(1);

            //Check if product is what expected
            Assert.AreEqual("Overwatch", product.Name);
        }

        [TestMethod()]
        public void DeleteProductTest()
        {
            //Delete product at with same id
            //Returns true if it worked
            Assert.AreEqual(true, productlogic.DeleteProduct(1));
        }

        [TestMethod()]
        public void InsertProductTest()
        {
            //Add new product to list
            Product product = new Product(2, 1, "League of Legends", "Best MOBA game", Convert.ToDecimal(49.55), 10);
            productlogic.InsertProduct(product);

            //Check list if new product is added
            List<Product> productlist = productlogic.GetAllProducts();
            Product[] productenlijst = productlist.ToArray();
            Assert.AreEqual("League of Legends", productenlijst[1].Name);
        }

        [TestMethod()]
        public void UpdateProductTest()
        {
            //Make changes to existing product 
            Product product = new Product(1, 2, "Call of Duty", "FPS Shooter", Convert.ToDecimal(59.99), 12);
            productlogic.UpdateProduct(product);

            //Check list if changes have been made
            List<Product> productlist = productlogic.GetAllProducts();
            Product[] productenlijst = productlist.ToArray();
            Assert.AreEqual("Call of Duty", productenlijst[0].Name);
        }

        [TestMethod()]
        public void GetAllReviewsTest()
        {
            //Fill list with all reviews stored in logic
            List<Review> reviewlist = productlogic.GetAllReviews();
            Review[] reviewlijst = reviewlist.ToArray();

            //Check first entry in array if expected rating is seen
            Assert.AreEqual("***", reviewlijst[0].Rating);
        }

        [TestMethod()]
        public void GetReviewByIdTest()
        {
            //Get review with id
            Review review = productlogic.GetReviewById(1);

            //Check if review is what expected
            Assert.AreEqual("***", review.Rating);
        }

        [TestMethod()]
        public void DeleteReviewTest()
        {
            //Delete review at with same id
            //Returns true if it worked
            Assert.AreEqual(true, productlogic.DeleteReview(1));
        }

        [TestMethod()]
        public void InsertReviewTest()
        {
            //Add new review to list
            Review review = new Review(2, 2, 1, "*****", "Het is een geweldig product");
            productlogic.InsertReview(review);

            //Check list if new review is added
            List<Review> reviewlist = productlogic.GetAllReviews();
            Review[] reviewlijst = reviewlist.ToArray();
            Assert.AreEqual("*****", reviewlijst[1].Rating);
        }

        [TestMethod()]
        public void UpdateReviewTest()
        {
            //Make changes to existing review 
            Review review = new Review(1, 1, 1, "*", "Het is een vreselijk product");
            productlogic.UpdateReview(review);

            //Check list if changes have been made
            List<Review> reviewlist = productlogic.GetAllReviews();
            Review[] reviewlijst = reviewlist.ToArray();
            Assert.AreEqual("*", reviewlijst[0].Rating);
        }

        private class ProductLogic
        {
            private List<Product> producten;
            private List<Review> reviews;



            public ProductLogic()
            {
                producten = new List<Product>()
                {
                    new Product(1, 1, "Overwatch", "Fun multiplayer game", Convert.ToDecimal(49.55), 10)
                };
                reviews = new List<Review>()
                {
                    new Review(1, 1, 1, "***", "Het is een redelijk product")
                };


            }

            public bool DeleteProduct(int id)
            {
                if (id != 0)
                {
                    producten.RemoveAt(id - 1);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool DeleteReview(int id)
            {
                if (id != 0)
                {
                    reviews.RemoveAt(id - 1);
                    return true;
                }
                else
                {
                    return false;
                }
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
                Product[] productlist = producten.ToArray();
                if (id != 0)
                {
                    return productlist[id - 1];
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            public Review GetReviewById(int id)
            {
                Review[] reviewlist = reviews.ToArray();
                if (id != 0)
                {
                    return reviewlist[id - 1];
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            public Product InsertProduct(Product product)
            {
                producten.Add(product);
                return product;
            }

            public Review InsertReview(Review review)
            {
                reviews.Add(review);
                return review;
            }

            public bool UpdateProduct(Product product)
            {
                Product[] productlist = producten.ToArray();

                if (Convert.ToBoolean(product.Id = productlist[product.Id - 1].Id))
                {

                    productlist[product.Id - 1].Name = product.Name;
                    productlist[product.Id - 1].Price = product.Price;
                    productlist[product.Id - 1].Stock = product.Stock;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool UpdateReview(Review review)
            {
                Review[] reviewlist = reviews.ToArray();

                if (Convert.ToBoolean(review.Id = reviewlist[review.Id - 1].Id))
                {

                    reviewlist[review.Id - 1].Rating = review.Rating;
                    reviewlist[review.Id - 1].ReviewText = review.ReviewText;
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
