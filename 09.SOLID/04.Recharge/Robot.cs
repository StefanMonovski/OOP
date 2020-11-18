using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Recharge
{
    class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity) 
            :base(id)
        {
            this.capacity = capacity;
            currentPower = capacity;
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public override int Work(int hours)
        {
            if (currentPower - hours > 0)
            {
                base.Work(hours);
                currentPower -= hours;
                return hours;
            }
            else
            {
                int finalHours = base.Work(currentPower);
                Recharge();
                return finalHours;
            }
        }

        public void Recharge()
        {
            Console.WriteLine("Recharging...");
            currentPower = capacity;
        }
    }
}
