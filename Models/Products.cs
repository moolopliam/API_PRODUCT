using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Products
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? BuyPrice { get; set; }
        public string Img { get; set; }
        public int? CategoryCode { get; set; }

    }

    public class ProductReq
    {
        public string ProductName { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int CategoryCode { get; set; }
    }
}
