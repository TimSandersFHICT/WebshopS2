using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Review
    {
        private int id;
        private int accountid;
        private int productid;
        private string rating;
        private string reviewtext;

        public int Id { get { return id; } set { id = value; } }
        public int AccountId { get { return accountid; } set { accountid = value; } }
        public int ProductId { get { return productid; } set { productid = value; } }
        public string Rating { get { return rating; } set { rating = value; } }
        public string ReviewText { get { return reviewtext; } set { reviewtext = value; } }

        public Review(int id, int accountid, int productid, string rating, string reviewtext)
        {
            this.id = id;
            this.accountid = accountid;
            this.productid = productid;
            this.rating = rating;
            this.reviewtext = reviewtext;
        }

        public Review(int accountid, int productid, string rating, string reviewtext):this(-1, accountid, productid, rating, reviewtext)
        {

        }
    }
}