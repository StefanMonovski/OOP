using System;
using System.Collections.Generic;
using System.Text;

namespace _01.TestAxe
{
    public class Axe
    {
        public Axe(int attack, int durability)
        {
            AttackPoints = attack;
            DurabilityPoints = durability;
        }

        public int AttackPoints { get; }
        public int DurabilityPoints { get; set; }

        public void Attack(Dummy target)
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
