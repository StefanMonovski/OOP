using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Template
{
    class WholeWheat : BreadBase
    {
        public override void MixIngredients()
        {
            Console.WriteLine($"Mixing ingredients for whole wheat bread.");
        }

        public override void Bake()
        {
            Console.WriteLine($"Baking whole weat bread. (15 minutes)");
        }
    }
}
