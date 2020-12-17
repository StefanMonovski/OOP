using Computers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class ComputerTests
    {
        Part firstPart;
        Part secondPart;
        Computer computer;

        [SetUp]
        public void Setup()
        {
            firstPart = new Part("first", 50.0m);
            secondPart = new Part("second", 100.0m);
            computer = new Computer("name");
        }

        [Test]
        public void NameSetterThrowsExceptionIfValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(null));
        }

        [Test]
        public void NameGetterReturnsName()
        {
            Assert.That(computer.Name, Is.EqualTo("name"));
        }

        [Test]
        public void PartsGetterReturnsPartsAsReadOnlyCollection()
        {
            computer.AddPart(firstPart);
            computer.AddPart(secondPart);
            IReadOnlyCollection<Part> expectedResult = new List<Part>() { firstPart, secondPart }.AsReadOnly();
            Assert.That(computer.Parts, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TotalPriceGetterReturnsPartsSum()
        {
            computer.AddPart(firstPart);
            computer.AddPart(secondPart);
            Assert.That(computer.TotalPrice, Is.EqualTo(150.0m));
        }

        [Test]
        public void AddPartMethodThrowsExceptionIfValueIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null));
        }

        [Test]
        public void AddPartMethodAddsPart()
        {
            computer.AddPart(firstPart);
            Assert.That(computer.Parts.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemovePartMethodReturnsTrueIfPartIsRemoved()
        {
            computer.AddPart(firstPart);
            Assert.That(computer.RemovePart(firstPart), Is.EqualTo(true));
        }

        [Test]
        public void RemovePartMethodReturnsFalseIfPartIsNotRemoved()
        {
            Assert.That(computer.RemovePart(firstPart), Is.EqualTo(false));
        }

        [Test]
        public void GetPartMethodReturnsPartIfPartExists()
        {
            computer.AddPart(firstPart);
            Assert.That(computer.GetPart("first"), Is.EqualTo(firstPart));
        }

        [Test]
        public void GetPartMethodReturnsNullIfPartDoesNotExist()
        {
            computer.AddPart(firstPart);
            Assert.That(computer.GetPart("invalid"), Is.EqualTo(null));
        }
    }
}