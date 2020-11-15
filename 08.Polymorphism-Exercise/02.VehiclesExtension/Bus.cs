using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            :base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption = fuelConsumption + 1.4;
        }
    }
}
