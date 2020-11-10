using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Military
{
    class Repair : IRepair
    {
        public string Name { get; set; }
        public int Hours { get; set; }

        public Repair(string name, int hours)
        {
            Name = name;
            Hours = hours;
        }

        public override string ToString()
        {
            return $"Part Name: {Name} Hours Worked: {Hours}";
        }
    }
}
