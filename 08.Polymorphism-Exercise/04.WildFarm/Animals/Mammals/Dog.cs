using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Mammals
{
    class Dog : Mammal
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override string LivingRegion { get; set; }

        public Dog(string name, double weight, string livingRegion) 
            :base(name, weight, livingRegion)
        {
        }

        public override string Feed(Food food, int quantity)
        {
            if (!(food is Meat))
            {
                return "Woof!" + Environment.NewLine + base.Feed(food, quantity);
            }
            else
            {
                FoodEaten += quantity;
                Weight += quantity * 0.40;
                return "Woof!";
            }
        }
    }
}
