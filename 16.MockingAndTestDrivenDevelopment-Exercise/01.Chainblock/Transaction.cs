using _01.Chainblock.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Chainblock
{
    public class Transaction : ITransaction, IEquatable<ITransaction>
    {
        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id { get; set; }
        public TransactionStatus Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Amount { get; set; }

        public bool Equals(ITransaction other)
        {
            if (Id == other.Id)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object other)
        {
            return Equals(other as ITransaction);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
