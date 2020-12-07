using System;

namespace _02.Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexGift toyBox = new ComplexGift("Toy box", 0);
            toyBox.Add(new SimpleGift("truck", 20));
            toyBox.Add(new SimpleGift("soldier", 10));
            toyBox.Add(new SimpleGift("puzzle", 50));
            Console.WriteLine($"Total gift price of toy box is {toyBox.CalculateGiftPrice()}");
        }
    }
}
