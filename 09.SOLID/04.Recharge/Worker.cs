using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Recharge
{
    public abstract class Worker
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public virtual int Work(int hours)
        {
            workingHours += hours;
            Console.WriteLine($"{GetType().Name} worked a total of {workingHours}");
            return hours;
        }
    }
}
