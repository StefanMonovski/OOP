using _02.ExtendedDatabase;
using NUnit.Framework;
using System;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        public static Person GenerateRandomPerson()
        {
            Random random = new Random();
            long randomLong = Convert.ToInt64(random.Next());
            string randomString = Path.GetRandomFileName();
            return new Person(randomLong, randomString);
        }

        public static Person[] GenerateRandomPersonArray(int length)
        {
            Person[] array = new Person[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GenerateRandomPerson();
            }
            return array;
        }

        Person[] emptyArray = { };
        Person[] array = GenerateRandomPersonArray(8);
        Person[] fullArray = GenerateRandomPersonArray(16);
        Person[] invalidArray = GenerateRandomPersonArray(17);

        [Test]
        public void ExtendedDatabaseThrowsExceptionIfSizeIsOver16People()
        {
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(invalidArray), "Database does not throw exception if size is over 16 integers");
        }

        [Test]
        public void ExtendedDatabaseAddAddsPerson()
        {
            ExtendedDatabase database = new ExtendedDatabase(emptyArray);
            database.Add(GenerateRandomPerson());
            Assert.That(database.Count, Is.EqualTo(1), "Database add method does not add person");
        }

        [Test]
        public void ExtendedDatabaseThrowsExceptionIfAdded17thPerson()
        {
            ExtendedDatabase database = new ExtendedDatabase(fullArray);
            Assert.Throws<InvalidOperationException>(() => database.Add(GenerateRandomPerson()), "Database does not throw exception if added 17th person");
        }

        [Test]
        public void ExtendedDatabaseThrowsExceptionIfAddedExistingUsername()
        {
            ExtendedDatabase database = new ExtendedDatabase(array);
            Person existingPerson = new Person(0, array[1].UserName);
            Assert.Throws<InvalidOperationException>(() => database.Add(existingPerson), "Database does not throw exception if added existing username");
        }

        [Test]
        public void ExtendedDatabaseThrowsExceptionIfAddedExistingPersonId()
        {
            ExtendedDatabase database = new ExtendedDatabase(array);
            Person existingPerson = new Person(array[1].Id, "");
            Assert.Throws<InvalidOperationException>(() => database.Add(existingPerson), "Database does not throw exception if added existing id");
        }

        [Test]
        public void ExtendedDatabaseRemoveRemovesPerson()
        {
            ExtendedDatabase database = new ExtendedDatabase(array);
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(7), "Database remove method does not remove person");
        }

        [Test]
        public void EmptyExtendedDatabaseThrowsExceptionIfRemovedPerson()
        {
            ExtendedDatabase database = new ExtendedDatabase(emptyArray);
            Assert.Throws<InvalidOperationException>(() => database.Remove(), "Empty database does not throw exception if removed person");
        }

        [Test]
        public void ExtendedDatabaseFindByUsernameFindsPerson()
        {
            ExtendedDatabase database = new ExtendedDatabase(fullArray);
            Person existingPerson = fullArray[1];
            Assert.That(database.FindByUsername(existingPerson.UserName), Is.EqualTo(existingPerson), "Database find by username method does not find person");
        }

        [Test]
        public void ExtendedDatabaseThrowsExceptionIfFindByUsernameIsNull()
        {
            ExtendedDatabase database = new ExtendedDatabase(fullArray);
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null), "Database does not throw exception if username is null");
        }

        [Test]
        public void ExtendedDatabaseThrowsExceptionIfNotFoundByUsername()
        {
            ExtendedDatabase database = new ExtendedDatabase(array);
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("not found"), "Database does not throw exception if username is not found");
        }

        [Test]
        public void ExtendedDatabaseFindByIdFindsPerson()
        {
            ExtendedDatabase database = new ExtendedDatabase(fullArray);
            Person existingPerson = fullArray[1];
            Assert.That(database.FindById(existingPerson.Id), Is.EqualTo(existingPerson), "Database find by id method does not find person");
        }

        [Test]
        public void ExtendedDatabaseThrowsExceptionIfFindByIdIsNegative()
        {
            ExtendedDatabase database = new ExtendedDatabase(fullArray);
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1), "Database does not throw exception if id is negative");
        }

        [Test]
        public void ExtendedDatabaseThrowsExceptionIfNotFoundById()
        {
            ExtendedDatabase database = new ExtendedDatabase(array);
            Assert.Throws<InvalidOperationException>(() => database.FindById(0), "Database does not throw exception if id is not found");
        }
    }
}
