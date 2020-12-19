using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
            }
            Name = name;
            if (health < 0)
            {
                health = 0;
            }
            Health = health;
            BaseHealth = health;
            if (armor < 0)
            {
                armor = 0;
            }
            Armor = armor;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name { get; }
        public double BaseHealth { get; }
        public double Health { get; set; }
        public double BaseArmor { get; }
        public double Armor { get; set; }
        public double AbilityPoints { get; }
        public Bag Bag { get; }
        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            if (Armor > 0)
            {
                Armor -= hitPoints;
                if (Armor <= 0)
                {
                    hitPoints = Math.Abs(Armor);
                    Armor = 0;
                }
            }
            if (Armor == 0)
            {
                Health -= hitPoints;
                if (Health <= 0)
                {
                    Health = 0;
                    IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }

        public void EnsureAlive()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}