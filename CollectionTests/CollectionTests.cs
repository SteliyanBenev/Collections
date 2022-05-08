using Collections;
using NUnit.Framework;
using System;
using System.Linq;

namespace CollectionTests
{
    public class Tests
    {

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            // Arrange/Act

            var collection = new Collection<int>();

            // Assert

            Assert.AreEqual(0, collection.Count);
            Assert.AreEqual(16, collection.Capacity);
        }

        [Test]

        public void Test_Collection_ConstructorSingleItem()
        {
            // Arrange

            int[] numbers = { 5 };
            var freeCapacity = 16 - numbers.Length;

            //Act

            var collection = new Collection<int>(numbers);

            //Assert

            Assert.AreEqual(numbers.Length, collection.Count);
            Assert.AreEqual(freeCapacity, collection.Capacity - collection.Count);
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            //Arrange

            int[] numbers = { 5, 7, 9, 11, 15 };
            var freeCapacity = 16 - numbers.Length;

            //Act

            var collection = new Collection<int>(numbers);

            //Assert

            Assert.AreEqual(numbers.Length, collection.Count);
            Assert.AreEqual(freeCapacity, collection.Capacity - collection.Count);
        }

        [Test]
        public void Test_Collection_Add()
        {
            //Arrange

            int[] numbers = { 5, 7, 9, 11, 15 };
            var freeCapacity = 16 - numbers.Length;

            //Act

            var collection = new Collection<int>(numbers);
            collection.Add(6);

            //Assert

            Assert.AreEqual(numbers.Length + 1, collection.Count);
            Assert.AreEqual(freeCapacity - 1, collection.Capacity - collection.Count);
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            //Act

            var collection = new Collection<int>(numbers);
            collection.Add(16);

            //Assert

            Assert.AreEqual(numbers.Length + 1, collection.Count);
            Assert.AreEqual(numbers.Length * 2, collection.Capacity);
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            int[] addNumbers = { 7, 8, 9 };

            //Act

            var collection = new Collection<int>(numbers);
            collection.AddRange(addNumbers);

            //Assert

            Assert.AreEqual(numbers.Length + addNumbers.Length, collection.Count);
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            //Act

            var collection = new Collection<int>(numbers);

            //Assert

            Assert.AreEqual(1, collection[0]);
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //Act

            var collection = new Collection<int>(numbers);

            //Assert

            Assert.That(() => collection[7], Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            int insertNumber = 88;

            //Act

            var collection = new Collection<int>(numbers);
            collection.InsertAt(1, insertNumber);

            //Assert

            Assert.That(collection[1], Is.EqualTo(insertNumber));
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            int insertNumber = 88;

            //Act

            var collection = new Collection<int>(numbers);

            //Assert

            Assert.That(() => collection.InsertAt(17, insertNumber), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] addRangeNumbers = { 16, 17, 18 };

            //Act

            var collection = new Collection<int>(numbers);
            collection.AddRange(addRangeNumbers);

            //Assert

            Assert.AreEqual(numbers.Length + addRangeNumbers.Length, collection.Count);
        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            int insertNumber = 88;

            //Act

            var collection = new Collection<int>(numbers);
            collection.InsertAt(0, insertNumber);

            //Assert

            Assert.AreEqual(insertNumber, collection[0]);
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            int insertNumber = 88;

            //Act

            var collection = new Collection<int>(numbers);
            collection.InsertAt(numbers.Length, insertNumber);

            //Assert

            Assert.AreEqual(insertNumber, collection[numbers.Length]);
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            int insertNumber = 88;

            //Act

            var collection = new Collection<int>(numbers);
            collection.InsertAt(numbers.Length/2, insertNumber);

            //Assert

            Assert.AreEqual(insertNumber, collection[numbers.Length/2]);
        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int insertNumber = 88;

            //Act

            var collection = new Collection<int>(numbers);
            collection.InsertAt(numbers.Length, insertNumber);

            //Assert

            Assert.AreEqual(numbers.Length * 2, collection.Capacity);
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            int insertNumber = 88;

            //Act

            var collection = new Collection<int>(numbers);

            //Assert

            Assert.That(() => collection.InsertAt(numbers.Length * 2, insertNumber), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //Act

            var collection = new Collection<int>(numbers);
            collection.Exchange(numbers.Length / 2 - 1, numbers.Length/2);

            //Assert
            Assert.AreEqual(numbers[numbers.Length / 2], collection[numbers.Length / 2 - 1]);
            Assert.AreEqual(numbers[numbers.Length / 2 - 1], collection[numbers.Length / 2]);
        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //Act

            var collection = new Collection<int>(numbers);
            collection.Exchange(0, numbers.Length - 1);

            //Assert
            Assert.AreEqual(numbers[0], collection[numbers.Length - 1]);
            Assert.AreEqual(numbers[numbers.Length - 1], collection[0]);
        }

        [Test]
        public void Test_Collection_ExchangeInvalidIndexes()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //Act

            var collection = new Collection<int>(numbers);

            //Assert

            Assert.That(() => collection.InsertAt(numbers.Length * 2, numbers.Length * 2 + 1), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //Act

            var collection = new Collection<int>(numbers);
            collection.RemoveAt(0);

            //Assert

            Assert.AreEqual(numbers[1], collection[0]);
        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //Act

            var collection = new Collection<int>(numbers);
            collection.RemoveAt(numbers.Length - 1);

            //Assert

            Assert.AreEqual(numbers.Length - 1, collection.Count);
        }

        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //Act

            var collection = new Collection<int>(numbers);
            collection.RemoveAt(numbers.Length / 2 - 1);

            //Assert

            Assert.AreEqual(numbers.Length / 2 + 1, collection[numbers.Length / 2 - 1]);
        }

        [Test]
        public void Test_Collection_RemoveAtInvalidIndex()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //Act

            var collection = new Collection<int>(numbers);

            //Assert

            Assert.That(() => collection.RemoveAt(numbers.Length), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_RemoveAll()
        {
            //Arrange

            int[] numbers = { 1 };

            //Act

            var collection = new Collection<int>(numbers);
            collection.RemoveAt(0);

            //Assert
            Assert.AreEqual(0, collection.Count);
        }

        [Test]
        public void Test_Collection_Clear()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //Act

            var collection = new Collection<int>(numbers);
            collection.Clear();

            //Assert
            Assert.AreEqual(0, collection.Count);
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            //Arrange

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //Act

            var collection = new Collection<int>(numbers);

            //Assert

            Assert.AreEqual(numbers.Length, collection.Count);
            Assert.AreEqual(16, collection.Capacity);
        }

        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            //Arrange/Act

            var collection = new Collection<int>();

            //Assert

            Assert.That(collection.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ToStringSingle()
        {
            //Arrange
            int[] numbers = { 1 };

            //Act

            var collection = new Collection<int>(numbers);

            //Assert

            Assert.That(collection.ToString(), Is.EqualTo("[1]"));
        }

        [Test]
        public void Test_Collection_ToStringMultiple()
        {
            //Arrange
            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //Act

            var collection = new Collection<int>(numbers);

            //Assert

            Assert.That(collection.ToString(), Is.EqualTo("[1, 2, 3, 4, 5, 6]"));
        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            //Arrange
            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            int[] insertNumbers = { 8, 9, 10 };

            //Act

            var collection = new Collection<int>(numbers);
            collection.AddRange(insertNumbers);

            //Assert

            Assert.That(collection.ToString(), Is.EqualTo("[1, 2, 3, 4, 5, 6, 8, 9, 10]"));
        }

        [Test]
        public void Test_Collection_1MillionItems()
        {

            //Arrange

            const int itemsCount = 1000000;

            //Act

            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());

            //Assert

            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            
        }

    }
}