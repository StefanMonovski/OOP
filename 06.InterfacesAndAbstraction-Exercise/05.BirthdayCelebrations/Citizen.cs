using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    class Citizen : IIdentifiable, IBirthable
    {
        private string Name;
        private int Age;
        public string Id { get; set; }
        public string Birthday { get; set; }

        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }
    }
}
