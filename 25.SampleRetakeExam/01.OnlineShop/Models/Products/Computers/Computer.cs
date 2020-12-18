using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            :base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        
        public IReadOnlyCollection<IComponent> Components { get { return components.AsReadOnly(); } }
        public IReadOnlyCollection<IPeripheral> Peripherals { get { return peripherals.AsReadOnly(); } }

        public void AddComponent(IComponent component)
        {
            if (components.Exists(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, GetType().Name, Id));
            }
            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || !components.Exists(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, GetType().Name, Id));
            }
            IComponent removeComponent = components.First(x => x.GetType().Name == componentType);
            components.Remove(removeComponent);
            return removeComponent;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Exists(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, GetType().Name, Id));
            }
            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || !peripherals.Exists(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, GetType().Name, Id));
            }
            IPeripheral removePeripheral = peripherals.First(x => x.GetType().Name == peripheralType);
            peripherals.Remove(removePeripheral);
            return removePeripheral;
        }

        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + GetAverageOverallPerformanceComponents();
                }
            }
        }

        public override decimal Price
        {
            get
            {
                decimal overallPrice = base.Price;
                foreach (var item in components)
                {
                    overallPrice += item.Price;
                }
                foreach (var item in peripherals)
                {
                    overallPrice += item.Price;
                }
                return overallPrice;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format(SuccessMessages.ComputerComponentsToString, components.Count));
            foreach (var item in components)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            sb.AppendLine(string.Format(SuccessMessages.ComputerPeripheralsToString, peripherals.Count, $"{GetAverageOverallPerformancePeripherals():f2}"));
            foreach (var item in peripherals)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().Trim();
        }

        private double GetAverageOverallPerformanceComponents()
        {
            double averageOverallPerformanceComponents = 0.0;
            if (components.Count == 0)
            {
                return averageOverallPerformanceComponents;
            }
            foreach (var item in components)
            {
                averageOverallPerformanceComponents += item.OverallPerformance;
            }
            averageOverallPerformanceComponents /= components.Count;
            return averageOverallPerformanceComponents;
        }

        private double GetAverageOverallPerformancePeripherals()
        {
            double averageOverallPerformancePeripherals = 0.0;
            if (peripherals.Count == 0)
            {
                return averageOverallPerformancePeripherals;
            }
            foreach (var item in peripherals)
            {
                averageOverallPerformancePeripherals += item.OverallPerformance;
            }
            averageOverallPerformancePeripherals /= peripherals.Count;
            return averageOverallPerformancePeripherals;
        }
    }
}
