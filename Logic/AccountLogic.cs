using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Models;

namespace Logic
{
    public class AccountLogic
    {
        private AccountRepository accountrepo = new AccountRepository(new AccountSQLContext());

        //Logic for getting all accounts
        public List<Account> GetAllAccounts()
        {
            return accountrepo.GetAllAccounts();
        }
        
        //Logic for inserting an account
        public Account InsertAccount(Account account, Administrator administrator, Customer customer)
        {
            if(account is Administrator)
            {
               return accountrepo.InsertAdministrator(administrator);
            }
            else if (account is Customer)
            {
                return accountrepo.InsertCustomer(customer);
            }
            else if (account == null)
            {
                throw new ArgumentException($"No account found.");
            }
            else 
            {
                throw new ArgumentException($"An unexpected error occurred.");
            }
        }

        //Logic for inserting an customer
        public Customer InsertCustomer(Customer customer)
        {
       
            if (customer == null)
            {
                throw new ArgumentException($"No account found.");
            }
            else
            {
               return accountrepo.InsertCustomer(customer);
            }
        }

        //Logic for deleting a customer
        public bool DeleteCustomer(int id)
        {
            Account account = accountrepo.GetAccountById(id);
            if (account == null)
            {
                throw new ArgumentException($"No account found with id {id}.");
            }
            else
            {
                return accountrepo.DeleteCustomer(id);
            }
        }

        //Logic for deleting a administrator
        public bool DeleteAdministrator(int id)
        {
            Account account = accountrepo.GetAccountById(id);
            if (account == null)
            {
                throw new ArgumentException($"No account found with id {id}.");
            }
            else
            {
                return accountrepo.DeleteAdministrator(id);
            }
        }

        //Logic for getting a account by id
        public Account GetAccountById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"No account found.");
            }
            else
            {
                return accountrepo.GetAccountById(id);
            }
        }

        //Logic for updating a account
        public bool UpdateAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentException($"No account found.");
            }
            else
            {
                return accountrepo.UpdateAccount(account);
            }
        }

        //Logic for logging in 
        public Account Login(string username, string password)
        {
            if (username == null || password == null)
            {
                throw new ArgumentException($"No log in information found.");
            }
            else
            {
                return accountrepo.Login(username, password);
            }
        }

        //Logic for getting all addresses
        public List<Address> GetAllAddress()
        {
            return accountrepo.GetAllAddress();
        }

        //Logic for inserting a address
        public Address InsertAddress(Address address)
        {
            if (address == null)
            {
                throw new ArgumentException($"No address found.");
            }
            else
            {
                return accountrepo.InsertAddress(address);
            }
        }

        //Logic for deleting a address
        public bool DeleteAddress(int id)
        {
            Address address = accountrepo.GetAddressById(id);
            if (address == null)
            {
                throw new ArgumentException($"No address found with id {id}.");
            }
            else
            {
                return accountrepo.DeleteAddress(id);
            }
        }

        //Logic for updating a address
        public bool UpdateAddress(Address address)
        {
            if (address == null)
            {
                throw new ArgumentException($"No address found.");
            }
            else
            {
                return accountrepo.UpdateAddress(address);
            }
        }

        //Logic for getting a address by id
        public Address GetAddressById(int id)
        {
            if(id == 0)
            {
                throw new ArgumentException($"No address found.");
            }
            else
            {
                return accountrepo.GetAddressById(id);
            }
        }

        public int GetLastInsertedAddressID()
        {
            return accountrepo.GetLastInsertedAddressID();
        }
    }
}
