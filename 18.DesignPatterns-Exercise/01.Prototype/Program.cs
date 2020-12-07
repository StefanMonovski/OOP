using System;

namespace _01.Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["Bacon"] = new Sandwich("weat", "bacon", "mozzarella", "tomato");
            sandwichMenu["Turkey"] = new Sandwich("rye", "turkey", "swiss", "lettuce");
            sandwichMenu["Salami"] = new Sandwich("white", "salami", "cheese", "olives");

            Sandwich baconClone = (Sandwich)sandwichMenu["Bacon"].Clone();
            Sandwich turkeyClone = (Sandwich)sandwichMenu["Turkey"].Clone();
            Sandwich salamiClone = (Sandwich)sandwichMenu["Salami"].Clone();
        }
    }
}
