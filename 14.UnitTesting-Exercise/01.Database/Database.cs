using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Database
{
    public class Database
    {
        private int[] data;

        public Database(params int[] data)
        {
            this.data = new int[16];

            for (int i = 0; i < data.Length; i++)
            {
                Add(data[i]);
            }

            Count = data.Length;
        }

        public int Count { get; private set; }

        public void Add(int element)
        {
            if (Count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            data[Count] = element;
            Count++;
        }

        public void Remove()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            Count--;
            data[Count] = 0;
        }

        public int[] Fetch()
        {
            int[] copyArray = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                copyArray[i] = data[i];
            }
            return copyArray;
        }
    }
}
