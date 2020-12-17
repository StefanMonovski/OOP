using System;
using System.Collections.Generic;
using System.Text;

namespace BankSafe
{
    public class Item
    {
        public Item(string owner, string itemId)
        {
            Owner = owner;
            ItemId = itemId;
        }

        public string Owner { get; private set; }
        public string ItemId { get; private set; }
    }
}