using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2WebshopOpdracht.Models
{
    public class Address
    {
        private int id;
        private string city;
        private string street;
        private string zipcode;
        private string housenumber;

        public int Id { get { return id; } set { id = value; } }
        public string City { get { return city; } set { city = value; } }
        public string Street { get { return street; } set { street = value; } }
        public string Zipcode { get { return zipcode; } set { zipcode = value; } }
        public string HouseNumber { get { return housenumber; } set { housenumber = value; } }

        public Address(int id, string city, string street, string zipcode, string housenumber)
        {
            this.id = id;
            this.city = city;
            this.street = street;
            this.zipcode = zipcode;
            this.housenumber = housenumber;
        }

        public Address(string city, string street, string zipcode, string housenumber):this(-1, city, street, zipcode, housenumber)
        {

        }
    }
}