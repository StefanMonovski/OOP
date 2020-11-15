using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split();
            string[] truckInput = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));
            int numberInput = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberInput; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                if (inputData[0] == "Drive")
                {
                    if (inputData[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(inputData[2])));
                    }
                    else if (inputData[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(inputData[2])));
                    }
                }
                else if (inputData[0] == "Refuel")
                {
                    if (inputData[1] == "Car")
                    {
                        car.Refuel(double.Parse(inputData[2]));
                    }
                    else if (inputData[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(inputData[2]));
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
