using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    interface ISoldier
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
