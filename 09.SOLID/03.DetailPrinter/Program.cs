using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.DetailPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputData = input.Split();
                string name = inputData[1];
                if (inputData[0] == "Employee")
                {
                    employees.Add(new Employee(name));
                }
                else if (inputData[0] == "Manager")
                {
                    List<string> documents = inputData.Skip(2).ToList();
                    employees.Add(new Manager(name, documents));
                }
            }
            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}
