using _01.Chainblock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Chainblock
{
    public class Chainblock : IChainblock
    {
        private Dictionary<int, ITransaction> record;

        public Chainblock()
        {
            record = new Dictionary<int, ITransaction>();
        }

        public int Count => record.Count;

        public void Add(ITransaction tx)
        {
            if (Contains(tx))
            {
                throw new ArgumentException("Added transaction exists");
            }
            record.Add(tx.Id, tx);
        }
        
        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!Contains(id))
            {
                throw new ArgumentException("Transaction with given id does not exist");
            }
            record[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return record.ContainsKey(tx.Id);
        }

        public bool Contains(int id)
        {
            return record.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            List<ITransaction> result = new List<ITransaction>();
            foreach (var item in record.Values)
            {
                if (item.Amount >= lo && item.Amount <= hi)
                {
                    result.Add(item);
                }
            }
            if (result.Count == 0)
            {
                throw new InvalidOperationException("Transactions in given range do not exist");
            }
            return result;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            List<ITransaction> result = new List<ITransaction>();
            foreach (var item in record.Values.OrderByDescending(x => x.Amount).ThenBy(x => x.Id))
            {
                result.Add(item);
            }
            if (result.Count == 0)
            {
                throw new InvalidOperationException("Transactions do not exist");
            }
            return result;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = new List<string>();
            foreach (var item in record.Values.OrderByDescending(x => x.Amount))
            {
                if (item.Status == status)
                {
                    result.Add(item.To);
                }
            }
            if (result.Count == 0)
            {
                throw new InvalidOperationException("Transactions with given status do not exist");
            }
            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = new List<string>();
            foreach (var item in record.Values.OrderByDescending(x => x.Amount))
            {
                if (item.Status == status)
                {
                    result.Add(item.From);
                }
            }
            if (result.Count == 0)
            {
                throw new InvalidOperationException("Transactions with given status do not exist");
            }
            return result;
        }

        public ITransaction GetById(int id)
        {
            if (!Contains(id))
            {
                throw new InvalidOperationException("Transaction with given id does not exist");
            }
            return record[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            List<ITransaction> result = new List<ITransaction>();
            foreach (var item in record.Values.OrderByDescending(x => x.Amount).ThenBy(x => x.Id))
            {
                if (item.To == receiver && item.Amount >= lo && item.Amount < hi)
                {
                    result.Add(item);
                }
            }
            if (result.Count == 0)
            {
                throw new InvalidOperationException("Transactions with given receiver and in given range do not exist");
            }
            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            List<ITransaction> result = new List<ITransaction>();
            foreach (var item in record.Values.OrderBy(x => x.Amount).ThenBy(x => x.Id))
            {
                if (item.To == receiver)
                {
                    result.Add(item);
                }
            }
            if (result.Count == 0)
            {
                throw new InvalidOperationException("Transactions by given receiver do not exist");
            }
            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            List<ITransaction> result = new List<ITransaction>();
            foreach (var item in record.Values.OrderByDescending(x => x.Amount))
            {
                if (item.From == sender && item.Amount >= amount)
                {
                    result.Add(item);
                }
            }
            if (result.Count == 0)
            {
                throw new InvalidOperationException("Transactions by given sender and more or equal to given amount do not exist");
            }
            return result;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> result = new List<ITransaction>();
            foreach (var item in record.Values.OrderByDescending(x => x.Amount))
            {
                if (item.From == sender)
                {
                    result.Add(item);
                }
            }
            if (result.Count == 0)
            {
                throw new InvalidOperationException("Transactions by given sender do not exist");
            }
            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> result = new List<ITransaction>();
            foreach (var item in record.Values.OrderByDescending(x => x.Amount))
            {
                if (item.Status == status)
                {
                    result.Add(item);
                }
            }
            if (result.Count == 0)
            {
                throw new InvalidOperationException("Transactions with given status do not exist");
            }
            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            List<ITransaction> result = new List<ITransaction>();
            foreach (var item in record.Values.OrderByDescending(x => x.Amount))
            {
                if (item.Status == status && item.Amount <= amount)
                {
                    result.Add(item);
                }
            }
            if (result.Count == 0)
            {
                throw new InvalidOperationException("Transactions with given status and less or equal then given amount do not exist");
            }
            return result;
        }

        public void RemoveTransactionById(int id)
        {
            if (!Contains(id))
            {
                throw new InvalidOperationException("Transaction with given id does not exist");
            }
            record.Remove(id);
        }
    }
}
