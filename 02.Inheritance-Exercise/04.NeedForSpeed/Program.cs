using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            FamilyCar familyCar = new FamilyCar(int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            SportCar sportCar = new SportCar(int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            raceMotorcycle.Drive(10);
            crossMotorcycle.Drive(10);
            familyCar.Drive(10);
            sportCar.Drive(10);
            Console.WriteLine(raceMotorcycle.FuelConsumption);
            Console.WriteLine(crossMotorcycle.FuelConsumption);
            Console.WriteLine(familyCar.FuelConsumption);
            Console.WriteLine(sportCar.FuelConsumption);
        }
    }
}
