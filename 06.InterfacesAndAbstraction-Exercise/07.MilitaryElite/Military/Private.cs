using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Military
{
    class Private : Soldier, IPrivate
    {
        public decimal Salary { get; set; }

        public Private(string id, string firstName, string lastName, decimal salary)
            :base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() +  $" Salary: {Salary:f2}";
        }
    }
}
