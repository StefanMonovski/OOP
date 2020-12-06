using System;

namespace _02.Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new CarBuilderFacade().Info().WithType("BMW").WithColor("red").WithNumberOfDoors(4).Address().InCity("Sofia").AtAddress("Center").Build();
            Console.WriteLine(car);
        }
    }
}
