using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Chainblock.Interfaces
{
    public interface ITransaction
    {
        int Id { get; set; }

        TransactionStatus Status { get; set; }

        string From { get; set; }

        string To { get; set; }

        double Amount { get; set; }
    }
}
