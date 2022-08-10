using System;
using System.Collections.Generic;
using System.Linq;

namespace SystemRules
{
    public class Customer
    {
        public Customer()
        {
            Products = new List<Product>();
        }
        public DateTime? DateOfFirstPurchase { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<Product> Products { get; set; }
        public decimal Discount { get; set; }
        public bool FreeShipping { get; set; }
        public int TotalValue { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}