using Animals.Animals;
using Animals.Animals.Cats;
using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = "";
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] inputData = Console.ReadLine().Split();
                if (int.Parse(inputData[1]) < 0 || inputData.Length != 3)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (input == "Cat")
                {
                    Cat cat = new Cat(inputData[0], int.Parse(inputData[1]), inputData[2]);
                    animals.Add(cat);
                }
                else if (input == "Dog")
                {
                    Dog dog = new Dog(inputData[0], int.Parse(inputData[1]), inputData[2]);
                    animals.Add(dog);
                }
                else if (input == "Frog")
                {
                    Frog frog = new Frog(inputData[0], int.Parse(inputData[1]), inputData[2]);
                    animals.Add(frog);
                }
                else if (input == "Kitten")
                {
                    Kitten kitten = new Kitten(inputData[0], int.Parse(inputData[1]));
                    animals.Add(kitten);
                }
                else if (input == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(inputData[0], int.Parse(inputData[1]));
                    animals.Add(tomcat);
                }
            }
            foreach (Animal item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
