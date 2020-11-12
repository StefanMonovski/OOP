using System;
using System.Collections.Generic;
using System.Text;
using _08.CollectionHierarchy.Interfaces;

namespace _08.CollectionHierarchy.Collections
{
    class MyList : IUsable, IRemovable, IAddable
    {
        public List<string> Collection { get; set; }
        public int Used { get { return Collection.Count; } set { } }

        public MyList()
        {
            Collection = new List<string>();
        }

        public int Add(string item)
        {
            Collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string firstItem = Collection[0];
            Collection.RemoveAt(0);
            return firstItem;
        }
    }
}
