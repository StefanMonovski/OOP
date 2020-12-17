using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace BankSafe
{
    public class BankVault
    {
        private readonly Dictionary<string, Item> vaultCells;

        public BankVault()
        {
            vaultCells = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
        }

        public IReadOnlyDictionary<string, Item> VaultCells => vaultCells.ToImmutableDictionary();

        public string AddItem(string cell, Item item)
        {
            if (!vaultCells.ContainsKey(cell))
            {
                throw new ArgumentException("Cell doesn't exists!");
            }

            if (vaultCells[cell] != null)
            {
                throw new ArgumentException("Cell is already taken!");
            }

            bool cellExists = vaultCells.Values.Any(x => x?.ItemId == item.ItemId);

            if (cellExists)
            {
                throw new InvalidOperationException("Item is already in cell!");
            }

            vaultCells[cell] = item;

            return $"Item:{item.ItemId} saved successfully!";
        }

        public string RemoveItem(string cell, Item item)
        {
            if (!vaultCells.ContainsKey(cell))
            {
                throw new ArgumentException("Cell doesn't exists!");
            }

            if (vaultCells[cell] != item)
            {
                throw new ArgumentException($"Item in that cell doesn't exists!");
            }

            vaultCells[cell] = null;

            return $"Remove item:{item.ItemId} successfully!";
        }
    }
}