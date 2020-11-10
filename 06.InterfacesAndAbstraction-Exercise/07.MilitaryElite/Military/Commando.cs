using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Military
{
    class Commando : SpecialisedSoldier, ICommando
    {
        public List<IMission> Missions { get; set; }

        public Commando(string id, string firstName, string lastName, decimal salary, string corps, List<IMission> missions)
            :base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendLine("Missions:");
            foreach (IMission item in Missions)
            {
                output.AppendLine($"  {item.ToString()}");
            }
            return output.ToString().Trim();
        }
    }
}
