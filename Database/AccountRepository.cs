using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database
{
    public class AccountRepository
    {
        private IAccountContext context;

        public AccountRepository(IAccountContext context)
        {
            this.context = context;
        }

        public List<Account> GetAllAccounts()
        {
            return context.GetAllAccounts();
        }

        public Administrator InsertAdministrator(Administrator administrator)
        {
            return context.InsertAdministrator(administrator);
        }

        public Customer InsertCustomer(Customer customer)
        {
            return context.InsertCustomer(customer);
        }

        public bool DeleteCustomer(int id)
        {
            return context.DeleteCustomer(id);
        }

        public bool DeleteAdministrator(int id)
        {
            return context.DeleteAdministrator(id);
        }

        public Account GetAccountById(int id)
        {
            return context.GetAccountById(id);
        }

        public bool UpdateAccount(Account account)
        {
            return context.UpdateAccount(account);
        }

        public List<Address> GetAllAddress()
        {
            return context.GetAllAddress();
        }

        public Address InsertAddress(Address address)
        {
            return context.InsertAddress(address);
        }

        public bool DeleteAddress(int id)
        {
            return context.DeleteAddress(id);
        }

        public bool UpdateAddress(Address address)
        {
            return context.UpdateAddress(address);
        }

        public Address GetAddressById(int id)
        {
            return context.GetAddressById(id);
        }

        Account Login(string username, string password)
        {
            return context.Login(username, password);
        }
    }
}