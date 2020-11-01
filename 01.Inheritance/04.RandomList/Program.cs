using System;
using System.Linq;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.AddRange(Console.ReadLine().Split().ToList());
            Console.WriteLine(randomList.RandomString());
            Console.WriteLine(string.Join(" ", randomList));
        }
    }
}
