using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Coffee : HotBeverage
    {
        public const double CoffeeMilliliters = 50;
        public const decimal CoffeePrice = 3.50M;
        public double Caffeine { get; set; }

        public Coffee(string name, double caffeine)
            : base(name, 0, 0)
        {
            Milliliters = CoffeeMilliliters;
            Price = CoffeePrice;
            Caffeine = caffeine;
        }
    }
}
