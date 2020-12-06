using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Command
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceCommand priceCommand;
        private readonly int amount;

        public ProductCommand(Product product, PriceCommand priceCommand, int amount)
        {
            this.product = product;
            this.priceCommand = priceCommand;
            this.amount = amount;
        }

        public void ExecuteCommand()
        {
            if (priceCommand == PriceCommand.Increase)
            {
                product.IncreasePrice(amount);
            }
            else if (priceCommand == PriceCommand.Decrease)
            {
                product.DecreasePrice(amount);
            }
        }
    }
}
