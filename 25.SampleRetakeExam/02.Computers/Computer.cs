using System;
using System.Collections.Generic;
using System.Text;

namespace Computers
{
    public class Computer
    {
        public Computer(string manufacturer, string model, decimal price)
        {
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
        }

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
    }
}
