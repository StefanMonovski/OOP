using _01.Chainblock;
using _01.Chainblock.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        Chainblock chainblock;
        Transaction transaction = new Transaction(0001, TransactionStatus.Successful, "sender", "receiver", 100.00);

        [SetUp]
        public void Setup()
        {
            chainblock = new Chainblock();
        }

        [Test]
        public void AddMethodAddsTransactionToRecord()
        {
            chainblock.Add(transaction);
            Assert.That(chainblock.Count, Is.EqualTo(1), "Add method does not add transaction to record");
        }

        [Test]
        public void AddMethodThrowsExceptionIfAddedTransactionExists()
        {
            chainblock.Add(transaction);
            Assert.Throws<ArgumentException>(() => chainblock.Add(transaction), "Add method does not throw exception if added transaction exists");
        }

        [Test]
        public void ContainsByTransactionMethodReturnsTrueIfTransactionExists()
        {
            chainblock.Add(transaction);
            Assert.True(chainblock.Contains(transaction), "Contains by transaction method does not return true if transaction exists");
        }

        [Test]
        public void ContainsByTransactionMethodReturnsFalseIfTransactionDoesNotExist()
        {
            Assert.False(chainblock.Contains(transaction), "Contains by transaction method does not return false if transaction does not exist");
        }

        [Test]
        public void ContainsByIdMethodReturnsTrueIfTransactionExists()
        {
            chainblock.Add(transaction);
            Assert.True(chainblock.Contains(transaction), "Contains by id method does not return true if transaction exists");
        }

        [Test]
        public void ContainsByIdMethodReturnsFalseIfTransactionDoesNotExist()
        {
            Assert.False(chainblock.Contains(transaction), "Contains by id method does not return false if transaction does not exist");
        }

        [Test]
        public void CountReturnsTransactionsCount()
        {
            Assert.That(chainblock.Count, Is.EqualTo(0), "Count does not return transactions count");
        }

        [Test]
        public void ChangeTransactionStatusMethodChangesGivenTransactionStatus()
        {
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(transaction.Id, TransactionStatus.Failed);
            TransactionStatus transactionStatus = chainblock.GetById(transaction.Id).Status;            
            Assert.That(transactionStatus, Is.EqualTo(TransactionStatus.Failed), "Change transaction status method dos not change given transaction status");
        }

        [Test]
        public void ChangeTransactionStatusMethodThrowsExceptionIfTransactionDoesNotExist()
        {
            string message = "Change transaction status method does not throw exception if transaction does not exist";
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(transaction.Id, TransactionStatus.Failed), message);
        }
        
        [Test]
        public void RemoveTransactionByIdMethodRemovesTransactionWithGivenId()
        {
            chainblock.Add(transaction);
            chainblock.RemoveTransactionById(transaction.Id);
            Assert.That(chainblock.Count, Is.EqualTo(0), "Remove transaction by id method does not remove transaction with given id");
        }

        [Test]
        public void RemoveTransactionByIdMethodThrowsExceptionIfTransactionDoesNotExist()
        {
            string message = "Remove transaction by id method does not throw exception if transaction does not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(transaction.Id), message);
        }

        [Test]
        public void GetByIdMethodReturnsTransactionWithGivenId()
        {
            chainblock.Add(transaction);
            Assert.That(chainblock.GetById(transaction.Id), Is.EqualTo(transaction), "Get by id method does not return transaction with given id");
        }

        [Test]
        public void GetByIdMethodThrowsExceptionIfTransactionDoesNotExist()
        {
            string message = "Get by id method does not throw exception if transaction does not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(transaction.Id), message);
        }

        [Test]
        public void GetByTransactionStatusMethodReturnsTransactionsWithGivenStatusByDescendingAmount()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Successful, "sender", "receiver", 100.00);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successful, "sender", "receiver", 75.00);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Successful, "sender", "receiver", 125.00);
            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            List<ITransaction> expectedResult = new List<ITransaction>(){ thirdTransaction, firstTransaction, secondTransaction };
            string message = "Get by transaction status method does not return expected result";
            Assert.That(chainblock.GetByTransactionStatus(TransactionStatus.Successful), Is.EqualTo(expectedResult), message);
        }
        
        [Test]
        public void GetByTransactionStatusMethodThrowsExceptionIfTransactionsWithGivenStatusDoNotExist()
        {
            string message = "Get by transaction status method does not throw exception if transactions with given status do not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Successful), message);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusMethodReturnsAllSendersWithGivenTransactionStatusByDescendingAmount()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Successful, "firstSender", "receiver", 100.00);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successful, "secondSender", "receiver", 75.00);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Successful, "secondSender", "receiver", 125.00);
            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            List<string> expectedResult = new List<string>() { "secondSender", "firstSender", "secondSender" };
            string message = "Get all senders with given transaction status method does not return expected result";
            Assert.That(chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successful), Is.EqualTo(expectedResult), message);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusMethodThrowsExceptionIfTransactionsWithGivenStatusDoNotExist()
        {
            string message = "Get all senders with given transaction status method does not throw exception if transactions with given status do not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successful), message);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusMethodReturnsAllReceiversWithGivenTransactionStatusByDescendingAmount()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Successful, "sender", "firstreceiver", 100.00);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successful, "sender", "secondreceiver", 75.00);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Successful, "sender", "secondreceiver", 125.00);
            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            List<string> expectedResult = new List<string>() { "secondreceiver", "firstreceiver", "secondreceiver" };
            string message = "Get all receivers with given transaction status method does not return expected result";
            Assert.That(chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successful), Is.EqualTo(expectedResult), message);
        }
        
        [Test]
        public void GetAllReceiversWithTransactionStatusMethodThrowsExceptionIfTransactionsWithGivenStatusDoNotExist()
        {
            string message = "Get all receivers with given transaction status method does not throw exception if transactions with given status do not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successful), message);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdMethodReturnsAllTransactionsByAmountDescendingThenById()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Successful, "sender", "receiver", 125.00);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successful, "sender", "receiver", 75.00);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Successful, "sender", "receiver", 125.00);
            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            List<ITransaction> expectedResult = new List<ITransaction>() { firstTransaction, thirdTransaction, secondTransaction };
            string message = "Get all ordered by amount descending then by id method does not return expected result";
            Assert.That(chainblock.GetAllOrderedByAmountDescendingThenById(), Is.EqualTo(expectedResult), message);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdMethodThrowsExceptionIfTransactionsDoNotExist()
        {
            string message = "Get all ordered by amount descending then by id method does not throw exception if transactions do not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllOrderedByAmountDescendingThenById(), message);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodReturnsAllTransactionsByGivenSenderOrderedByAmountDescending()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Successful, "sender", "receiver", 100.00);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successful, "sender", "receiver", 75.00);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Successful, "sender", "receiver", 125.00);
            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            List<ITransaction> expectedResult = new List<ITransaction>() { thirdTransaction, firstTransaction, secondTransaction };
            string message = "Get by sender ordered by amount descending method does not return expected result";
            Assert.That(chainblock.GetBySenderOrderedByAmountDescending("sender"), Is.EqualTo(expectedResult), message);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodThrowsExceptionIfTransactionsDoNotExist()
        {
            string message = "Get by sender ordered by amount descending method does not throw exception if transactions do not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("sender"), message);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdMethodReturnsAllTransactionsByGivenReceiverOrderedByAmountThenById()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Successful, "sender", "receiver", 125.00);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successful, "sender", "receiver", 75.00);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Successful, "sender", "receiver", 125.00);
            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            List<ITransaction> expectedResult = new List<ITransaction>() { secondTransaction, firstTransaction, thirdTransaction };
            string message = "Get by receiver ordered by amount then by id method does not return expected result";
            Assert.That(chainblock.GetByReceiverOrderedByAmountThenById("receiver"), Is.EqualTo(expectedResult), message);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdMethodThrowsExceptionIfTransactionsDoNotExist()
        {
            string message = "Get by receiver ordered by amount then by id method does not throw exception if transactions do not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("receiver"), message);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountMethodReturnsTransactionsWithGivenStatusAndLessOrEqualToMaximumAmount()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Successful, "sender", "receiver", 100.00);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successful, "sender", "receiver", 75.00);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Successful, "sender", "receiver", 125.00);
            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            List<ITransaction> expectedResult = new List<ITransaction>() { firstTransaction, secondTransaction };
            string message = "Get by transaction status and maximum amount method does not return expected result";
            Assert.That(chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successful, 100.00), Is.EqualTo(expectedResult), message);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountMethodThrowsExceptionIfTransactionsDoNotExist()
        {
            string message = "Get by transaction status and maximum amount method does not throw exception if transactions do not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successful, 100.00), message);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingMethodReturnsTransactionsMoreOrEqualToMinimumAmountByAmountDescending()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Successful, "sender", "receiver", 100.00);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successful, "sender", "receiver", 75.00);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Successful, "sender", "receiver", 125.00);
            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            List<ITransaction> expectedResult = new List<ITransaction>() { thirdTransaction, firstTransaction };
            string message = "Get by sender and minimum amount descending method does not return expected result";
            Assert.That(chainblock.GetBySenderAndMinimumAmountDescending("sender", 100.00), Is.EqualTo(expectedResult), message);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingMethodThrowsExceptionIfTransactionsDoNotExist()
        {
            string message = "Get by sender and minimum amount descending method does not throw exception if transactions do not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending("sender", 100.00), message);
        }

        [Test]
        public void GetByReceiverAndAmountRangeMethodReturnsTransactionsByGivenReceiverInAmountRange()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Successful, "sender", "receiver", 100.00);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successful, "sender", "receiver", 75.00);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Successful, "sender", "receiver", 125.00);
            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            List<ITransaction> expectedResult = new List<ITransaction>() { firstTransaction, secondTransaction };
            string message = "Get by receiver and amount range method does not return expected result";
            Assert.That(chainblock.GetByReceiverAndAmountRange("receiver", 75.00, 125.00), Is.EqualTo(expectedResult), message);
        }

        [Test]
        public void GetByReceiverAndAmountRangeMethodThrowsExceptionIfTransactionsDoNotExist()
        {
            string message = "Get by receiver and amount range method does not throw exception if transactions do not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("receiver", 75.00, 125.00), message);
        }

        [Test]
        public void GetAllInAmountRangeMethodReturnsTransactionsInAmountRange()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Successful, "sender", "receiver", 100.00);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successful, "sender", "receiver", 75.00);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Successful, "sender", "receiver", 125.00);
            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            List<ITransaction> expectedResult = new List<ITransaction>() { firstTransaction, secondTransaction, thirdTransaction };
            string message = "Get all in amount range method does not return expected result";
            Assert.That(chainblock.GetAllInAmountRange(75.00, 125.00), Is.EqualTo(expectedResult), message);
        }

        [Test]
        public void GetAllInAmountRangeMethodThrowsExceptionIfTransactionsDoNotExist()
        {
            string message = "Get all in amount range method does not throw exception if transactions do not exist";
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllInAmountRange(75.00, 125.00), message);
        }
    }
}
