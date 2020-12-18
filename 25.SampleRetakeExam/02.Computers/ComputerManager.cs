using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers
{
    public class ComputerManager
    {
        private const string CanNotBeNullMessage = "Can not be null!";

        private readonly List<Computer> computers;

        public ComputerManager()
        {
            computers = new List<Computer>();
        }

        public IReadOnlyCollection<Computer> Computers => computers.AsReadOnly();

        public int Count => computers.Count;

        public void AddComputer(Computer computer)
        {
            ValidateNullValue(computer, nameof(computer), CanNotBeNullMessage);

            if (computers.Any(c => c.Manufacturer == computer.Manufacturer && c.Model == computer.Model))
            {
                throw new ArgumentException("This computer already exists.");
            }

            computers.Add(computer);
        }

        public Computer RemoveComputer(string manufacturer, string model)
        {
            Computer computer = GetComputer(manufacturer, model);

            computers.Remove(computer);
            return computer;
        }

        public Computer GetComputer(string manufacturer, string model)
        {
            ValidateNullValue(manufacturer, nameof(manufacturer), CanNotBeNullMessage);
            ValidateNullValue(model, nameof(model), CanNotBeNullMessage);

            Computer computer = computers.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (computer == null)
            {
                throw new ArgumentException("There is no computer with this manufacturer and model.");
            }

            return computer;
        }

        public ICollection<Computer> GetComputersByManufacturer(string manufacturer)
        {
            ValidateNullValue(manufacturer, nameof(manufacturer), CanNotBeNullMessage);

            ICollection<Computer> computers = this.computers.Where(c => c.Manufacturer == manufacturer).ToList();

            return computers;
        }

        private void ValidateNullValue(object variable, string variableName, string exceptionMessage)
        {
            if (variable == null)
            {
                throw new ArgumentNullException(variableName, exceptionMessage);
            }
        }
    }
}