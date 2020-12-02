using _02.FakeAxeAndDummy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.FakeAxeAndDummy
{
    public class Hero
    {
        public Hero(string name, IWeapon weapon)
        {
            Name = name;
            Experience = 0;
            Weapon = weapon;
        }

        public string Name { get; set; }
        public int Experience { get; set; }
        public IWeapon Weapon { get; set; }

        public void Attack(ITarget target)
        {
            Weapon.Attack(target);

            if (target.IsDead())
            {
                Experience += target.GiveExperience();
            }
        }
    }
}
