using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputData = input.Split();
                if (inputData.Length == 3)
                {
                    identifiables.Add(new Citizen(inputData[0], int.Parse(inputData[1]), inputData[2]));
                }
                else if (inputData.Length == 2)
                {
                    identifiables.Add(new Robot(inputData[0], inputData[1]));
                }
            }
            string fakeId = Console.ReadLine();
            foreach (IIdentifiable item in identifiables)
            {
                if (item.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
