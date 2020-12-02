using _02.FakeAxeAndDummy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.FakeAxeAndDummy
{
    public class Axe : IWeapon
    {
        public Axe(int attack, int durability)
        {
            AttackPoints = attack;
            DurabilityPoints = durability;
        }

        public int AttackPoints { get; set; }
        public int DurabilityPoints { get; set; }

        public void Attack(ITarget target)
        {
            if (DurabilityPoints <= 0)
            {
                throw new InvalidOperationException("Axe is broken.");
            }
            target.TakeAttack(AttackPoints);
            DurabilityPoints -= 1;
        }
    }
}
