using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class Car : Vehicle
    {
        public override double FuelConsumption { get => DefaultFuelConsumption; set => DefaultFuelConsumption = 3; }

        public Car(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }
    }
}
