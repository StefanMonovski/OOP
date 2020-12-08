using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Maps
{
    class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            ICollection<IPlayer> terrorists = new List<IPlayer>();
            ICollection<IPlayer> counterTerrorists = new List<IPlayer>();

            foreach (IPlayer item in players)
            {
                if (item.GetType().Equals(typeof(Terrorist)))
                {
                    terrorists.Add(item);
                }
                else if (item.GetType().Equals(typeof(CounterTerrorist)))
                {
                    counterTerrorists.Add(item);
                }
            }

            bool teamIsDead = false;
            string winner = "";
            while (!teamIsDead)
            {
                foreach (var terrorist in terrorists)
                {
                    foreach (var counterTerrorist in counterTerrorists)
                    {
                        if (terrorist.IsAlive && counterTerrorist.IsAlive)
                        {
                            counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                        }                       
                    }
                }
                foreach (var item in counterTerrorists)
                {
                    if (item.IsAlive)
                    {
                        teamIsDead = false;
                        break;
                    }
                    teamIsDead = true;
                }
                if (teamIsDead)
                {
                    winner = "Terrorist wins!";
                    break;
                }

                foreach (var counterTerrorist in counterTerrorists)
                {
                    foreach (var terrorist in terrorists)
                    {
                        if (terrorist.IsAlive && counterTerrorist.IsAlive)
                        {
                            terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                        }
                    }
                }
                foreach (var item in terrorists)
                {
                    if (item.IsAlive)
                    {
                        teamIsDead = false;
                        break;
                    }
                    teamIsDead = true;
                }
                if (teamIsDead)
                {
                    winner = "Counter Terrorist wins!";
                    break;
                }
            }
            return winner;
        }
    }
}
