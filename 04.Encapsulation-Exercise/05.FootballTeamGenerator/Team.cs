using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    class Team
    {
        private string name;
        private List<Player> players;

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

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public void AddPlayer(Player player, string teamName)
        {
            DoesTeamExist(teamName);
            players.Add(player);
        }

        public void RemovePlayer(string teamName, string playerName)
        {
            DoesTeamExist(teamName);
            Player player = players.FirstOrDefault(x => x.Name == playerName);
            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
            }
            players.Remove(player);
        }

        public double GetTeamRating(string teamName)
        {
            DoesTeamExist(teamName);
            double teamRating = 0.0;
            double teamTotalStats = 0.0;
            if (players.Count != 0)
            {
                foreach (Player item in players)
                {
                    foreach (int stat in item.Stats)
                    {
                        teamTotalStats += stat;
                    }
                }
                teamRating = teamTotalStats / (players.Count * 5);
            }
            return teamRating;
        }

        private bool DoesTeamExist(string teamName)
        {
            if (name != teamName)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
            return true;
        }
    }
}
