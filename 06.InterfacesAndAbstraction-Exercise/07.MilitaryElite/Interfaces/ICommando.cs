using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    interface ICommando : ISpecialisedSoldier
    {
        List<IMission> Missions { get; set; }
    }
}
