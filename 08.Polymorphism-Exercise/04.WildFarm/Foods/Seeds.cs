using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Foods
{
    class Seeds : Food
    {
        public override int Quantity { get; set; }

        public Seeds(int quantity)
            : base(quantity)
        {
        }
    }
}
