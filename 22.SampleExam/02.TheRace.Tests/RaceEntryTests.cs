using NUnit.Framework;
using System;
using TheRace;

namespace Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        UnitCar defaultCar = new UnitCar("model", 100, 100);
        UnitDriver defaultDriver;
        RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            defaultDriver = new UnitDriver("name", defaultCar);
            raceEntry = new RaceEntry();
        }

        [Test]
        public void RaceEntryCounterGetterReturnsDriversCount()
        {
            raceEntry.AddDriver(defaultDriver);
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddMethodReturnsExpectedResult()
        {
            Assert.That(raceEntry.AddDriver(defaultDriver), Is.EqualTo("Driver name added in race."));
        }

        [Test]
        public void AddDriverMethodThrowsExceptionIfDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriverMethodThrowsExceptionIfDriverExists()
        {
            raceEntry.AddDriver(defaultDriver);
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(defaultDriver));
        }

        [Test]
        public void CalculateAverageHorsePowerMethodThrowsExceptionIfCounterIsLessThanMinimum()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerMethodReturnsExpectedResult()
        {
            UnitDriver firstDriver = new UnitDriver("first", new UnitCar("model", 50, 100));
            UnitDriver secondDriver = new UnitDriver("second", new UnitCar("model", 100, 100));
            UnitDriver thirdDriver = new UnitDriver("third", new UnitCar("model", 150, 100));
            raceEntry.AddDriver(firstDriver);
            raceEntry.AddDriver(secondDriver);
            raceEntry.AddDriver(thirdDriver);
            Assert.That(raceEntry.CalculateAverageHorsePower(), Is.EqualTo(100));
        }
    }
}