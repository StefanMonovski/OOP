using Computers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class ComputerManagerTests
    {
        Computer computer = new Computer("manufacturer", "model", 100.0m);
        ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
        }

        [Test]
        public void ComputersGetterReturnsComputersAsReadOnlyCollection()
        {
            computerManager.AddComputer(computer);
            IReadOnlyCollection<Computer> expectedResult = new List<Computer>() { computer }.AsReadOnly();
            Assert.That(computerManager.Computers, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CountGetterReturnsComputersCount()
        {
            computerManager.AddComputer(computer);
            Assert.That(computerManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddComputerMethodThrowsExceptionIfValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
        }

        [Test]
        public void AddComputerMethodThrowsExceptionIfComputerExists()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }

        [Test]
        public void AddComputerMethodAddsComputer()
        {
            computerManager.AddComputer(computer);
            Assert.That(computerManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveComputerMethodThrowsExceptionIfManufacturerIsNull()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, "model"));
        }

        [Test]
        public void RemoveComputerMethodThrowsExceptionIfModelIsNull()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("manufacturer", null));
        }

        [Test]
        public void RemoveComputerMethodThrowsExceptionIfComputerDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => computerManager.RemoveComputer("manufacturer", "model"));
        }

        [Test]
        public void RemoveComputerMethodReturnsComputer()
        {
            computerManager.AddComputer(computer);
            Assert.That(computerManager.RemoveComputer("manufacturer", "model"), Is.EqualTo(computer));
        }

        [Test]
        public void GetComputerMethodThrowsExceptionIfManufacturerIsNull()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "model"));
        }

        [Test]
        public void GetComputerMethodThrowsExceptionIfModelIsNull()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("manufacturer", null));
        }

        [Test]
        public void GetComputerMethodThrowsExceptionIfComputerDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("manufacturer", "model"));
        }

        [Test]
        public void GetComputerReturnsComputer()
        {
            computerManager.AddComputer(computer);
            Assert.That(computerManager.GetComputer("manufacturer", "model"), Is.EqualTo(computer));
        }

        [Test]
        public void GetComputersByManufacturerThrowsExceptionIfValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturerReturnsComputersCollection()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("ignore", "ignore", 100.0m));
            Assert.That(computerManager.GetComputersByManufacturer("manufacturer").Count, Is.EqualTo(1));
        }
    }
}