using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_OOP_11;
using Lab_10;

namespace Lab_OOP_11.Tests
{
    [TestClass]
    public class TestCollectionsTests
    {
        [TestMethod]
        public void Add_AddsLibraryToCollections()
        {
            // Arrange
            var testCollections = new TestCollections();
            var library = new Library();

            // Act
            bool result = testCollections.Add(library);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, testCollections.Count);
        }

        [TestMethod]
        public void Add_ReturnsFalseIfLibraryAlreadyExists()
        {
            // Arrange
            var testCollections = new TestCollections();
            var library = new Library();
            testCollections.Add(library);

            // Act
            bool result = testCollections.Add(library);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, testCollections.Count);
        }

        [TestMethod]
        public void DeleteElem_RemovesLibraryFromCollections()
        {
            // Arrange
            var testCollections = new TestCollections();
            var library = new Library();
            testCollections.Add(library);

            // Act
            bool result = testCollections.DeleteElem(library);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, testCollections.Count);
        }

        [TestMethod]
        public void DeleteElem_ReturnsFalseIfLibraryDoesNotExist()
        {
            // Arrange
            var testCollections = new TestCollections();
            var library = new Library();

            // Act
            bool result = testCollections.DeleteElem(library);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0, testCollections.Count);
        }

        [TestMethod]
        public void AreEqual_RandomInitSizeCollection()
        {
            // Arrange
            var testLibrary = new TestCollections();

            // Act
            testLibrary.RandomInit(5);

            // Assert
            Assert.AreEqual(5, testLibrary.Count);
        }
    }
}