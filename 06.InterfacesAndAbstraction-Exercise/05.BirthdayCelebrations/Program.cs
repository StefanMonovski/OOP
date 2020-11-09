using System;
using System.Collections.Generic;

namespace _05.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> namables = new List<IBirthable>();
            List<IIdentifiable> identifiables = new List<IIdentifiable>();
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputData = input.Split();
                if (inputData[0] == "Citizen")
                {
                    namables.Add(new Citizen(inputData[1], int.Parse(inputData[2]), inputData[3], inputData[4]));
                    identifiables.Add(new Citizen(inputData[1], int.Parse(inputData[2]), inputData[3], inputData[4]));
                }
                else if (inputData[0] == "Robot")
                {
                    identifiables.Add(new Robot(inputData[1], inputData[2]));
                }
                else if (inputData[0] == "Pet")
                {
                    namables.Add(new Pet(inputData[1], inputData[2]));
                }
            }
            string year = Console.ReadLine();
            foreach (IBirthable item in namables)
            {
                if (item.Birthday.EndsWith(year))
                {
                    Console.WriteLine(item.Birthday);
                }
            }
        }
    }
}
