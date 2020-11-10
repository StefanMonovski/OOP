using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    interface ISpy : ISoldier
    {
        int CodeNumber { get; set; }
    }
}
