using System;
using System.Collections.Generic;

namespace _04.Recharge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter worker, id and max hours:");
            Worker worker = null;
            string[] inputData = Console.ReadLine().Split();
            string id = inputData[1];
            if (inputData[0] == "Employee")
            {
                worker = new Employee(id, int.Parse(inputData[2]));
            }
            else if (inputData[0] == "Robot")
            {
                worker = new Robot(id, int.Parse(inputData[2]));
            }
            Console.WriteLine($"Enter total hours work needed:");
            int totalHoursWork = int.Parse(Console.ReadLine());
            int hoursWorked = 0;
            int shiftsWorked = 0;
            while (hoursWorked < totalHoursWork)
            {
                Console.WriteLine($"Enter current shift hours work:");
                int hoursWork = int.Parse(Console.ReadLine());
                hoursWorked += worker.Work(hoursWork);
                shiftsWorked++;
            }
            Console.WriteLine($"Job finished in {shiftsWorked} shifts!!!");
        }
    }
}
