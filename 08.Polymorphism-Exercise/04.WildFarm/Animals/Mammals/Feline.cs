using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    abstract class Feline : Mammal
    {
        public abstract string Breed { get; set; }

        protected Feline(string name, double weight, string livingRegion, string breed) 
            :base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
