using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Mammals
{
    class Mouse : Mammal
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override string LivingRegion { get; set; }

        public Mouse(string name, double weight, string livingRegion) 
            :base(name, weight, livingRegion)
        {
        }

        public override string Feed(Food food, int quantity)
        {
            if (!(food is Vegetable || food is Fruit))
            {
                return "Squeak" + Environment.NewLine + base.Feed(food, quantity);
            }
            else
            {
                FoodEaten += quantity;
                Weight += quantity * 0.10;
                return "Squeak";
            }
        }
    }
}
