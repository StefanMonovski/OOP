using System;

namespace Restaurant
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Coffee coffee = new Coffee(Console.ReadLine(), double.Parse(Console.ReadLine()));
            Tea tea = new Tea(Console.ReadLine(), decimal.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Soup soup = new Soup(Console.ReadLine(), decimal.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Fish fish = new Fish(Console.ReadLine(), decimal.Parse(Console.ReadLine()));
            Cake cake = new Cake(Console.ReadLine());
            Console.WriteLine($"{coffee.Name} {coffee.Price} {coffee.Milliliters} {coffee.Caffeine}");
            Console.WriteLine($"{tea.Name} {tea.Price} {tea.Milliliters}");
            Console.WriteLine($"{soup.Name} {soup.Price} {soup.Grams}");
            Console.WriteLine($"{fish.Name} {fish.Price} {fish.Grams}");
            Console.WriteLine($"{cake.Name} {cake.Price} {cake.Grams} {cake.Calories}");
        }
    }
}
