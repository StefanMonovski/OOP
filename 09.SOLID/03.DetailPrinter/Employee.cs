using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DetailPrinter
{
    class Employee : IPrintable
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual string GetDetails()
        {
            return $"{GetType().Name}: {Name}";
        }
    }
}
