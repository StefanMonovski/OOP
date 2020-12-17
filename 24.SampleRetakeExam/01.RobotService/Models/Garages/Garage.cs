using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int Capacity = 10;
        private readonly Dictionary<string, IRobot> robots;
        public IReadOnlyDictionary<string, IRobot> Robots { get { return robots; } }

        public Garage()
        {
            robots = new Dictionary<string, IRobot>();
        }

        public void Manufacture(IRobot robot)
        {
            if (robots.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            if (robots.ContainsKey(robot.Name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }
            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            robots.First(x => x.Key == robotName).Value.Owner = ownerName;
            robots.First(x => x.Key == robotName).Value.IsBought = true;
            robots.Remove(robotName);
        }
    }
}
