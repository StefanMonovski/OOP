using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
            :base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption = fuelConsumption + 1.6;
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters * 0.95;
        }
    }
}
