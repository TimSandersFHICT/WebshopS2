using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2WebshopOpdracht.ViewModels
{
    public class ProductViewModel
    {
        public string Rating { get; set; }
        public string ReviewText { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}