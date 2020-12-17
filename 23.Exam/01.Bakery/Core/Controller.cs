using System;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    class Controller : IController
    {
        private List<IBakedFood> foods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private List<decimal> bills;

        public Controller()
        {
            foods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
            bills = new List<decimal>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }
            foods.Add(food);
            return string.Format(OutputMessages.FoodAdded, name, food.GetType().Name);
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            drinks.Add(drink);
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            tables.Add(table);
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            foreach (ITable item in tables)
            {
                if (item.IsReserved == false && item.Capacity >= numberOfPeople)
                {
                    item.Reserve(numberOfPeople);
                    return string.Format(OutputMessages.TableReserved, item.TableNumber, numberOfPeople);
                }
            }
            return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (!tables.Exists(x => x.TableNumber == tableNumber))
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (!foods.Exists(x => x.Name == foodName))
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }
            tables.First(x => x.TableNumber == tableNumber).OrderFood(foods.First(x => x.Name == foodName));
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (!tables.Exists(x => x.TableNumber == tableNumber))
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (!drinks.Exists(x => x.Name == drinkName && x.Brand == drinkBrand))
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            tables.First(x => x.TableNumber == tableNumber).OrderDrink(drinks.First(x => x.Name == drinkName && x.Brand == drinkBrand));
            return string.Format(OutputMessages.DrinkOrderedSuccesful, tableNumber, drinkName, drinkBrand);
        }

        public string LeaveTable(int tableNumber)
        {
            decimal bill = tables.FirstOrDefault(x => x.TableNumber == tableNumber).GetBill();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");
            tables.FirstOrDefault(x => x.TableNumber == tableNumber).Clear();
            bills.Add(bill);
            return sb.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ITable item in tables)
            {
                if (item.IsReserved == false)
                {
                    sb.AppendLine(item.GetFreeTableInfo());
                }
            }
            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            decimal totalIncome = bills.Sum();
            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }
    }
}
