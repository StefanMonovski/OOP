using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        public string Model { get; }
        public int HorsePower { get; }
        public double CubicCentimeters { get; }

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            if (string.IsNullOrWhiteSpace(model) || model.Length < 4)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, model, 4));
            }
            Model = model;
            if (horsePower < minHorsePower || horsePower > maxHorsePower)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
