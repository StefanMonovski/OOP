using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Felines
{
    class Cat : Feline
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override string LivingRegion { get; set; }
        public override string Breed { get; set; }

        public Cat(string name, double weight, string livingRegion, string breed) 
            :base(name, weight, livingRegion, breed)
        {
        }

        public override string Feed(Food food, int quantity)
        {
            if (!(food is Vegetable || food is Meat))
            {
                return "Meow" + Environment.NewLine + base.Feed(food, quantity);
            }
            else
            {
                FoodEaten += quantity;
                Weight += quantity * 0.30;
                return "Meow";
            }
        }
    }
}
