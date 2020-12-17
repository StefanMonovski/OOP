using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        protected BakedFood(string name, int portion, decimal price)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.InvalidName);
            }
            if (portion <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPortion);
            }
            if (price <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPrice);
            }
            Name = name;
            Portion = portion;
            Price = price;
        }

        public string Name { get; }
        public int Portion { get; }
        public decimal Price { get; }

        public override string ToString()
        {
            return $"{Name}: {Portion}g - {Price:f2}";
        }
    }
}
