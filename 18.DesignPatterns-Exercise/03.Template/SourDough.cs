using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Template
{
    class SourDough : BreadBase
    {
        public override void MixIngredients()
        {
            Console.WriteLine($"Mixing ingredients for sour dough bread.");
        }

        public override void Bake()
        {
            Console.WriteLine($"Baking sour dough bread. (20 minutes)");
        }
    }
}
