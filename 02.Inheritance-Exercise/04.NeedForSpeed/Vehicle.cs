using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class Vehicle
    {
        public double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption { get; set; }
        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        public Vehicle(int horsePower, double fuel)
        {
            FuelConsumption = DefaultFuelConsumption;
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual void Drive(double kilometers)
        {
            Fuel -= FuelConsumption * kilometers;
        }
    }
}
