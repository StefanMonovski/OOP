using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Recharge
{
    class Employee : Worker, ISleeper
    {
        private int maximum;
        private int currentEnergy;

        public Employee(string id, int maximum) 
            :base(id)
        {
            this.maximum = maximum;
            currentEnergy = maximum;
        }

        public override int Work(int hours)
        {
            if (currentEnergy - hours > 0)
            {
                base.Work(hours);
                currentEnergy -= hours;
                return hours;
            }
            else
            {
                int finalHours = base.Work(currentEnergy);
                Sleep();
                return finalHours;
            }
        }

        public void Sleep()
        {
            Console.WriteLine("Sleeping...");
            currentEnergy = maximum;
        }
    }
}
