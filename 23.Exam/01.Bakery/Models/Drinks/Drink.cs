using Bakery.Models.Drinks.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        protected Drink(string name, int portion, decimal price, string brand)
        {
            if (string.IsNullOrWhiteSpace(name))
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
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException(ExceptionMessages.InvalidBrand);
            }
            Name = name;
            Portion = portion;
            Price = price;
            Brand = brand;
        }

        public string Name { get; }
        public int Portion { get; }
        public decimal Price { get; }
        public string Brand { get; }

        public override string ToString()
        {
            return $"{Name} {Brand} - {Portion}ml - {Price:f2}lv";
        }
    }
}
