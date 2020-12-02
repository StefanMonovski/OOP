using _02.FakeAxeAndDummy;
using _02.FakeAxeAndDummy.Interfaces;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class HeroTests
    {
        [Test]
        public void HeroGainsXpIfTargetIsDeadFakeTest()
        {
            IWeapon fakeAxe = new FakeAxe();
            ITarget fakeDummy = new FakeDummy();
            Hero hero = new Hero("hero", fakeAxe);
            hero.Attack(fakeDummy);
            Assert.That(hero.Experience, Is.EqualTo(20), "Hero does not gain xp if target is dead");
        }

        [Test]
        public void HeroGainsXpIfTargetIsDeadMockTest()
        {
            Mock<IWeapon> fakeAxe = new Mock<IWeapon>();
            fakeAxe.Setup(x => x.AttackPoints).Returns(10);
            fakeAxe.Setup(x => x.DurabilityPoints).Returns(10);
            Mock<ITarget> fakeDummy = new Mock<ITarget>();
            fakeDummy.Setup(x => x.Health).Returns(0);
            fakeDummy.Setup(x => x.GiveExperience()).Returns(20);
            fakeDummy.Setup(x => x.IsDead()).Returns(true);
            Hero hero = new Hero("hero", fakeAxe.Object);
            hero.Attack(fakeDummy.Object);
            Assert.That(hero.Experience, Is.EqualTo(20), "Hero does not gain xp if target is dead");
        }
    }
}