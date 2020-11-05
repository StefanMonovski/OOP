using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split();
                string[] doughInput = Console.ReadLine().Split();
                Dough dough = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));
                Pizza pizza = new Pizza(pizzaInput[1], dough);
                string input = "";
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingInput = input.Split();
                    Topping topping = new Topping(toppingInput[1], double.Parse(toppingInput[2]));
                    pizza.AddTopping(topping);
                }
                double pizzaCalories = pizza.GetPizzaCalories();
                Console.WriteLine($"{pizza.Name} - {pizzaCalories:f2} Calories.");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }            
        }
    }
}
