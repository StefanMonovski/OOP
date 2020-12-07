using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Template
{
    abstract class BreadBase
    {
        public abstract void MixIngredients();
        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine($"Slicing the {GetType().Name} bread!");
        }

        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }
    }
}
