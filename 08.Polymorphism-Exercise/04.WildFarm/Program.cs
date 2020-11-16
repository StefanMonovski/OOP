using System;
using System.Collections.Generic;
using _04.WildFarm.Animals;
using _04.WildFarm.Animals.Birds;
using _04.WildFarm.Animals.Felines;
using _04.WildFarm.Animals.Mammals;
using _04.WildFarm.Foods;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>(); 
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalData = input.Split();
                if (animalData[0] == "Owl")
                {
                    animals.Add(new Owl(animalData[1], double.Parse(animalData[2]), double.Parse(animalData[3])));
                }
                else if (animalData[0] == "Hen")
                {
                    animals.Add(new Hen(animalData[1], double.Parse(animalData[2]), double.Parse(animalData[3])));
                }
                else if (animalData[0] == "Mouse")
                {
                    animals.Add(new Mouse(animalData[1], double.Parse(animalData[2]), animalData[3]));
                }
                else if (animalData[0] == "Dog")
                {
                    animals.Add(new Dog(animalData[1], double.Parse(animalData[2]), animalData[3]));
                }
                else if (animalData[0] == "Cat")
                {
                    animals.Add(new Cat(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4]));
                }
                else if (animalData[0] == "Tiger")
                {
                    animals.Add(new Tiger(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4]));
                }

                string[] foodData = Console.ReadLine().Split();
                Food food = null;
                if (foodData[0] == "Vegetable")
                {
                    food = new Vegetable(int.Parse(foodData[1]));
                }
                else if (foodData[0] == "Fruit")
                {
                    food = new Fruit(int.Parse(foodData[1]));
                }
                else if (foodData[0] == "Meat")
                {
                    food = new Meat(int.Parse(foodData[1]));
                }
                else if (foodData[0] == "Seeds")
                {
                    food = new Seeds(int.Parse(foodData[1]));
                }

                Console.WriteLine(animals[animals.Count - 1].Feed(food, food.Quantity));
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
