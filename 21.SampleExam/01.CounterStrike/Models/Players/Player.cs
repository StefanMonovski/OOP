using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        public string Username { get; private set; }
        public int Health { get; private set; }
        public int Armor { get; private set; }
        public IGun Gun { get; private set; }
        public bool IsAlive { get; private set; }

        protected Player(string username, int health, int armor, IGun gun)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
            }
            if (health < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
            }
            if (armor < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
            }
            if (gun is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunName);
            }
            if (health > 0)
            {
                IsAlive = true;
            }
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }

        public virtual void TakeDamage(int points)
        {
            if (Armor > 0)
            {
                Armor -= points;
                if (Armor <= 0)
                {
                    points = Math.Abs(Armor);
                    Armor = 0;
                }
            }
            if (Armor <= 0)
            {
                Health -= points;
                if (Health <= 0)
                {
                    Health = 0;
                    IsAlive = false;
                }
            }
        }
    }
}
