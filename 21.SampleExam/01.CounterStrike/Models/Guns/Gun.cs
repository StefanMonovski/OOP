using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;  

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        public string Name { get; }
        public int BulletsCount { get { return bulletsCount; } }
        protected int bulletsCount;

        protected Gun(string name, int bulletsCount)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.InvalidGun);
            }
            Name = name;
            if (bulletsCount < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
            }
            this.bulletsCount = bulletsCount;
        }

        public abstract int Fire();
    }
}
