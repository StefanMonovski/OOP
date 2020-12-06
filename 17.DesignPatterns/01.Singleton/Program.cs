using System;

namespace _01.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            SingletonDatabase firstSingletonDatabase = SingletonDatabase.Instance;
            SingletonDatabase secondSingletonDatabase = SingletonDatabase.Instance;
            SingletonDatabase thirdSingletonDatabase = SingletonDatabase.Instance;
            SingletonDatabase fourthSingletonDatabase = SingletonDatabase.Instance;
            Console.WriteLine(firstSingletonDatabase.GetData(0));
            Console.WriteLine(secondSingletonDatabase.GetData(1));
            Console.WriteLine(thirdSingletonDatabase.GetData(2));
            Console.WriteLine(fourthSingletonDatabase.GetData(3));
        }
    }
}
