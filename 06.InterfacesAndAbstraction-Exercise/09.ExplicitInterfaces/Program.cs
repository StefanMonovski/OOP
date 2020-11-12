using System;
using System.Collections.Generic;

namespace _09.ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputData = input.Split();
                Citizen citizen = new Citizen(inputData[0], inputData[1], int.Parse(inputData[2]));
                citizens.Add(citizen);
            }
            foreach (Citizen item in citizens)
            {
                IResident itemAsResident = item as IResident;
                Console.WriteLine(itemAsResident.GetName());
                IPerson itemAsPerson = item as IPerson;
                Console.WriteLine(itemAsPerson.GetName());
            }
        }
    }
}
