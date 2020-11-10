using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    interface IPrivate : ISoldier
    {
        decimal Salary { get; set; }
    }
}
