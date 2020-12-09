using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races
{
    class Race : IRace
    {
        public string Name { get; }
        public int Laps { get; }
        public IReadOnlyCollection<IDriver> Drivers { get { return drivers.AsReadOnly(); } }
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 5)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, name, 5));
            }
            Name = name;
            if (laps < 1)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
            }
            Laps = laps;
            drivers = new List<IDriver>();
        }

        public void AddDriver(IDriver driver)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (drivers.Exists(x => x.Name == driver.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, Name));
            }
            drivers.Add(driver);
        }
    }
}
