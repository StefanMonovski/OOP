using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double health = 50;
        private const double armor = 25;
        private const double abilityPoints = 40;

        public Priest(string name)
            : base(name, health, armor, abilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            EnsureAlive();
            character.EnsureAlive();
            character.Health += AbilityPoints;
            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
