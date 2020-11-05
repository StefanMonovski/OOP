using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough
        {
            set
            {
                dough = value;
            }
        }

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public double GetPizzaToppingsCount()
        {
            return toppings.Count;
        }

        public double GetPizzaCalories()
        {
            double toppingsCalories = 0.0;
            foreach (Topping item in toppings)
            {
                toppingsCalories += item.GetToppingCalories();
            }
            return dough.GetDoughCalories() + toppingsCalories;
        }
    }
}
