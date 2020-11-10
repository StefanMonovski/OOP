using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    interface IEngineer : ISpecialisedSoldier
    {
        List<IRepair> Repairs { get; set; }
    }
}
