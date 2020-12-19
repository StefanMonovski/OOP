﻿using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double health = 100;
        private const double armor = 50;
        private const double abilityPoints = 40;

        public Warrior(string name)
            : base(name, health, armor, abilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            EnsureAlive();
            character.EnsureAlive();
            if (character == this)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }
            character.TakeDamage(AbilityPoints);
        }
    }
}
