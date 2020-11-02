using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class SportCar : Car
    {
        public override double FuelConsumption { get => DefaultFuelConsumption; set => DefaultFuelConsumption = 10; }

        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }
    }
}
