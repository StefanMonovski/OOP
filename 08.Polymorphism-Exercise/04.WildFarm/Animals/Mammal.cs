using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    abstract class Mammal : Animal
    {
        public abstract string LivingRegion { get; set; }

        protected Mammal(string name, double weight, string livingRegion) 
            :base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
