using _01.InStock;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class StockTests
    {
        Stock defaultStock;
        Product defaultProduct = new Product("product", 10.00m);

        [SetUp]
        public void SetUp()
        {
            defaultStock = new Stock();
        }

        [Test]
        public void AddMethodAddsProductToStock()
        {
            defaultStock.Add(defaultProduct);
            Assert.That(defaultStock.Count, Is.EqualTo(1), "Add method does not add product to stock");
        }

        [Test]
        public void AddMethodThrowsExceptionIfAddedProductExists()
        {
            defaultStock.Add(defaultProduct);
            Assert.Throws<ArgumentException>(() => defaultStock.Add(defaultProduct), "Add method does not throw exception if added product exists");
        }

        [Test]
        public void ContainsMethodReturnsTrueIfProductIsInStock()
        {
            defaultStock.Add(defaultProduct);
            Assert.True(defaultStock.Contains(defaultProduct), "Contains method does not return true if product is in stock");
        }

        [Test]
        public void ContainsMethodReturnsFalseIfProductIsNotInStock()
        {
            Assert.False(defaultStock.Contains(defaultProduct), "Contains method does not return false if product is not in stock");
        }

        [Test]
        public void CountReturnsProductsCount()
        {
            Assert.That(defaultStock.Count, Is.EqualTo(0), "Count does not return products count");
        }

        [Test]
        public void FindMethodReturnsProductInStockAtGivenIndex()
        {
            defaultStock.Add(defaultProduct);
            Assert.That(defaultStock.Find(1), Is.EqualTo(defaultProduct), "Find method does not return product in stock at given index");
        }

        [Test]
        public void FindMethodThrowsExceptionIfIndexIsOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(() => defaultStock.Find(1), "Find method does not throw exception if count is out of range");
        }

        [Test]
        public void FindByLabelMethodReturnsProductInStockWithGivenLabel()
        {
            defaultStock.Add(defaultProduct);
            Assert.That(defaultStock.FindByLabel("product"), Is.EqualTo(defaultProduct), "Find by label method does not return product in stock with given label");
        }

        [Test]
        public void FindByLabelMethodThrowsExceptionIfProductIsNotInStock()
        {
            Assert.Throws<ArgumentException>(() => defaultStock.FindByLabel("product"), "Find by label method does not throw exception if product is not in stock");
        }
        
        [Test]
        public void FindAllInPriceRangeMethodReturnsProductsInGivenPriceRange()
        {
            Product product1 = new Product("product1", 2.50m);
            Product product2 = new Product("product2", 5.00m);
            Product product3 = new Product("product3", 7.50m);
            defaultStock.Add(product1);
            defaultStock.Add(product2);
            defaultStock.Add(product3);
            List<Product> expected = new List<Product>() { product2, product1 };
            Assert.That(defaultStock.FindAllInPriceRange(0.00m, 5.00m), Is.EqualTo(expected), "Find all in price range method does not return expected result");
        }

        [Test]
        public void FindAllInPriceRangeMethodReturnsEmptyCollectionIfProductsDoNotExist()
        {
            Product product1 = new Product("product1", 2.50m);
            Product product2 = new Product("product2", 5.00m);
            Product product3 = new Product("product3", 7.50m);
            defaultStock.Add(product1);
            defaultStock.Add(product2);
            defaultStock.Add(product3);
            List<Product> expected = new List<Product>();
            Assert.That(defaultStock.FindAllInPriceRange(0.00m, 2.00m), Is.EqualTo(expected), "Find all in price range method does not return expected result");
        }

        [Test]
        public void FindAllByPriceMethodReturnsProductsWithGivenPrice()
        {
            Product product1 = new Product("product1", 2.50m);
            Product product2 = new Product("product2", 2.50m);
            Product product3 = new Product("product3", 7.50m);
            defaultStock.Add(product1);
            defaultStock.Add(product2);
            defaultStock.Add(product3);
            List<Product> expected = new List<Product>() { product1, product2 };
            Assert.That(defaultStock.FindAllByPrice(2.50m), Is.EqualTo(expected), "Find all by price method does not return expected result");
        }

        [Test]
        public void FindAllByPriceMethodReturnsEmptyCollectionIfProductsDoNotExist()
        {
            Product product1 = new Product("product1", 2.50m);
            Product product2 = new Product("product2", 2.50m);
            Product product3 = new Product("product3", 7.50m);
            defaultStock.Add(product1);
            defaultStock.Add(product2);
            defaultStock.Add(product3);
            List<Product> expected = new List<Product>();
            Assert.That(defaultStock.FindAllByPrice(5.00m), Is.EqualTo(expected), "Find all by price method does not return expected result");
        }
        
        [Test]
        public void FindMostExpensiveProductsReturnsMostExpensiveProducts()
        {
            Product product1 = new Product("product1", 2.50m);
            Product product2 = new Product("product2", 5.00m);
            Product product3 = new Product("product3", 7.50m);
            defaultStock.Add(product1);
            defaultStock.Add(product2);
            defaultStock.Add(product3);
            List<Product> expected = new List<Product>() { product3, product2 };
            Assert.That(defaultStock.FindMostExpensiveProducts(2), Is.EqualTo(expected), "Find most expensive products method does not return expected result");
        }

        [Test]
        public void FindMostExpensiveProductsReturnsEmptyCollectionIfProductsDoNotExist()
        {
            List<Product> expected = new List<Product>();
            Assert.That(defaultStock.FindMostExpensiveProducts(2), Is.EqualTo(expected), "Find most expensive products method does not return expected result");
        }

        [Test]
        public void FindAllByQuantityMethodReturnsProductsWithGivenQuantity()
        {
            Product product1 = new Product("product1", 2.50m);
            Product product2 = new Product("product2", 5.00m);
            Product product3 = new Product("product3", 7.50m);
            defaultStock.Add(product1);
            defaultStock.Add(product2);
            defaultStock.Add(product3);
            List<Product> expected = new List<Product>() { product1, product2, product3 };
            Assert.That(defaultStock.FindAllByQuantity(0), Is.EqualTo(expected), "Find all by quantity method does not return expected result");
        }

        [Test]
        public void FindAllByQuantityMethodReturnsEmptyCollectionIfProductsDoNotExist()
        {
            Product product1 = new Product("product1", 2.50m);
            Product product2 = new Product("product2", 5.00m);
            Product product3 = new Product("product3", 7.50m);
            defaultStock.Add(product1);
            defaultStock.Add(product2);
            defaultStock.Add(product3);
            List<Product> expected = new List<Product>();
            Assert.That(defaultStock.FindAllByQuantity(1), Is.EqualTo(expected), "Find all by quantity method does not return expected result");
        }
    }
}
