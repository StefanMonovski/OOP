using System;
using System.Collections.Generic;
using System.Text;
using _08.CollectionHierarchy.Interfaces;

namespace _08.CollectionHierarchy.Collections
{
    class AddCollection : IAddable
    {
        public List<string> Collection { get; set; }

        public AddCollection()
        {
            Collection = new List<string>();
        }

        public int Add(string item)
        {
            Collection.Add(item);
            return Collection.Count - 1;
        }
    }
}
