using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get; set; } = 100;
        public int Load => GetLoad();
        public IReadOnlyCollection<Item> Items { get { return items.AsReadOnly(); } }

        public void AddItem(Item item)
        {
            if (GetLoad() + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (!items.Exists(x => x.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            Item removeItem = items.First(x => x.GetType().Name == name);
            items.Remove(removeItem);
            return removeItem;
        }

        protected int GetLoad()
        {
            int load = 0;
            foreach (var item in items)
            {
                load += item.Weight;
            }
            return load;
        }
    }
}
