using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int numberHeroes = int.Parse(Console.ReadLine());
            while (heroes.Count != numberHeroes)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                if (type == "Druid")
                {
                    heroes.Add(new Druid(name));
                }
                else if (type == "Paladin")
                {
                    heroes.Add(new Paladin(name));
                }
                else if (type == "Rogue")
                {
                    heroes.Add(new Rogue(name));
                }
                else if (type == "Warrior")
                {
                    heroes.Add(new Warrior(name));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int raidPower = 0;
            foreach (var item in heroes)
            {
                raidPower += item.Power;
                Console.WriteLine(item.CastAbility());
            }
            if (raidPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
