using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    class Controller : IController
    {
        private List<IComputer> computers;
        private List<IPeripheral> peripherals;
        private List<IComponent> components;

        public Controller()
        {
            computers = new List<IComputer>();
            peripherals = new List<IPeripheral>();
            components = new List<IComponent>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Exists(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            IComputer computer = null;
            switch (computerType)
            {
                case "DesktopComputer": computer = new DesktopComputer(id, manufacturer, model, price); break;
                case "Laptop": computer = new Laptop(id, manufacturer, model, price); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfComputerExists(computerId);
            if (peripherals.Exists(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            IPeripheral peripheral = null;
            switch (peripheralType)
            {
                case "Headset": peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Keyboard": peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Monitor": peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Mouse": peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            computers.First(x => x.Id == computerId).AddPeripheral(peripheral);
            peripherals.Add(peripheral);
            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerExists(computerId);
            IPeripheral removePeripheral = computers.First(x => x.Id == computerId).RemovePeripheral(peripheralType);
            peripherals.Remove(removePeripheral);
            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, removePeripheral.Id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfComputerExists(computerId);
            if (components.Exists(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            IComponent component = null;
            switch (componentType)
            {
                case "CentralProcessingUnit": component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation); break;
                case "Motherboard": component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation); break;
                case "PowerSupply": component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation); break;
                case "RandomAccessMemory": component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation); break;
                case "SolidStateDrive": component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation); break;
                case "VideoCard": component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            computers.First(x => x.Id == computerId).AddComponent(component);
            components.Add(component);
            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfComputerExists(computerId);
            IComponent removeComponent = computers.First(x => x.Id == computerId).RemoveComponent(componentType);
            components.Remove(removeComponent);
            return string.Format(SuccessMessages.RemovedComponent, componentType, removeComponent.Id);
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerExists(id);
            IComputer removeComputer = computers.First(x => x.Id == id);
            computers.Remove(removeComputer);
            return removeComputer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            IComputer bestComputer = null;
            foreach (var item in computers.OrderByDescending(x => x.OverallPerformance))
            {
                if (item.Price <= budget)
                {
                    bestComputer = item;
                    break;
                }
            }
            if (bestComputer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            computers.Remove(bestComputer);
            return bestComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckIfComputerExists(id);
            return computers.First(x => x.Id == id).ToString();
        }

        private void CheckIfComputerExists(int id)
        {
            if (!computers.Exists(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
