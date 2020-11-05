using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    class Person
    {
        private string name;
        private double money;
        private List<Product> products;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public void BuyProduct(Product product)
        {
            if (money - product.Cost < 0)
            {
                Console.WriteLine($"{name} can't afford {product.Name}");
            }
            else
            {
                money -= product.Cost;
                products.Add(product);
                Console.WriteLine($"{name} bought {product.Name}");
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(name);
            output.Append(" - ");
            List<string> productNames = new List<string>();
            if (products.Count == 0)
            {
                productNames.Add("Nothing bought");
            }
            else
            {
                for (int i = 0; i < products.Count; i++)
                {
                    productNames.Add(products[i].Name);
                }
            }
            output.Append(string.Join(", ", productNames));
            return output.ToString();
        }
    }
}
