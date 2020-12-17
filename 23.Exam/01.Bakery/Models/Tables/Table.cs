using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> FoodOrders;
        private List<IDrink> DrinkOrders;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
            }
            TableNumber = tableNumber;
            Capacity = capacity;
            NumberOfPeople = 0;
            PricePerPerson = pricePerPerson;
            IsReserved = false;
            Price = 0;
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; }
        public int Capacity { get; }
        public int NumberOfPeople { get; private set; }
        public decimal PricePerPerson { get; }
        public bool IsReserved { get; private set; }
        public decimal Price { get => NumberOfPeople * PricePerPerson; private set { } }

        public void Reserve(int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
            }
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }

        public void OrderFood(IBakedFood food)
        {
            FoodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal bill = 0.0m;
            bill += Price;
            foreach (IBakedFood item in FoodOrders)
            {
                bill += item.Price;
            }
            foreach (IDrink item in DrinkOrders)
            {
                bill += item.Price;
            }
            return bill;
        }

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            IsReserved = false;
            NumberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");
            return sb.ToString().Trim();
        }
    }
}