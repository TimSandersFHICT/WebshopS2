using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Database
{
    public class AccountSQLContext : IAccountContext
    {
        Address address;
        Account account;

        //Get all accounts
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM ACCOUNT ORDER BY ID";

                //commit
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(CreateAccountFromReader(reader));
                        }
                    }
                }
            }
            return accounts;
        }

        //Insert a administrator object
        public Administrator InsertAdministrator(Administrator administrator)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string queryadmin = "INSERT INTO Administrator (AdminName)" +
                    "VALUES (@adminname)";
                string queryaccount = "INSERT INTO Account (Username, Password, Email, AdministratorID)" +
                   "VALUES (@username, @password, @email, @administratorid)";
                using (SqlCommand command = new SqlCommand(queryadmin, connection))
                {
                    command.Parameters.AddWithValue("@adminname", administrator.AdminName);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                using (SqlCommand command = new SqlCommand(queryaccount, connection))
                {
                    command.Parameters.AddWithValue("@username", administrator.Username);
                    command.Parameters.AddWithValue("@password", administrator.Password);
                    command.Parameters.AddWithValue("@email", administrator.Email);
                    command.Parameters.AddWithValue("@administratorid", administrator.Id);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return administrator;
            }
        }

        //Insert a customer object
        public Customer InsertCustomer(Customer customer)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string queryadmin = "INSERT INTO Customer (CreditCardInfo, PhoneNumber, FirstName, LastName, ShippingInfo)" +
                    "VALUES (@creditcardinfo, @phonenumber, @firstname, @lastname, @shippinginfo)";

                string queryaccount = "INSERT INTO Account (Username, Password, Email, CustomerID)" +
                   "VALUES (@username, @password, @email, @customerid)";
                using (SqlCommand command = new SqlCommand(queryadmin, connection))
                {
                    command.Parameters.AddWithValue("@creditcardinfo", customer.CreditCardInfo);
                    command.Parameters.AddWithValue("@phonenumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@firstname", customer.FirstName);
                    command.Parameters.AddWithValue("@lastname", customer.LastName);
                    command.Parameters.AddWithValue("@shippinginfo", customer.ShippingInfo);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                using (SqlCommand command = new SqlCommand(queryaccount, connection))
                {
                    command.Parameters.AddWithValue("@username", customer.Username);
                    command.Parameters.AddWithValue("@password", customer.Password);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.Parameters.AddWithValue("@customerid", customer.Id);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return customer;
            }
        }

        //Delete a account object
        public bool DeleteAccount(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Account WHERE ID=@id";
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

        //Update a customer object
        public bool UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string querycustomer = "UPDATE Customer" +
                    " SET CreditCardInfo=@creditcardinfo, PhoneNumber=@phonenumber, FirstName=@firstname, LastName=@lastname, ShippingInfo=@shippinginfo" +
                    " WHERE ID=@id";
                string queryaccount = "UPDATE Account" +
                    " SET Username=@username, Password=@password, Email=@email" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(querycustomer, connection))
                {
                    command.Parameters.AddWithValue("@id", customer.Id);
                    command.Parameters.AddWithValue("@creditcardinfo", customer.CreditCardInfo);
                    command.Parameters.AddWithValue("@phonenumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@firstname", customer.FirstName);
                    command.Parameters.AddWithValue("@lastname", customer.LastName);
                    command.Parameters.AddWithValue("@shippinginfo", customer.ShippingInfo);
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
                using (SqlCommand command = new SqlCommand(queryaccount, connection))
                {
                    command.Parameters.AddWithValue("@id", customer.Id);
                    command.Parameters.AddWithValue("@username", customer.Username);
                    command.Parameters.AddWithValue("@password", customer.Password);
                    command.Parameters.AddWithValue("@email", customer.Email);
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

        private Account CreateAccountFromReader(SqlDataReader reader)
        {
            if (reader["CustomerID"] == DBNull.Value)
            {
                return new Administrator(
                 Convert.ToString(reader["AdminName"]),
                 Convert.ToString(reader["Username"]),
                 Convert.ToString(reader["Password"]),
                 Convert.ToString(reader["Email"]));


            }
            else
            {
                return new Customer(
                 Convert.ToString(reader["CreditCardInfo"]),
                 Convert.ToString(reader["PhoneNumber"]),
                 Convert.ToString(reader["FirstName"]),
                 Convert.ToString(reader["LastName"]),
                 Convert.ToString(reader["ShippingInfo"]),
                 Convert.ToString(reader["Username"]),
                 Convert.ToString(reader["Password"]),
                 Convert.ToString(reader["Email"]));
            }
        }

        //Get all accounts
        public List<Address> GetAllAddress()
        {
            List<Address> addresses = new List<Address>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Address ORDER BY ID";

                //commit
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            addresses.Add(CreateAddressFromReader(reader));
                        }
                    }
                }
            }
            return addresses;
        }

        //Insert a address object
        public Address InsertAddress(Address address)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Address (City, Street, Zipcode, HouseNumber)" +
                    "VALUES (@city, @street, @zipcode, @housenumber)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@city", address.City);
                    command.Parameters.AddWithValue("@street", address.Street);
                    command.Parameters.AddWithValue("@zipcode", address.Zipcode);
                    command.Parameters.AddWithValue("@housenumber", address.HouseNumber);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return address;
            }
        }

        //Delete a address object
        public bool DeleteAddress(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Address WHERE ID=@id";
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

        //Update a address object
        public bool UpdateAddress(Address address)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE Address" +
                    " SET City=@city, Street=@street, Zipcode=@zipcode, HouseNumber=@housenumber" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", address.Id);
                    command.Parameters.AddWithValue("@city", address.City);
                    command.Parameters.AddWithValue("@street", address.Street);
                    command.Parameters.AddWithValue("@zipcode", address.Zipcode);
                    command.Parameters.AddWithValue("@housenumber", address.HouseNumber);
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

        //Get a address object by id
        public Address GetAddressById(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Address WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            address = CreateAddressFromReader(reader);
                        }
                    }
                }
            }
            return address;
        }

        private Address CreateAddressFromReader(SqlDataReader reader)
        {
            return new Address(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToString(reader["City"]),
                 Convert.ToString(reader["Street"]),
                 Convert.ToString(reader["Zipcode"]),
                 Convert.ToString(reader["HouseNumber"]));
        }
    }
}