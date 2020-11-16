using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    abstract class Food
    {
        public abstract int Quantity { get; set; }

        protected Food(int quantity)
        {
            Quantity = quantity;
        }
    }
}
