using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2WebshopOpdracht.Models
{
    public class Customer
    {
        private int id;
        private string creditcardinfo;
        private string phonenumber;
        private string firstname;
        private string lastname;
        private string shippinginfo;

        public int Id { get { return id; } set { id = value; } }
        public string CreditCardInfo { get { return creditcardinfo; } set { creditcardinfo = value; } }
        public string PhoneNumber { get { return phonenumber; } set { phonenumber = value; } }
        public string FirstName { get { return firstname; } set { firstname = value; } }
        public string LastName { get { return lastname; } set { lastname = value; } }
        public string ShippingInfo { get { return shippinginfo; } set { shippinginfo = value; } }

        public Customer(int id, string creditcardinfo, string phonenumber, string firstname, string lastname, string shippinginfo)
        {
            this.id = id;
            this.creditcardinfo = creditcardinfo;
            this.phonenumber = phonenumber;
            this.firstname = firstname;
            this.lastname = lastname;
            this.shippinginfo = shippinginfo;
        }

        public Customer(string creditcardinfo, string phonenumber, string firstname, string lastname, string shippinginfo):this(-1, creditcardinfo, phonenumber, firstname, lastname, shippinginfo)
        {

        }

    }
}