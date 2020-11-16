using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    abstract class Animal
    {
        public abstract string Name { get; set; }
        public abstract double Weight { get; set; }
        public abstract int FoodEaten { get; set; }

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public virtual string Feed(Food food, int quantity)
        {
            return $"{GetType().Name} does not eat {food.GetType().Name}!";
        }
    }
}
