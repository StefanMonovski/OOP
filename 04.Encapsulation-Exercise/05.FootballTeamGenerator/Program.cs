using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            List<Team> teams = new List<Team>();
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] inputData = input.Split(";");
                    if (inputData[0] == "Team")
                    {
                        teams.Add(new Team(inputData[1]));
                        continue;
                    }

                    Team currentTeam = teams.FirstOrDefault(x => x.Name == inputData[1]);
                    if (currentTeam == null)
                    {
                        throw new ArgumentException($"Team {inputData[1]} does not exist.");
                    }

                    if (inputData[0] == "Add")
                    {
                        string[] inputStatsData = new string[5];
                        Array.Copy(inputData, 3, inputStatsData, 0, 5);
                        Player player = new Player(inputData[2], inputStatsData.Select(int.Parse).ToArray());
                        currentTeam.AddPlayer(player, inputData[1]);
                    }
                    else if (inputData[0] == "Remove")
                    {
                        currentTeam.RemovePlayer(inputData[1], inputData[2]);
                    }
                    else if (inputData[0] == "Rating")
                    {
                        double teamRating = currentTeam.GetTeamRating(inputData[1]);
                        Console.WriteLine($"{inputData[1]} - {Math.Round(teamRating)}");
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
