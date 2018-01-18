using Models;
using System;
using System.Collections.Generic;
using System.Data;
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
                string queryadmin = "INSERT INTO Administrator (AccountID, AdminName)" +
                    "VALUES (@adminname)";
                string queryaccount = "INSERT INTO Account (AddressID, Username, Password, Email)" +
                   "VALUES (@addressid, @username, @password, @email)";

                using (SqlCommand command = new SqlCommand(queryaccount, connection))
                {
                    command.Parameters.AddWithValue("@addressid", administrator.AddressId);
                    command.Parameters.AddWithValue("@username", administrator.Username);
                    command.Parameters.AddWithValue("@password", administrator.Password);
                    command.Parameters.AddWithValue("@email", administrator.Email);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                using (SqlCommand command = new SqlCommand(queryadmin, connection))
                {
                    command.Parameters.AddWithValue("@accountid", administrator.Id = administrator.AddressId);
                    command.Parameters.AddWithValue("@adminname", administrator.AdminName);
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
                string querycustomer = "INSERT INTO Customer (AccountID, CreditCardInfo, PhoneNumber, FirstName, LastName, ShippingInfo)" +
                    "VALUES (@accountid, @creditcardinfo, @phonenumber, @firstname, @lastname, @shippinginfo)";

                string queryaccount = "INSERT INTO Account (AddressID, Username, Password, Email)" +
                   "VALUES (@addressid, @username, @password, @email)";



                using (SqlCommand command = new SqlCommand(queryaccount, connection))
                {
                    command.Parameters.AddWithValue("@addressid", customer.AddressId);
                    command.Parameters.AddWithValue("@username", customer.Username);
                    command.Parameters.AddWithValue("@password", customer.Password);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    try
                    {

                        command.ExecuteNonQuery();

                    }
                    catch (SqlException e)
                    {

                    }
                }    
                using (SqlCommand command = new SqlCommand(querycustomer, connection))
                {
                    command.Parameters.AddWithValue("@accountid", customer.Id = customer.AddressId);
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
               
                return customer;
            }
        }

        //Delete a customer object
        public bool DeleteCustomer(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string queryaccount = "DELETE FROM Account WHERE ID=@id";
                string querycustomer = "DELETE FROM Customer WHERE AccountID=@id";

                using (SqlCommand command = new SqlCommand(querycustomer, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
                using (SqlCommand command = new SqlCommand(queryaccount, connection))
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

        //Delete a administrator object
        public bool DeleteAdministrator(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string queryaccount = "DELETE FROM Account WHERE ID=@id";
                string querycustomer = "DELETE FROM Administrator WHERE AccountID=@id";

                using (SqlCommand command = new SqlCommand(queryaccount, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
                using (SqlCommand command = new SqlCommand(querycustomer, connection))
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

        

        //Get a account object by id
        public Account GetAccountById(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Account WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            account = CreateAccountFromReader(reader);
                        }
                    }
                }
            }
            return account;
        }

        //Update a account object
        public bool UpdateAccount(Account account)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE Account" +
                    " SET AddressID=@addressid, Username=@username, Email=@email, Password=@password" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", account.Id);
                    command.Parameters.AddWithValue("@addressid", account.AddressId);
                    command.Parameters.AddWithValue("@username", account.Username);
                    command.Parameters.AddWithValue("@email", account.Email);
                    command.Parameters.AddWithValue("@password", account.Password);
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

        //Get username and passwords
        public Account Login(string username, string password)
        {
            SqlConnection connection = Database.Connection;

            //Check the state of the connection
            ConnectionState conState = connection.State;

            if (conState == ConnectionState.Open)
            {
                string query = "SELECT * FROM Account FULL OUTER JOIN Customer ON Customer.AccountID = Account.ID FULL OUTER JOIN Administrator ON Account.ID = Administrator.AccountID WHERE Username=@username and Password=@password ";
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteScalar();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Account account = CreateAccountFromReader(reader);
                            
                            return account;
                        }
                    }
                }
            }
            return null;
        }

        private Account CreateAccountFromReader(SqlDataReader reader)
        {
            if (account is Administrator)
            {
                return new Administrator(               
                 Convert.ToString(reader["AdminName"]),
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToInt32(reader["AddressID"]),
                 Convert.ToString(reader["Username"]),
                 Convert.ToString(reader["Password"]),
                 Convert.ToString(reader["Email"]));


            }
            else if(account is Customer)
            {
                return new Customer(
                 Convert.ToString(reader["CreditCardInfo"]),
                 Convert.ToString(reader["PhoneNumber"]),
                 Convert.ToString(reader["FirstName"]),
                 Convert.ToString(reader["LastName"]),
                 Convert.ToString(reader["ShippingInfo"]),
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToInt32(reader["AddressID"]),
                 Convert.ToString(reader["Username"]),
                 Convert.ToString(reader["Password"]),
                 Convert.ToString(reader["Email"]));
            }
            else
            {
                return new Customer(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToInt32(reader["AddressID"]),
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

        //Get Last inserted address id
        public int GetLastInsertedAddressID()
        {
            int addressid;
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT TOP 1 ID FROM Address ORDER BY ID DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    addressid = Convert.ToInt32(command.ExecuteScalar());
                    return addressid;
                }
            }
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