using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Person
{
    class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
            Name = name;
            Age = age;
        }
    }
}
