using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Birds
{
    class Hen : Bird
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override double WingSize { get; set; }

        public Hen(string name, double weight, double wingSize) 
            :base(name, weight, wingSize)
        {
        }

        public override string Feed(Food food, int quantity)
        {
            FoodEaten += quantity;
            Weight += quantity * 0.35;
            return "Cluck";
        }
    }
}
