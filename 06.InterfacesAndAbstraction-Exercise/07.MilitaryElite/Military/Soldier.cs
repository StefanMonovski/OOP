using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Military
{
    class Soldier : ISoldier
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}";
        }
    }
}
