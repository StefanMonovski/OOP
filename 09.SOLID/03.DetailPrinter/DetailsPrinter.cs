using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DetailPrinter
{
    class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee item in employees)
            {
                Console.WriteLine(item.GetDetails());
            }
        }
    }
}
