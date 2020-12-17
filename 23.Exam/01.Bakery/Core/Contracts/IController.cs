namespace Bakery.Core.Contracts
{
    public interface IController
    {
         string AddFood(string type, string name, decimal price);

         string AddDrink(string type, string name, int portion, string brand);

         string AddTable(string type, int tableNumber, int capacity);

         string ReserveTable(int numberOfPeople);

         string OrderFood(int tableNumber, string foodName);

         string OrderDrink(int tableNumber, string drinkName, string drinkBrand);

         string LeaveTable(int tableNumber);

         string GetFreeTablesInfo();

         string GetTotalIncome();
    }
}
