using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Military
{
    class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<IRepair> Repairs { get; set; }

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, List<IRepair> repairs)
            :base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendLine("Repairs:");
            foreach (IRepair item in Repairs)
            {
                output.AppendLine($"  {item.ToString()}");
            }
            return output.ToString().Trim();
        }
    }
}
