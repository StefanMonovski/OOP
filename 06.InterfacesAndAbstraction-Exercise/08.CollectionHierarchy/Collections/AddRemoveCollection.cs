using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _08.CollectionHierarchy.Interfaces;

namespace _08.CollectionHierarchy.Collections
{
    class AddRemoveCollection : IRemovable, IAddable
    {
        public List<string> Collection { get; set; }

        public AddRemoveCollection()
        {
            Collection = new List<string>();
        }

        public int Add(string item)
        {
            Collection.Insert(0, item);
            return Collection.IndexOf(item);
        }

        public string Remove()
        {
            string lastItem = Collection[Collection.Count - 1];
            Collection.RemoveAt(Collection.Count - 1);
            return lastItem;
        }
    }
}
