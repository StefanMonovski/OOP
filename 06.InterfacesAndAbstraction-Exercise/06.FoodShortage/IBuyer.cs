using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    interface IBuyer
    {
        string Name { get; set; }
        int Food { get; set; }
        void BuyFood();
    }
}
