using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        public string Name { get; set; }
        private int Age;
        public string Id { get; set; }
        public string Birthday { get; set; }
        public int Food { get; set; }

        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
            Food = 0;
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
