using BankSafe;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        Item item = new Item("owner", "itemId");
        BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        public void BankVaultConstructorCreatesBankVault()
        {
            Assert.That(bankVault.VaultCells.Count, Is.EqualTo(12));
        }

        [Test]
        public void AddMethodThrowsExceptionIfCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A0", item));
        }

        [Test]
        public void AddMethodThrowsExceptionIfCellIsTaken()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", new Item("invalid", "invalid")));
        }

        [Test]
        public void AddMethodThrowsExceptionIfItemExists()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));
        }

        [Test]
        public void AddMehtodReturnsExpectedResult()
        {
            string result = "Item:itemId saved successfully!";
            Assert.That(bankVault.AddItem("A1", item), Is.EqualTo(result));
        }
        
        [Test]
        public void RemoveMethodThrowsExceptionIfCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A0", item));
        }

        [Test]
        public void RemoveMethodThrowsExceptionIfItemDoesNotExistInCell()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", item));
        }
        
        [Test]
        public void RemoveMethodReturnsExpectedResult()
        {
            string result = "Remove item:itemId successfully!";
            bankVault.AddItem("A1", item);
            Assert.That(bankVault.RemoveItem("A1", item), Is.EqualTo(result));
        }
    }
}
