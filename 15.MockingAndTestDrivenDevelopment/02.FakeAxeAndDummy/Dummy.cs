using _02.FakeAxeAndDummy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.FakeAxeAndDummy
{
    public class Dummy : ITarget
    {
        private int experience;

        public Dummy(int health, int experience)
        {
            Health = health;
            this.experience = experience;
        }

        public int Health { get; set; }

        public void TakeAttack(int attackPoints)
        {
            if (IsDead())
            {
                throw new InvalidOperationException("Dummy is dead.");
            }
            Health -= attackPoints;
        }

        public int GiveExperience()
        {
            if (!IsDead())
            {
                throw new InvalidOperationException("Target is not dead.");
            }
            return experience;
        }

        public bool IsDead()
        {
            return Health <= 0;
        }
    }
}
