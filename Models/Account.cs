using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public abstract class Account
    {
        private int id;
        private int addressid;
        private Customer customer;
        private Administrator administrator;
        private string username;
        private string password;
        private string email;

        public int Id { get { return id; } set { id = value; } }
        public int AddressId { get { return addressid; } set { addressid = value; } }
        public Customer Customer { get { return customer; } set { customer = value; } }
        public Administrator Administrator { get { return administrator; } set { administrator = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }

        public Account(int id, int addressid, Customer customer, string username, string password, string email)
        {
            this.id = id;
            this.addressid = addressid;
            this.customer = customer;
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public Account(int id, int addressid, Administrator administrator, string username, string password, string email)
            :this(id, addressid, username, password, email)
        {
            this.administrator = administrator;
        }

        private Account(int id, int addressid, string username, string password, string email)
        {
            this.id = id;
            this.addressid = addressid;
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public Account(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public Account(int id)
        {
           
        }
    }
}