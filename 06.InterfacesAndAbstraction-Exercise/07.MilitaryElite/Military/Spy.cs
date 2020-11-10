using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Military
{
    class Spy : Soldier, ISpy
    {
        public int CodeNumber { get; set; }

        public Spy(string id, string firstName, string lastName, int codeNumber)
            :base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendLine($"Code Number: {CodeNumber}");
            return output.ToString().Trim();
        }
    }
}
