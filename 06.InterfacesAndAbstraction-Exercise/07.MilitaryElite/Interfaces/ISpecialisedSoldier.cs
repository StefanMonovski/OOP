using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; set; }
    }
}
