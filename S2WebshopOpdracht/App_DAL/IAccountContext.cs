using S2WebshopOpdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2WebshopOpdracht.App_DAL
{
    public interface IAccountContext
    {
        List<Account> GetAllAccounts();
        List<Address> GetAllAddress();
        Address InsertAddress(Address address);
        bool DeleteAddress(int id);
        bool UpdateAddress(Address address);
        Address GetAddressById(int id);
    }
}
