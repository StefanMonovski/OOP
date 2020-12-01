using System;
using System.Collections.Generic;
using System.Text;

namespace _01.InStock
{
    public class Product
    {
        public Product(string label, decimal price)
        {
            Label = label;
            Price = price;
            Quantity = 0;
        }

        public string Label { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
