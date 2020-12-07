using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Composite
{
    class SimpleGift : GiftBase
    {
        public SimpleGift(string name, int price)
            :base(name, price)
        {
        }

        public override int CalculateGiftPrice()
        {
            Console.WriteLine($"{name} with the price {price}");
            return price;
        }
    }
}
