using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            if (energy < 0 || energy > 100)
            {
                throw new ArgumentException(ExceptionMessages.InvalidEnergy);
            }
            Energy = energy;
            if (happiness < 0 || happiness > 100)
            {
                throw new ArgumentException(ExceptionMessages.InvalidHappiness);
            }
            Happiness = happiness;
            ProcedureTime = procedureTime;
            Owner = "Service";
            IsBought = false;
            IsChipped = false;
            IsChecked = false;
        }

        public string Name { get; }
        public int Happiness { get; set; }
        public int Energy { get; set; }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return string.Format(OutputMessages.RobotInfo, GetType().Name, Name, Happiness, Energy);
        }
    }
}
