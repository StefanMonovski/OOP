using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    class Player
    {
        private string name;
        private int[] stats;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int[] Stats
        {
            get
            {
                return stats;
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] < 0 || value[i] > 100)
                    {
                        string statName = "";
                        switch (i)
                        {
                            case 0: statName = "Endurance"; break;
                            case 1: statName = "Sprint"; break;
                            case 2: statName = "Dribble"; break;
                            case 3: statName = "Passing"; break;
                            case 4: statName = "Shooting"; break;
                        }
                        throw new ArgumentException($"{statName} should be between 0 and 100.");
                    }
                }
                stats = value;
            }
        }

        public Player(string name, int[] stats)
        {
            Name = name;
            Stats = stats;
        }
    }
}
