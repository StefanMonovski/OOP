using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
        private List<Character> characters;
        private List<Item> items;

        public WarController()
        {
            characters = new List<Character>();
            items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            Character character = null;
            switch (characterType)
            {
                case "Warrior": character = new Warrior(name); break;
                case "Priest": character = new Priest(name); break;
                default: throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
            characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = null;
            switch (itemName)
            {
                case "FirePotion": item = new FirePotion(); break;
                case "HealthPotion": item = new HealthPotion(); break;
                default: throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }
            items.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            if (!characters.Exists(x => x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            Item addItem = items[items.Count - 1];
            characters.First(x => x.Name == characterName).Bag.AddItem(addItem);
            items.RemoveAt(items.Count - 1);
            return string.Format(SuccessMessages.PickUpItem, characterName, addItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            if (!characters.Exists(x => x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            characters.First(x => x.Name == characterName).UseItem(characters.First(x => x.Name == characterName).Bag.GetItem(itemName));
            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                string status = "";
                if (item.IsAlive)
                {
                    status = "Alive";
                }
                else if (!item.IsAlive)
                {
                    status = "Dead";
                }
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, item.Name, item.Health, item.BaseHealth, item.Armor, item.BaseArmor, status));
            }
            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            if (!characters.Exists(x => x.Name == attackerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (!characters.Exists(x => x.Name == receiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }
            if (characters.First(x => x.Name == attackerName).GetType().Name != "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
            Warrior attacker = (Warrior)characters.First(x => x.Name == attackerName);
            Character receiver = characters.First(x => x.Name == receiverName);
            attacker.Attack(receiver);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Name, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));
            if (!receiver.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
            }
            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingRecieverName = args[1];
            if (!characters.Exists(x => x.Name == healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (!characters.Exists(x => x.Name == healingRecieverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingRecieverName));
            }
            if (characters.First(x => x.Name == healerName).GetType().Name != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
            Priest healer = (Priest)characters.First(x => x.Name == healerName);
            Character receiver = characters.First(x => x.Name == healingRecieverName);
            healer.Heal(receiver);
            return string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);
        }
    }
}
