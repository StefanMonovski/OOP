using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class RaceMotorcycle : Motorcycle
    {
        public override double FuelConsumption { get => DefaultFuelConsumption; set => DefaultFuelConsumption = 8; }

        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }
    }
}
