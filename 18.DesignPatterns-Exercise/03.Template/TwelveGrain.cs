using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Template
{
    class TwelveGrain : BreadBase
    {
        public override void MixIngredients()
        {
            Console.WriteLine($"Mixing ingredients for 12-grain bread.");
        }

        public override void Bake()
        {
            Console.WriteLine($"Baking 12-grain bread. (25 minutes)");
        }
    }
}
