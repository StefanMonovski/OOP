using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int numberInput = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberInput; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                if (inputData.Length == 4)
                {
                    buyers.Add(new Citizen(inputData[0], int.Parse(inputData[1]), inputData[2], inputData[3]));
                }
                else if (inputData.Length == 3)
                {
                    buyers.Add(new Rebel(inputData[0], int.Parse(inputData[1]), inputData[2]));
                }
            }
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                var buyer = buyers.FirstOrDefault(x => x.Name == input);
                if (buyer != null)
                {
                    buyers.First(x => x.Name == input).BuyFood();
                }
            }
            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
