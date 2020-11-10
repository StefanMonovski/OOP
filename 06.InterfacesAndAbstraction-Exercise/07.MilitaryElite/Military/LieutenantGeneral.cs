using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Military
{
    class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<ISoldier> Privates { get; set; }

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, List<ISoldier> privates)
            :base(id, firstName, lastName,salary)
        {
            Privates = privates;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendLine("Privates:");
            foreach (ISoldier item in Privates)
            {
                output.AppendLine($"  {item.ToString()}");
            }
            return output.ToString().Trim();
        }
    }
}
