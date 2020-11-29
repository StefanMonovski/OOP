using _04.FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        Warrior defaultWarrior = new Warrior("name", 100, 100);

        [Test]
        public void NameGetterReturnsExpectedValue()
        {
            Assert.That(defaultWarrior.Name, Is.EqualTo("name"), "Name getter does not return expected value");
        }

        [Test]
        public void NameSetterThrowsExceptionIfValueIsNullEmptyOrWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 100, 100), "Name setter does not throw exception if value is null or white space");
        }

        [Test]
        public void DamageGetterReturnsExpectedValue()
        {
            Assert.That(defaultWarrior.Damage, Is.EqualTo(100), "Damage getter does not return expected value");
        }

        [Test]
        public void DamageSetterThrowsExceptionIfValueIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("name", 0, 100), "Damage setter does not throw exception if value is zero or negative");
        }

        [Test]
        public void HpGetterReturnsExpectedValue()
        {
            Assert.That(defaultWarrior.HP, Is.EqualTo(100), "Hp getter does not return expected value");
        }

        [Test]
        public void HpSetterThrowsExceptionIfValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("name", 100, -1), "Hp setter does not throw exception if value is negative");
        }

        [Test]
        public void AttackMethodDealsDamageToBothWarriors()
        {
            Warrior attacker = new Warrior("attacker", 50, 100);
            Warrior opponent = new Warrior("opponent", 50, 100);
            attacker.Attack(opponent);
            Assert.That(attacker.HP, Is.EqualTo(50), "Attack method does not deal damage to attacker");
            Assert.That(opponent.HP, Is.EqualTo(50), "Attack method does not deal damage to opponent");
        }

        [Test]
        public void AttackMethodSetsOpponentHpToZeroIfAfterAttackIsNegative()
        {
            Warrior attacker = new Warrior("attacker", 150, 100);
            Warrior opponent = new Warrior("opponent", 50, 100);
            attacker.Attack(opponent);
            Assert.That(opponent.HP, Is.EqualTo(0), "Attack method does not set opponent hp to zero if after attack is negative");
        }

        [Test]
        public void AttackMethodThrowsExceptionIfAttackerHpIsLessOrEqualToMin()
        {
            Warrior attacker = new Warrior("attacker", 10, 20);
            Warrior opponent = new Warrior("opponent", 10, 40);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(opponent), "Attack method does not throw exception if attacker hp is less or equal to min");
        }

        [Test]
        public void AttackMethodThrowsExceptionIfOpponentHpIsLessOrEqualToMin()
        {
            Warrior attacker = new Warrior("attacker", 10, 40);
            Warrior opponent = new Warrior("opponent", 10, 20);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(opponent), "Attack method does not throw exception if opponent hp is less or equal to min");
        }

        [Test]
        public void AttackMethodThrowsExceptionIfOpponentIsTooStrongForAttacker()
        {
            Warrior attacker = new Warrior("attacker", 10, 40);
            Warrior opponent = new Warrior("opponent", 50, 100);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(opponent), "Attack method does not throw exception if opponent is too strong for attacker");
        }
    }
}
