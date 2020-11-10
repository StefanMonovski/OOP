using System;
using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Military
{
    class Mission : IMission
    {
        public string CodeName { get; set; }
        private string state;
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new Exception("Invalid!");
                }
                state = value;
            }
        }

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
