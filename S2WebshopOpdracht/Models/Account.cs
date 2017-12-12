using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2WebshopOpdracht.Models
{
    public abstract class Account
    {
        private int id;
        private int addressid;
        private int customerid;
        private int administratorid;
        private string username;
        private string password;
        private string email;

        public int Id { get { return id; } set { id = value; } }
        public int AddressId { get { return addressid; } set { addressid = value; } }
        public int CustomerId { get { return customerid; } set { customerid = value; } }
        public int AdministratorId { get { return administratorid; } set { administratorid = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }

        public Account(int id, int addressid, int customerid, int administratorid, string username, string password, string email)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public Account(int addressid, int customerid, int administratorid, string username, string password, string email) :this(-1, addressid, customerid, administratorid, username, password, email)
        {

        }

    }
}