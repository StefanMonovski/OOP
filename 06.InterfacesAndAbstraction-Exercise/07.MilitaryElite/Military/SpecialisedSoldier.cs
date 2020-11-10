using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Military
{
    class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public string Corps
        {
            get
            {
                return corps;
            }
            set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new Exception("Invalid!");
                }
                corps = value;
            }
        }

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            :base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendLine($"Corps: {Corps}");
            return output.ToString().Trim();
        }
    }
}
