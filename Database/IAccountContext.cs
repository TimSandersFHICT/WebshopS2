using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IAccountContext
    {
        List<Account> GetAllAccounts();
        Administrator InsertAdministrator(Administrator administrator);
        Customer InsertCustomer(Customer customer);
        bool DeleteAccount(int id);
        bool UpdateCustomer(Customer customer);
        List<Address> GetAllAddress();
        Address InsertAddress(Address address);
        bool DeleteAddress(int id);
        bool UpdateAddress(Address address);
        Address GetAddressById(int id);
    }
}
