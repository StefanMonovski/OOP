﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Composite
{
    abstract class GiftBase
    {
        protected string name;
        protected int price;

        public GiftBase(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract int CalculateGiftPrice();
    }
}
