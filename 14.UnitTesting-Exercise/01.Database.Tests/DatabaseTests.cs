using _01.Database;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        int[] emptyArray = { };
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        int[] invalidArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

        [Test]
        public void DatabaseThrowsExceptionIfSizeIsOver16Integers()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(invalidArray), "Database does not throw exception if size is over 16 integers");
        }

        [Test]
        public void DatabaseAddAddsInteger()
        {
            Database database = new Database(emptyArray);
            database.Add(1);
            Assert.That(database.Count, Is.EqualTo(1), "Database add method does not add integer");
        }

        [Test]
        public void DatabaseThrowsExceptionIfAdded17thInteger()
        {
            Database database = new Database(array);
            Assert.Throws<InvalidOperationException>(() => database.Add(17), "Database does not throw exception if added 17th integer");
        }

        [Test]
        public void DatabaseRemoveRemovesInteger()
        {
            Database database = new Database(array);
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(15), "Database remove method does not remove integer");
        }

        [Test]
        public void EmptyDatabaseThrowsExceptionIfRemovedInteger()
        {
            Database database = new Database(emptyArray);
            Assert.Throws<InvalidOperationException>(() => database.Remove(), "Empty database does not throw exception if removed integer");
        }

        [Test]
        public void DatabaseFetchReturnsArray()
        {
            Database database = new Database(array);
            Assert.That(database.Fetch(), Is.EqualTo(array), "Database fetch method does not return integer array");
        }
    }
}
