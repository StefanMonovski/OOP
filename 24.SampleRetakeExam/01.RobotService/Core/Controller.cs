using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage;
        private Dictionary<string, IProcedure> procedures;

        public Controller()
        {
            garage = new Garage();
            procedures = new Dictionary<string, IProcedure>();
            procedures.Add("Chip", new Chip());
            procedures.Add("Charge", new Charge());
            procedures.Add("Rest", new Rest());
            procedures.Add("Polish", new Polish());
            procedures.Add("Work", new Work());
            procedures.Add("TechCheck", new TechCheck());
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;
            switch (robotType)
            {
                case "HouseholdRobot": robot = new HouseholdRobot(name, energy, happiness, procedureTime); break;
                case "WalkerRobot": robot = new WalkerRobot(name, energy, happiness, procedureTime); break;
                case "PetRobot": robot = new PetRobot(name, energy, happiness, procedureTime); break;
                default: throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }
            garage.Manufacture(robot);
            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            CheckIfGarageContainsRobot(robotName);
            procedures["Chip"].DoService(garage.Robots[robotName], procedureTime);
            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            CheckIfGarageContainsRobot(robotName);
            procedures["TechCheck"].DoService(garage.Robots[robotName], procedureTime);
            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            CheckIfGarageContainsRobot(robotName);
            procedures["Rest"].DoService(garage.Robots[robotName], procedureTime);
            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            CheckIfGarageContainsRobot(robotName);
            procedures["Work"].DoService(garage.Robots[robotName], procedureTime);
            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        public string Charge(string robotName, int procedureTime)
        {
            CheckIfGarageContainsRobot(robotName);
            procedures["Charge"].DoService(garage.Robots[robotName], procedureTime);
            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Polish(string robotName, int procedureTime)
        {
            CheckIfGarageContainsRobot(robotName);
            procedures["Polish"].DoService(garage.Robots[robotName], procedureTime);
            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            CheckIfGarageContainsRobot(robotName);
            IRobot soldRobot = garage.Robots[robotName];
            garage.Sell(robotName, ownerName);
            if (soldRobot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string History(string procedureType)
        {
            return procedures[procedureType].History();
        }

        private void CheckIfGarageContainsRobot(string robotName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }
    }
}
