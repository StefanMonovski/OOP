using _02.DummyTests;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        [TestFixture]
        class DummyTests
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(100, 100);
            Dummy deadDummy = new Dummy(0, 100);

            [Test]
            public void AliveDummyLosesHealthAfterAttack()
            {
                axe.Attack(dummy);
                Assert.That(dummy.Health, Is.EqualTo(90), "Dummy health does not change after attack");
            }

            [Test]
            public void DeadDummyThrowsExceptionAfterAttack()
            {
                Assert.Throws<InvalidOperationException>(() => axe.Attack(deadDummy), "Dead dummy does not throw exception after attack");
            }

            [Test]
            public void DeadDummyGivesXP()
            {
                int xp = deadDummy.GiveExperience();
                Assert.That(xp, Is.EqualTo(100), "Dead dummy does not give experience");
            }

            [Test]
            public void AliveDummyThrowsExceptionGivesXP()
            {
                Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Dummy does not throw exception does not give experience");
            }
        }
    }
}
