using S2WebshopOpdracht.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace S2WebshopOpdracht.App_DAL
{
    public class AccountSQLContext:IAccountContext
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

        private Account CreateAccountFromReader(SqlDataReader reader)
        {
            if(reader["CustomerID"] == DBNull.Value)
            {
                return new Administrator(
                    );

               
            }
            else if (reader["AdministratorID"] == DBNull.Value)
            {
                return new Customer(
                    );
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