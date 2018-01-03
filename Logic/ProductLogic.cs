using System;
using Database;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductLogic
    {
        private ProductRepository productrepo = new ProductRepository(new ProductSQLContext());

        //Logic for getting all products
        public List<Product> GetAllProducts()
        {
            return productrepo.GetAllProducts();
        }

        //Logic for inserting product
        public Product InsertProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentException($"No product found.");
            }
            else
            {
                return productrepo.InsertProduct(product);
            }
        }

        //Logic for deleting a product
        public bool DeleteProduct(int id)
        {
            Product product = productrepo.GetProductById(id);
            if(product == null)
            {
                throw new ArgumentException($"No product found with id {id}.");
            }
            else
            {
                return productrepo.DeleteProduct(id);
            }
        }

        //Logic for updating product
        public bool UpdateProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentException($"No product found.");
            }
            else
            {
                productrepo.UpdateProduct(product);
                return true;
            }
        }

        //Logic for getting product by id
        public Product GetProductById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"No review found.");
            }
            else
            {
                return productrepo.GetProductById(id);
            }
        }

        //Logic for getting all reviews
        public List<Review> GetAllReviews()
        {
            return productrepo.GetAllReviews();
        }

        //Logic for inserting review
        public Review InsertReview(Review review)
        {
            string hiddenpassword = "*";

            if (review == null)
            {
                throw new ArgumentException($"No product found.");
            }
            else if(review.Rating.Contains(hiddenpassword))
            {
                return productrepo.InsertReview(review);
            }
            else
            {
                throw new ArgumentException($"Review rating must be in asterisks (*)");
            }
        }

        //Logic for deleting a review
        public bool DeleteReview(int id)
        {
            Review review = productrepo.GetReviewById(id);
            if(review == null)
            {
                throw new ArgumentException($"No review found.");
            }
            else
            {
                return productrepo.DeleteReview(id);
            }
        }

        //Logic for updating a review
        public bool UpdateReview(Review review)
        {
            if(review == null)
            {
                throw new ArgumentException($"No review found.");
            }
            else
            {
                return productrepo.UpdateReview(review);
            }
        }

        //Logic for getting a review by id
        public Review GetReviewById(int id)
        {
            if(id == 0)
            {
                throw new ArgumentException($"No review found.");
            }
            else
            {
                return productrepo.GetReviewById(id);
            }
        }

        public Review GetReviewByProductId(int productid)
        {
            if(productid == 0)
            {
                throw new ArgumentException($"No product found.");
            }
            else
            {
                return productrepo.GetReviewByProductId(productid);
            }
        }
    }
}
