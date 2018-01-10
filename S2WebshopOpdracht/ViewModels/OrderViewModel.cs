using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2WebshopOpdracht.ViewModels
{
    public class OrderViewModel
    {
        public string DeliveryName { get; set; }
        public string BillingName { get; set; }
        public string Username { get; set; }
        public bool OrderStatus { get; set; }
    }
}