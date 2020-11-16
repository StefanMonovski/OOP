using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Birds
{
    class Owl : Bird
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override double WingSize { get; set; }

        public Owl(string name, double weight, double wingSize) 
            :base(name, weight, wingSize)
        {
        }

        public override string Feed(Food food, int quantity)
        {            
            if (!(food is Meat))
            {
                return "Hoot Hoot" + Environment.NewLine + base.Feed(food, quantity);
            }
            else
            {
                FoodEaten += quantity;
                Weight += quantity * 0.25;
                return "Hoot Hoot";
            }
        }
    }
}
