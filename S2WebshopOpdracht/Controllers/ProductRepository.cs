using S2WebshopOpdracht.App_DAL;
using S2WebshopOpdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2WebshopOpdracht.Controllers
{
    public class ProductRepository
    {
        private IProductContext context;

        public ProductRepository(IProductContext context)
        {
            this.context = context;
        }

        public List<Product> GetAllProducts()
        {
            return context.GetAllProducts();
        }

        public Product InsertProduct(Product product)
        {
            return context.InsertProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return context.DeleteProduct(id);
        }

        public bool UpdateProduct(Product product)
        {
            return context.UpdateProduct(product);
        }

        public Product GetProductById(int id)
        {
            return context.GetProductById(id);
        }

        public List<Review> GetAllReviews()
        {
            return context.GetAllReviews();
        }

        public Review InsertReview(Review review)
        {
            return context.InsertReview(review);
        }

        public bool DeleteReview(int id)
        {
            return context.DeleteReview(id);
        }

        public bool UpdateReview(Review review)
        {
            return context.UpdateReview(review);
        }

        public Review GetReviewById(int id)
        {
            return context.GetReviewById(id);
        }
    }
}