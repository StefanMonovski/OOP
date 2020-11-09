using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    class Pet : IBirthable
    {
        private string Name;
        public string Birthday { get; set; }

        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }
    }
}
