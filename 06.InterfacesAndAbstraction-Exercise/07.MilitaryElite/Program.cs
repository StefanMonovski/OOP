using System;
using _07.MilitaryElite.Military;
using _07.MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> military = new List<ISoldier>();
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputData = input.Split();
                string id = inputData[1];
                string firstName = inputData[2];
                string lastName = inputData[3];

                if (inputData[0] == "Private")
                {
                    decimal salary = decimal.Parse(inputData[4]);
                    military.Add(new Private(id, firstName, lastName, salary));
                }
                else if (inputData[0] == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputData[4]);
                    string[] privateIds = inputData.Skip(5).ToArray();
                    List<ISoldier> privates = new List<ISoldier>();
                    foreach (string item in privateIds)
                    {
                        if (military.FirstOrDefault(x => x.Id == item) != null)
                        {
                            privates.Add(military.First(x => x.Id == item));
                        }
                    }
                    military.Add(new LieutenantGeneral(id, firstName, lastName, salary, privates));
                }
                else if (inputData[0] == "Engineer")
                {
                    try
                    {
                        decimal salary = decimal.Parse(inputData[4]);
                        string corps = inputData[5];
                        string[] repairsInput = inputData.Skip(6).ToArray();
                        List<IRepair> repairs = new List<IRepair>();
                        for (int i = 0; i < repairsInput.Length; i += 2)
                        {
                            Repair repair = new Repair(repairsInput[i], int.Parse(repairsInput[i + 1]));
                            repairs.Add(repair);
                        }
                        military.Add(new Engineer(id, firstName, lastName, salary, corps, repairs));
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (inputData[0] == "Commando")
                {
                    try
                    {
                        decimal salary = decimal.Parse(inputData[4]);
                        string corps = inputData[5];
                        string[] missionsInput = inputData.Skip(6).ToArray();
                        List<IMission> missions = new List<IMission>();
                        for (int i = 0; i < missionsInput.Length; i += 2)
                        {
                            try
                            {
                                Mission mission = new Mission(missionsInput[i], missionsInput[i + 1]);
                                missions.Add(mission);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        military.Add(new Commando(id, firstName, lastName, salary, corps, missions));
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (inputData[0] == "Spy")
                {
                    int codeNumber = int.Parse(inputData[4]);
                    military.Add(new Spy(id, firstName, lastName, codeNumber));
                }
            }
            foreach (ISoldier item in military)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
