using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Animals.Cats
{
    class Kitten : Cat
    {
        private const string gender = "Female";

        public Kitten(string name, int age)
            : base(name, age, null)
        {
            Gender = gender;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
