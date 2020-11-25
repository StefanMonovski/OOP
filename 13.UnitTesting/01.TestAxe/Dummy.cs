using System;
using System.Collections.Generic;
using System.Text;

namespace _01.TestAxe
{
    public class Dummy
    {
        private int experience;

        public Dummy(int health, int experience)
        {
            Health = health;
            this.experience = experience;
        }

        public int Health { get; private set; }

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
