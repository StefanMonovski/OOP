using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, Count - 1);
            string removeString = this[randomIndex];
            RemoveAt(randomIndex);
            return removeString;
        }
    }
}
