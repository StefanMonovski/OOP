using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            :base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption = fuelConsumption + 0.9;
        }
    }
}
