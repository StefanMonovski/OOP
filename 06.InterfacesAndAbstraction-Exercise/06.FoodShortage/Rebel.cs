using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    class Rebel : IBuyer
    {
        public string Name { get; set; }
        private int Age;
        private string Group;
        public int Food { get; set; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }


        public void BuyFood()
        {
            Food += 5;
        }
    }
}
