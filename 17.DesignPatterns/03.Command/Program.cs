using System;

namespace _03.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            ModifyPrice modifyPrice = new ModifyPrice();
            Product product = new Product("Smartphone", 750);
            Execute(modifyPrice, new ProductCommand(product, PriceCommand.Increase, 100));
            Execute(modifyPrice, new ProductCommand(product, PriceCommand.Increase, 50));
            Execute(modifyPrice, new ProductCommand(product, PriceCommand.Decrease, 100));
            Console.WriteLine(product);
        }

        private static void Execute(ModifyPrice modifyPrice, ICommand command)
        {
            modifyPrice.SetCommand(command);
            modifyPrice.Invoke();
        }
    }
}
