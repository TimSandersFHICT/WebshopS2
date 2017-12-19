using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Database
{
    public class ProductSQLContext:IProductContext
    {
        Product product;
        Review review;

        //Get all products
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Product ORDER BY ID";

                //commit
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(CreateProductFromReader(reader));
                        }
                    }
                }
            }
            return products;
        }

        //Insert a product object
        public Product InsertProduct(Product product)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Product (ManufacturerID, Name, Description, Price, Stock)" +
                    "VALUES (@manufacturerid, @name, @description, @price, @stock)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@manufacturerid", product.ManufacturerId);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@stock", product.Stock);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return product;
            }
        }

        //Delete a product object
        public bool DeleteProduct(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Product WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Update a product object
        public bool UpdateProduct(Product product)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE Product" +
                    " SET ManufacturerID=@manufacturerid, Name=@name, Description=@description, Price=@price, Stock=@stock" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", product.Id);
                    command.Parameters.AddWithValue("@manufacturerid", product.ManufacturerId);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@stock", product.Stock);
                    try
                    {
                        if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
                        {
                            return true;
                        }
                    }
                    catch (SqlException e)
                    {

                    }
                }
            }
            return false;
        }

        //Get a product object by id
        public Product GetProductById(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Product WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product = CreateProductFromReader(reader);
                        }
                    }
                }
            }
            return product;
        }

        private Product CreateProductFromReader(SqlDataReader reader)
        {
            return new Product(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToInt32(reader["ManufacturerID"]),
                 Convert.ToString(reader["Name"]),
                 Convert.ToString(reader["Description"]),
                 Convert.ToDecimal(reader["Price"]),
                 Convert.ToInt32(reader["Stock"]));
        }


        //Get all reviews
        public List<Review> GetAllReviews()
        {
            List<Review> reviews = new List<Review>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Review ORDER BY ID";

                //commit
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reviews.Add(CreateReviewFromReader(reader));
                        }
                    }
                }
            }
            return reviews;
        }

        //Insert a review object
        public Review InsertReview(Review review)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Review (AccountID, ProductID, Rating, ReviewText)" +
                    "VALUES (@accountid, @productid, @rating, @reviewtext)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@accountid", review.AccountId);
                    command.Parameters.AddWithValue("@productid", review.ProductId);
                    command.Parameters.AddWithValue("@rating", review.Rating);
                    command.Parameters.AddWithValue("@reviewtext", review.ReviewText);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return review;
            }
        }

        //Delete a review object
        public bool DeleteReview(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Review WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Update a review object
        public bool UpdateReview(Review review)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE Review" +
                    " SET AccountID=@accountid, ProductID=@productid, Rating=@rating, ReviewText=@reviewtext" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", review.Id);
                    command.Parameters.AddWithValue("@accountid", review.AccountId);
                    command.Parameters.AddWithValue("@productid", review.ProductId);
                    command.Parameters.AddWithValue("@rating", review.Rating);
                    command.Parameters.AddWithValue("@reviewtext", review.ReviewText);
                    try
                    {
                        if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
                        {
                            return true;
                        }
                    }
                    catch (SqlException e)
                    {

                    }
                }
            }
            return false;
        }

        //Get a review object by id
        public Review GetReviewById(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Review WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product = CreateProductFromReader(reader);
                        }
                    }
                }
            }
            return review;
        }

        private Review CreateReviewFromReader(SqlDataReader reader)
        {
            return new Review(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToInt32(reader["AccountID"]),
                 Convert.ToInt32(reader["ProductID"]),
                 Convert.ToString(reader["Rating"]),
                 Convert.ToString(reader["ReviewText"]));
        }
    }
}