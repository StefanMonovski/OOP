using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] peopleData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peopleData.Length; i++)
            {
                string[] personData = peopleData[i].Split("=");
                try
                {
                    Person person = new Person(personData[0], double.Parse(personData[1]));
                    people.Add(person);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }                 
            }
            List<Product> products = new List<Product>();
            string[] productsData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsData.Length; i++)
            {
                string[] productData = productsData[i].Split("=");
                try
                {
                    Product product = new Product(productData[0], double.Parse(productData[1]));
                    products.Add(product);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
            }
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandData = command.Split();
                try
                {
                    if (people.Count > 0 && products.Count > 0)
                    {
                        people.Find(x => x.Name == commandData[0]).BuyProduct(products.Find(x => x.Name == commandData[1]));
                    }                    
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }    
            }
            foreach (Person item in people)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
