using NUnit.Framework;
using Robots;
using System;

namespace Tests
{
    [TestFixture]
    public class RobotsTests
    {
        Robot defaultRobot = new Robot("name", 100);
        RobotManager robotManager;

        [SetUp]
        public void Setup()
        {
            robotManager = new RobotManager(10);
        }

        [Test]
        public void RobotManagerCapacityGetterReturnsRobotsCapacity()
        {
            Assert.That(robotManager.Capacity, Is.EqualTo(10));
        }

        [Test]
        public void RobotManagerCapacitySetterThrowsExceptionIfRobotCapacityIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }

        [Test]
        public void RobotManagerCountGetterReturnsRobotsCount()
        {
            robotManager.Add(defaultRobot);
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void RobotManagerAddMethodAddsGivenRobot()
        {
            robotManager.Add(defaultRobot);
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void RobotManagerAddMethodThrowsExceptionIfRobotExists()
        {
            robotManager.Add(defaultRobot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("name", 50)));
        }
    
        [Test]
        public void RobotManagerAddMethodThrowsExceptionIfRobotCountIsEqualToCapacity()
        {
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(defaultRobot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("invalid", 100)));
        }

        [Test]
        public void RobotManagerRemoveMethodRemovesGivenRobot()
        {
            robotManager.Add(defaultRobot);
            robotManager.Remove("name");
            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void RobotManagerRemoveMethodThrowsExceptionIfGivenRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("name"));
        }

        [Test]
        public void WorkMethodDecreasesGivenRobotBattery()
        {
            robotManager.Add(defaultRobot);
            robotManager.Work("name", "job", 50);
            Assert.That(defaultRobot.Battery, Is.EqualTo(50));
        }

        [Test]
        public void WorkMethodThrowsExceptionIfGivenRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("name", "job", 50));
        }

        [Test]
        public void WorkMethodThrowsExceptionIfGivenRobotDoesNotHaveEnoughBattery()
        {
            robotManager.Add(defaultRobot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("name", "job", 150));
        }

        [Test]
        public void ChargeMethodIncreasesGivenRobotBattery()
        {
            robotManager.Add(defaultRobot);
            robotManager.Work("name", "job", 50);
            robotManager.Charge("name");
            Assert.That(defaultRobot.Battery, Is.EqualTo(100));
        }

        [Test]
        public void ChargeMethodThrowsExceptionIfGivenRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("name"));
        }
    }
}