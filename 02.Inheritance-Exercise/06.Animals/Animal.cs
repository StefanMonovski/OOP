using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(GetType().Name);
            output.AppendLine($"{Name} {Age} {Gender}");
            output.Append(ProduceSound());
            return output.ToString();
        }
    }
}
