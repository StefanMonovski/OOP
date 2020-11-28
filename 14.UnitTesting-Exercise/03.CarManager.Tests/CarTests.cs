using _03.CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        Car defaultCar = new Car("mk", "md", 1.0, 1.0);

        [Test]
        public void MakeGetterReturnsExpectedValue()
        {
            Assert.That(defaultCar.Make, Is.EqualTo("mk"), "Make getter does not return expected value");
        }
        
        [Test]
        public void MakeSetterThrowsExceptionIfValueIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "md", 1.0, 1.0), "Make setter does not throw exception if value is null or empty");
        }

        [Test]
        public void ModelGetterReturnsExpectedValue()
        {
            Assert.That(defaultCar.Model, Is.EqualTo("mk"), "Model getter does not return expected value");
        }

        [Test]
        public void ModelSetterThrowsExceptionIfValueIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Car("mk", null, 1.0, 1.0), "Model setter does not throw exception if value is null or empty");
        }

        [Test]
        public void FuelConsumptionGetterReturnsExpectedValue()
        {
            Assert.That(defaultCar.FuelConsumption, Is.EqualTo(1.0), "Fuel consumption getter does not return expected value");
        }

        [Test]
        public void FuelConsumptionSetterThrowsExceptionIfValueIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new Car("mk", "md", 0, 1.0), "Fuel consumption setter does not throw exception if value is zero or negative");
        }

        [Test]
        public void FuelCapacityGetterReturnsExpectedValue()
        {
            Assert.That(defaultCar.FuelCapacity, Is.EqualTo(1.0), "Fuel capacity getter does not return expected value");
        }

        [Test]
        public void FuelCapacitySetterThrowsExceptionIfValueIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new Car("mk", "md", 1.0, 0), "Fuel capacity setter does not throw exception if value is zero or negative");
        }

        [Test]
        public void FuelAmountGetterReturnsExpectedValue()
        {
            Assert.That(defaultCar.FuelAmount, Is.EqualTo(0), "Fuel amount getter does not return expected value");
        }

        [Test]
        public void RefuelMethodIncreasesFuelAmount()
        {
            defaultCar.Refuel(1.0);
            Assert.That(defaultCar.FuelAmount, Is.EqualTo(1.0), "Refuel method does not increase fuel amount");
        }

        [Test]
        public void RefuelMethodThrowsExceptionIfValueIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => defaultCar.Refuel(0), "Refuel method does not throw exception if value is zero or negative");
        }

        [Test]
        public void DriveMethodDecreasesFuelAmount()
        {
            defaultCar.Refuel(100.0);
            defaultCar.Drive(100.0);
            Assert.That(defaultCar.FuelAmount, Is.EqualTo(0), "Drive method does not decrease fuel amount");
        }

        [Test]
        public void DriveMethodThrowsExceptionIfValueIsMoreThanFuelAmount()
        {
            Assert.Throws<InvalidOperationException>(() => defaultCar.Drive(100.0), "Drive method does not throw exception if value is more than fuel amount");
        }
    }
}