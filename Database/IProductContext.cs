using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IProductContext
    {
        List<Product> GetAllProducts();
        Product InsertProduct(Product product);
        bool DeleteProduct(int id);
        bool UpdateProduct(Product product);
        Product GetProductById(int id);
        List<Review> GetAllReviews();
        Review InsertReview(Review review);
        bool DeleteReview(int id);
        bool UpdateReview(Review review);
        Review GetReviewById(int id);
        Review GetReviewByProductId(int productid);
    }
}
