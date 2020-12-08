using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robots
{
    public class RobotManager
    {
        private List<Robot> robots;
        private int capacity;

        public RobotManager(int capacity)
        {
            robots = new List<Robot>();
            Capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid capacity!");
                }
                capacity = value;
            }
        }

        public int Count => robots.Count;

        public void Add(Robot robot)
        {
            if (robots.Any(r => r.Name == robot.Name))
            {
                throw new InvalidOperationException($"There is already a robot with name {robot.Name}!");
            }
            else if (robots.Count == capacity)
            {
                throw new InvalidOperationException("Not enough capacity!");
            }
            robots.Add(robot);
        }

        public void Remove(string name)
        {
            Robot robotToRemove = robots.FirstOrDefault(r => r.Name == name);
            if (robotToRemove == null)
            {
                throw new InvalidOperationException($"Robot with the name {name} doesn't exist!");
            }
            robots.Remove(robotToRemove);
        }

        public void Work(string robotName, string job, int batteryUsage)
        {
            Robot robot = robots.FirstOrDefault(r => r.Name == robotName);
            if (robot == null)
            {
                throw new InvalidOperationException($"Robot with the name {robotName} doesn't exist!");
            }
            else if (robot.Battery < batteryUsage)
            {
                throw new InvalidOperationException($"{robot.Name} doesn't have enough battery!");
            }
            robot.Battery -= batteryUsage;
        }

        public void Charge(string robotName)
        {
            Robot robot = robots.FirstOrDefault(r => r.Name == robotName);
            if (robot == null)
            {
                throw new InvalidOperationException($"Robot with the name {robotName} doesn't exist!");
            }
            robot.Battery = robot.MaximumBattery;
        }
    }
}

