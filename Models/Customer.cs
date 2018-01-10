using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Customer : Account
    {

        private string creditcardinfo;
        private string phonenumber;
        private string firstname;
        private string lastname;
        private string shippinginfo;


        public string CreditCardInfo { get { return creditcardinfo; } set { creditcardinfo = value; } }
        public string PhoneNumber { get { return phonenumber; } set { phonenumber = value; } }
        public string FirstName { get { return firstname; } set { firstname = value; } }
        public string LastName { get { return lastname; } set { lastname = value; } }
        public string ShippingInfo { get { return shippinginfo; } set { shippinginfo = value; } }

        public Customer(string creditcardinfo, string phonenumber, string firstname, string lastname, string shippinginfo,int id, int addressid,  string username, string password, string email) : base(id, addressid, username, password, email)
        {
            this.creditcardinfo = creditcardinfo;
            this.phonenumber = phonenumber;
            this.firstname = firstname;
            this.lastname = lastname;
            this.shippinginfo = shippinginfo;
        }

        public Customer(int id, string creditcardinfo, string phonenumber, string firstname, string lastname, string shippinginfo) : base(id)
        {
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