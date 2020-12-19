﻿using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int weight = 5;

        public HealthPotion()
            : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.EnsureAlive();
            base.AffectCharacter(character);
            character.Health += 20;
            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
