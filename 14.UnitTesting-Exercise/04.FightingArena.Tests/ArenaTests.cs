using _04.FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        Arena defaultArena = new Arena();
        Warrior defaultWarrior = new Warrior("name", 100, 100);

        [Test]
        public void EnrollMethodEnrollsWarriorToArena()
        {
            defaultArena.Enroll(defaultWarrior);
            Assert.That(defaultArena.Count, Is.EqualTo(1), "Enroll method does not enroll warrior to arena");
        }

        [Test]
        public void EnrollMethodThrowsExceptionIfEnrolledWarriorExists()
        {
            Assert.Throws<InvalidOperationException>(() => defaultArena.Enroll(defaultWarrior), "Enroll method does not throw exception if enrolled warrior exists");
        }

        [Test]
        public void FightMethodInitiatesFightBetweenWarriors()
        {
            Warrior attacker = new Warrior("attacker", 50, 100);
            Warrior opponent = new Warrior("opponent", 50, 100);
            defaultArena.Enroll(attacker);
            defaultArena.Enroll(opponent);
            defaultArena.Fight("attacker", "opponent");
            Assert.That(attacker.HP, Is.EqualTo(50), "Fight method does not initiate fight between warriors");
            Assert.That(opponent.HP, Is.EqualTo(50), "Fight method does not initiate fight between warriors");
        }

        [Test]
        public void FightMethodThrowsExceptionIfWarriorDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => defaultArena.Fight(null, "name"), "Fight method does not throw exception if warrior does not exist");
        }
    }
}
