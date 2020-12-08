using System;
using System.Collections.Generic;
using System.Text;

namespace Robots
{
    public class Robot
    {
        public Robot(string name, int maximumBattery)
        {
            Name = name;
            MaximumBattery = maximumBattery;
            Battery = maximumBattery;
        }

        public string Name { get; set; }
        public int Battery { get; set; }
        public int MaximumBattery { get; }
    }
}
