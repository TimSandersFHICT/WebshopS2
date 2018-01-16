using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class AccountSQLContextTest
    {
        AccountLogic accountlogic = new AccountLogic();

        [TestMethod()]
        public void GetAllAccountsTest()
        {
            //Fill list with all accounts stored in logic
            List<Account> accountlist = accountlogic.GetAllAccounts();
            Account[] accountlijst = accountlist.ToArray();

            //Check both entries in array if expected username is seen
            Assert.AreEqual("tim2912", accountlijst[0].Username);
            Assert.AreEqual("luc2907", accountlijst[1].Username);
        }

        [TestMethod()]
        public void InsertAccountTest()
        {
            //Add new administrator to list
            Account administrator = new Administrator("AdminRob", 3, 3, "robbie", "123", "rwp.sanders@gmail.com");
            accountlogic.InsertAccount(administrator);

            //Add new customer to list
            Account customer = new Customer("432143214321", "0620176856", "Jose", "Kaan", "Aardbeistraat 10", 4, 4, "jose", "123", "jose@gmail.com");
            accountlogic.InsertAccount(customer);

            //Check list if new administrator & customer are added
            List<Account> accountlist = accountlogic.GetAllAccounts();
            Account[] accountlijst = accountlist.ToArray();
            Assert.AreEqual("robbie", accountlijst[2].Username);
            Assert.AreEqual("jose", accountlijst[3].Username);
        }

        [TestMethod()]
        public void DeleteAccountTest()
        {
            //Delete account with same id
            //Returns true if it worked
            Assert.AreEqual(true, accountlogic.DeleteAccount(1));
        }

        [TestMethod()]
        public void GetAccountByIdTest()
        {
            //Get account with id
            Account account = accountlogic.GetAccountById(1);

            //Check if account is what expected
            Assert.AreEqual("tim2912", account.Username);
        }

        [TestMethod()]
        public void UpdateAccountTest()
        {
            //Make changes to existing account 
            Account account = new Administrator("AdminLuc", 2, 2, "AdminLuc2907", "123", "luc2907@live.nl");
            accountlogic.UpdateAccount(account);

            //Check list if changes have been made
            List<Account> accountlist = accountlogic.GetAllAccounts();
            Account[] accountlijst = accountlist.ToArray();
            Assert.AreEqual("AdminLuc2907", accountlijst[1].Username);
        }

        [TestMethod()]
        public void GetAllAddressesTest()
        {
            //Fill list with all addresses stored in logic
            List<Address> addresslist = accountlogic.GetAllAddresses();
            Address[] addresslijst = addresslist.ToArray();

            //Check both entries in array if expected street is seen
            Assert.AreEqual("Avocadohof", addresslijst[0].Street);
            Assert.AreEqual("Aardbeistraat", addresslijst[1].Street);
        }

        [TestMethod()]
        public void InsertAddressTest()
        {
            //Add new address to list
            Address address = new Address(3, "Eindhoven", "Bijerlandlaan", "5632SP", "13");
            accountlogic.InsertAddress(address);


            //Check list if new address is added
            List<Address> addresslist = accountlogic.GetAllAddresses();
            Address[] addresslijst = addresslist.ToArray();
            Assert.AreEqual("Bijerlandlaan", addresslijst[2].Street);
        }

        [TestMethod()]
        public void DeleteAddressTest()
        {
            //Delete address with same id
            //Returns true if it worked
            Assert.AreEqual(true, accountlogic.DeleteAddress(1));
        }

        [TestMethod()]
        public void GetAddressByIdTest()
        {
            //Get address with id
            Address address = accountlogic.GetAddressById(1);

            //Check if address is what expected
            Assert.AreEqual("Avocadohof", address.Street);
        }

        [TestMethod()]
        public void UpdateAddressTest()
        {
            //Make changes to existing address 
            Address address = new Address(2, "Eindhoven", "Kennedrylaan", "5632SG", "25");
            accountlogic.UpdateAddress(address);

            //Check list if changes have been made
            List<Address> addresslist = accountlogic.GetAllAddresses();
            Address[] addresslijst = addresslist.ToArray();
            Assert.AreEqual("Kennedrylaan", addresslijst[1].Street);
            Assert.AreEqual("5632SG", addresslijst[1].Zipcode);
            Assert.AreEqual("25", addresslijst[1].HouseNumber);
        }

        private class AccountLogic
        {
            private List<Account> accounts;
            private List<Address> addresses;

            public AccountLogic()
            {
                //Make new account list
                accounts = new List<Account>()
                {
                    new Customer("432143214321", "0620148485", "Tim", "Sanders", "Avocadohof 3", 1, 1, "tim2912", "123", "tim2912@live.nl"),
                    new Administrator("AdminLuc", 2, 2, "luc2907", "123", "luc2907@live.nl")
                };
                //Make new address list
                addresses = new List<Address>()
                {
                    new Address(1, "Eindhoven", "Avocadohof", "5632XP", "3"),
                    new Address(2, "Eindhoven", "Aardbeistraat", "5632SH", "10"),
                };
            }

            public List<Account> GetAllAccounts()
            {
                return accounts;
            }

            public List<Address> GetAllAddresses()
            {
                return addresses;
            }

            public Account InsertAccount(Account account)
            {
                //Add account to the list
                accounts.Add(account);
                return account;
            }

            public Address InsertAddress(Address address)
            {
                //Add address to the list
                addresses.Add(address);
                return address;
            }

            public bool DeleteAccount(int id)
            {
                if (id != 0)
                {
                    //Remove account at index id - 1
                    accounts.RemoveAt(id - 1);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool DeleteAddress(int id)
            {
                if (id != 0)
                {
                    //Remove address at index id - 1
                    addresses.RemoveAt(id - 1);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public Account GetAccountById(int id)
            {
                //List to array
                Account[] accountlist = accounts.ToArray();
                if (id != 0)
                {
                    //Return account at index id - 1 because array index starts at 0
                    return accountlist[id - 1];
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            public Address GetAddressById(int id)
            {
                //List to array
                Address[] addresslist = addresses.ToArray();
                if (id != 0)
                {
                    //Return address at index id - 1 because array index starts at 0
                    return addresslist[id - 1];
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            public bool UpdateAccount(Account account)
            {
                //List to array
                Account[] accountlist = accounts.ToArray();

                //Check array for same id as inserted account
                if (Convert.ToBoolean(account.Id = accountlist[account.Id - 1].Id))
                {
                    //Update account in array with same id
                    accountlist[account.Id - 1].Username = account.Username;
                    accountlist[account.Id - 1].Password = account.Password;
                    accountlist[account.Id - 1].Email = account.Email;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool UpdateAddress(Address address)
            {
                //List to array
                Address[] addresslist = addresses.ToArray();

                //Check array for same id as inserted address
                if (Convert.ToBoolean(address.Id = addresslist[address.Id - 1].Id))
                {
                    //Update address in array with same id
                    addresslist[address.Id - 1].Street = address.Street;
                    addresslist[address.Id - 1].City = address.City;
                    addresslist[address.Id - 1].Zipcode = address.Zipcode;
                    addresslist[address.Id - 1].HouseNumber = address.HouseNumber;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
