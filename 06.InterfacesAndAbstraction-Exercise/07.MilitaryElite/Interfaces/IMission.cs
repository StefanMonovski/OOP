using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    interface IMission
    {
        string CodeName { get; set; }
        string State { get; set; }

        void CompleteMission();
    }
}
