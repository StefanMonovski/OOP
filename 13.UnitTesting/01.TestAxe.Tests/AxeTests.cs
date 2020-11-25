using _01.TestAxe;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        Dummy dummy = new Dummy(100, 100);
        Axe axe = new Axe(10, 10);
        Axe brokenAxe = new Axe(10, 0);

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability does not change after attack");
        }

        [Test]
        public void BrokenAxeThrowsExceptionAfterAttack()
        {
            Assert.Throws<InvalidOperationException>(() => brokenAxe.Attack(dummy), "Broken axe does not throw exception after attack");
        }
    }
}
