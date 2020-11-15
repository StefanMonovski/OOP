using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    class Vehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
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

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
