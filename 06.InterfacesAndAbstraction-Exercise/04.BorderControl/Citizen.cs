using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    class Citizen : IIdentifiable
    {
        private string Name;
        private int Age;
        public string Id { get; set; }

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
    }
}
