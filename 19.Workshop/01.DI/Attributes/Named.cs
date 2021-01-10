using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DI.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class Named : Attribute
    {
        public Named(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
