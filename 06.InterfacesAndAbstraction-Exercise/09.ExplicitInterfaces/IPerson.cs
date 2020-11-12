using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }

        string GetName();
    }
}
