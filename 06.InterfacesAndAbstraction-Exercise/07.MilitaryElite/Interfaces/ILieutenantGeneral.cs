using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    interface ILieutenantGeneral : IPrivate
    {
        List<ISoldier> Privates { get; set; }
    }
}
