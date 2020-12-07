using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Prototype
{
    class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            string ingredients = GetIngredients();
            Console.WriteLine($"Cloning sandwich with ingredients: {ingredients}");
            return (SandwichPrototype)MemberwiseClone();
        }

        private string GetIngredients()
        {
            return $"{bread}, {meat}, {cheese}, {veggies}";
        }
    }
}
