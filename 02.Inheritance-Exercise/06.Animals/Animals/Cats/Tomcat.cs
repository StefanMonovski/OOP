using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Animals.Cats
{
    class Tomcat : Cat
    {
        private const string gender = "Male";

        public Tomcat(string name, int age)
            : base(name, age, null)
        {
            Gender = gender;
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
