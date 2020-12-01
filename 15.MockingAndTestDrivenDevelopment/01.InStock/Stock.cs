using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.InStock
{
    public class Stock
    {
        private List<Product> Products { get; set; }

        public Stock()
        {
            Products = new List<Product>();
        }

        public int Count => Products.Count;

        public void Add(Product product)
        {
            if (Contains(product))
            {
                throw new ArgumentException("Added product exists");
            }
            Products.Add(product);
        }

        public bool Contains(Product product)
        {
            if (Products.Exists(x => x.Label == product.Label))
            {
                return true;
            }
            return false;
        }

        public Product Find(int index)
        {
            if (index <= 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            return Products[index - 1];
        }

        public Product FindByLabel(string label)
        {
            if (!Products.Exists(x => x.Label == label))
            {
                throw new ArgumentException("Searched product does not exist");
            }
            return Products.Find(x => x.Label == label);
        }

        public List<Product> FindAllInPriceRange(decimal low, decimal high)
        {
            List<Product> productsRange = new List<Product>();
            foreach (Product item in Products)
            {
                if (item.Price >= low && item.Price <= high)
                {
                    productsRange.Add(item);
                }
            }
            return productsRange.OrderByDescending(x => x.Price).ToList();
        }

        public List<Product> FindAllByPrice(decimal price)
        {
            List<Product> productsRange = new List<Product>();
            foreach (Product item in Products)
            {
                if (item.Price == price)
                {
                    productsRange.Add(item);
                }
            }
            return productsRange;
        }

        public List<Product> FindMostExpensiveProducts(int number)
        {
            List<Product> productsRange = new List<Product>();
            foreach (Product item in Products.OrderByDescending(x => x.Price))
            {
                if (productsRange.Count < number)
                {
                    productsRange.Add(item);
                }
                else
                {
                    break;
                }
            }
            return productsRange;
        }

        public List<Product> FindAllByQuantity(int quantity)
        {
            List<Product> productsRange = new List<Product>();
            foreach (Product item in Products)
            {
                if (item.Quantity == quantity)
                {
                    productsRange.Add(item);
                }
            }
            return productsRange;
        }
    }
}
