﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    class Citizen : IResident, IPerson
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        string IPerson.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }

        string IResident.GetName()
        {
            return Name;
        }
    }
}
