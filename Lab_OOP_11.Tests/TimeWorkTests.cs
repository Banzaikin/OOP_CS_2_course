using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Lab_OOP_11.Tests
{
    [TestClass]
    public class TimeWorkTests
    {
        [TestMethod]
        public void OrganizationOfWorkQueue_WhenObjectExists_ReturnsTimeAndFoundTrue()
        {
            // Arrange
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            int obj = 2;

            // Act
            string result = TimeWork.OrganizationOfWorkQueue(queue, obj);

            // Assert
            Assert.IsTrue(result.Contains("Найден: True"));
        }

        [TestMethod]
        public void OrganizationOfWorkSortedDictionaryByKey_WhenKeyExists_ReturnsTimeAndFoundTrue()
        {
            // Arrange
            SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();
            sortedDictionary.Add("One", 1);
            sortedDictionary.Add("Two", 2);
            sortedDictionary.Add("Three", 3);
            string key = "Two";

            // Act
            string result = TimeWork.OrganizationOfWorkSortedDictionary(sortedDictionary, key);

            // Assert
            Assert.IsTrue(result.Contains("Найден: True"));
        }

        [TestMethod]
        public void OrganizationOfWorkSortedDictionaryByValue_WhenValueExists_ReturnsTimeAndFoundTrue()
        {
            // Arrange
            SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();
            sortedDictionary.Add("One", 1);
            sortedDictionary.Add("Two", 2);
            sortedDictionary.Add("Three", 3);
            int value = 2;

            // Act
            string result = TimeWork.OrganizationOfWorkSortedDictionary(sortedDictionary, value);

            // Assert
            Assert.IsTrue(result.Contains("Найден: True"));
        }
    }
}