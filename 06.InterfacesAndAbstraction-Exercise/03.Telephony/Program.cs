using System;
using System.Linq;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartPhone smartPhone = new SmartPhone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();
            foreach (string item in numbers)
            {
                if (!item.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (item.Length == 10)
                {
                    smartPhone.Call(item);
                }
                else if (item.Length == 7)
                {
                    stationaryPhone.Call(item);
                }
            }
            foreach (string item in urls)
            {
                if (item.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartPhone.Browse(item);
                }
            }
        }
    }
}
