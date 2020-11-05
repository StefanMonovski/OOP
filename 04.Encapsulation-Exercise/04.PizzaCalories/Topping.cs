using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Topping
    {
        private string toppingType;
        private double weight;
        private double toppingTypeCalories;
        private readonly List<string> validToppingTypes = new List<string>() { "meat", "veggies", "cheese", "sauce" };

        private string ToppingType
        {
            get
            {
                return toppingType;
            }
            set
            {
                if (!validToppingTypes.Contains(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
                switch (toppingType.ToLower())
                {
                    case "meat": toppingTypeCalories = 1.2; break;
                    case "veggies": toppingTypeCalories = 0.8; break;
                    case "cheese": toppingTypeCalories = 1.1; break;
                    case "sauce": toppingTypeCalories = 0.9; break;
                }
            }
        }

        private double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public double GetToppingCalories()
        {
            return 2.0 * weight * toppingTypeCalories;
        }
    }
}
