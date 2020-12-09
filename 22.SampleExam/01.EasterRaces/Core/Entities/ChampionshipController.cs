using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;

        public ChampionshipController()
        {
            cars = new CarRepository();
            drivers = new DriverRepository();
            races = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            if (drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(ExceptionMessages.DriversExists, driverName);
            }
            drivers.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower, 5000, 400, 600);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower, 3000, 250, 450);
            }
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException(ExceptionMessages.CarExists, model);
            }
            cars.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            races.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (drivers.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            races.GetByName(raceName).AddDriver(drivers.GetByName(driverName));
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);            
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (drivers.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (cars.GetByName(carModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            drivers.GetByName(driverName).AddCar(cars.GetByName(carModel));
            return string.Format(OutputMessages.CarAdded, driverName, carModel);            
        }

        public string StartRace(string raceName)
        {
            IRace race = races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }
            StringBuilder sb = new StringBuilder();
            List<IDriver> driversOrdered = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToList();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, driversOrdered[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, driversOrdered[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, driversOrdered[2].Name, raceName));
            races.Remove(race);
            return sb.ToString().Trim();
        }
    }
}
