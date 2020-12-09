using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers
{
    class Driver : IDriver
    {
        public string Name { get; }
        public ICar Car { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanParticipate { get; private set; }

        public Driver(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 5)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, name, 5));
            }
            Name = name;
            Car = null;
            NumberOfWins = 0;
            CanParticipate = false;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car is null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
            Car = car;
            CanParticipate = true;
        }
    }
}
