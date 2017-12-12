using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2WebshopOpdracht.Models
{
    public class Order
    {
        private int id;
        private int accountid;
        private string deliveryname;
        private string billingname;
        private bool orderstatus;

        public int Id { get { return id; } set { id = value; } }
        public int AccountId { get { return accountid; } set { accountid = value; } }
        public string DeliveryName { get { return deliveryname; } set { deliveryname = value; } }
        public string BillingName { get { return billingname; } set { billingname = value; } }
        public bool OrderStatus { get { return orderstatus; } set { orderstatus = value; } }

        public Order(int id, int accountid, string deliveryname, string billingname, bool orderstatus)
        {
            this.id = id;
            this.accountid = accountid;
            this.deliveryname = deliveryname;
            this.billingname = billingname;
            this.orderstatus = orderstatus;
        }

        public Order(int accountid, string deliveryname, string billingname, bool orderstatus):this(-1, accountid, deliveryname, billingname, orderstatus)
        {

        }
    }
}