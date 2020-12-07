using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Composite
{
    class ComplexGift : GiftBase, IOperation
    {
        private List<GiftBase> gifts;

        public ComplexGift(string name, int price)
            :base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }

        public override int CalculateGiftPrice()
        {
            int giftPrice = 0;
            Console.WriteLine($"{name} contains the following gifts with prices:");
            foreach (GiftBase item in gifts)
            {
                giftPrice += item.CalculateGiftPrice();
            }
            return giftPrice;
        }
    }
}
