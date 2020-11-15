using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    class Vehicle
    {
        private double fuelQuantity;
        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }

        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;
        }

        public string Drive(double kilometers)
        {
            if (FuelQuantity - FuelConsumption * kilometers >= 0)
            {
                FuelQuantity -= FuelConsumption * kilometers;
                return $"{GetType().Name} travelled {kilometers} km";
            }
            else
            {
                return $"{GetType().Name} needs refueling";
            }
        }

        public void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                if (this is Truck)
                {
                    FuelQuantity += liters * 0.95;
                }
                else
                {
                    FuelQuantity += liters;
                }
            }  
        }
    }
}
