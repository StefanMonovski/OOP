using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Felines
{
    class Tiger : Feline
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override string LivingRegion { get; set; }
        public override string Breed { get; set; }

        public Tiger(string name, double weight, string livingRegion, string breed) 
            :base(name, weight, livingRegion, breed)
        {
        }

        public override string Feed(Food food, int quantity)
        {
            if (!(food is Meat))
            {
                return "ROAR!!!" + Environment.NewLine + base.Feed(food, quantity);
            }
            else
            {
                FoodEaten += quantity;
                Weight += quantity * 1.00;
                return "ROAR!!!";
            }
        }
    }
}
