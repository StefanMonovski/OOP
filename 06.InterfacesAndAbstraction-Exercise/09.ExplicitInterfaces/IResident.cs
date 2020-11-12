using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    interface IResident
    {
        string Name { get; set; }
        string Country { get; set; }

        string GetName();
    }
}
