using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_OOP_10;

namespace Lab_OOP_10.Tests
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void Library_NumBook_SetValue()
        {
            // Arrange
            var Library = new Library();

            // Act
            Library.NumBook = 50000;

            // Assert
            Assert.AreEqual(50000, Library.NumBook);
        }

        [TestMethod]
        public void Library_GetString_ReturnsFormattedString()
        {
            // Arrange
            var Library = new Library("Library1", "Address1", 100, 50000);

            // Act
            var result = Library.GetString();

            // Assert
            Assert.AreEqual("Название: Library1\nАдрес: Address1\nКол-во сотрудников: 100\nКол-во книг: 50000\n", result);
        }

        //[TestMethod]
        //public void Library_Init_SetsNumBook()
        //{
        //    // Arrange
        //    var Library = new Library();

        //    // Act
        //    Library.Init();

        //    // Assert
        //    Assert.AreNotEqual(0, Library.NumBook);
        //}

        [TestMethod]
        public void Library_RandomInit_SetsRandomNumBook()
        {
            // Arrange
            var library = new Library();

            // Act
            library.RandomInit();

            // Assert
            Assert.AreEqual(0, library.NumBook);
        }

        [TestMethod]
        public void Library_Clone_ReturnsDeepCopy()
        {
            // Arrange
            var Library1 = new Library("Library1", "Address1", 100, 50000);

            // Act
            var Library2 = (Library)Library1.Clone();

            // Modify Library1
            Library1.NumBook = 60000;
            Library1.Name = "Library2";

            // Assert
            Assert.AreEqual("Library1", Library2.Name);
            Assert.AreEqual("Address1", Library2.Address);
            Assert.AreEqual(100, Library2.NumEmployess);
            Assert.AreEqual(50000, Library2.NumBook);
        }

        [TestMethod]
        public void ShallowCopy_ReturnsShallowCopy()
        {
            // Arrange
            var Library1 = new Library("Library1", "Address1", 100, 50000);

            // Act
            var Library2 = (Library)Library1.ShallowCopy();

            // Modify Library1
            Library1.NumBook = 60000;
            Library1.Name = "Library2";

            // Assert
            Assert.AreEqual("Library1", Library2.Name);
            Assert.AreEqual("Address1", Library2.Address);
            Assert.AreEqual(100, Library2.NumEmployess);
            Assert.AreEqual(50000, Library2.NumBook);
        }
    }
}