using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_OOP_10;

namespace Lab_OOP_10.Tests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void Factory_AvarageSalary_SetValue()
        {
            // Arrange
            var factory = new Factory();

            // Act
            factory.AvarageSalary = 50000;

            // Assert
            Assert.AreEqual(50000, factory.AvarageSalary);
        }

        [TestMethod]
        public void Factory_GetString_ReturnsFormattedString()
        {
            // Arrange
            var factory = new Factory("Factory1", "Address1", 100, 50000);

            // Act
            var result = factory.GetString();

            // Assert
            Assert.AreEqual("Название: Factory1\nАдрес: Address1\nКол-во сотрудников: 100\nСредняя зарплата: 50000\n", result);
        }

        //[TestMethod]
        //public void Factory_Init_SetsAvarageSalary()
        //{
        //    // Arrange
        //    var factory = new Factory();

        //    // Act
        //    factory.Init();

        //    // Assert
        //    Assert.AreNotEqual(0, factory.AvarageSalary);
        //}

        [TestMethod]
        public void Factory_RandomInit_SetsRandomAvarageSalary()
        {
            // Arrange
            var factory = new Factory();

            // Act
            factory.RandomInit();

            // Assert
            Assert.AreNotEqual(0, factory.AvarageSalary);
        }

        [TestMethod]
        public void Factory_Clone_ReturnsDeepCopy()
        {
            // Arrange
            var factory1 = new Factory("Factory1", "Address1", 100, 50000);

            // Act
            var factory2 = (Factory)factory1.Clone();

            // Modify factory1
            factory1.AvarageSalary = 60000;
            factory1.Name = "Factory2";

            // Assert
            Assert.AreEqual("Factory1", factory2.Name);
            Assert.AreEqual("Address1", factory2.Address);
            Assert.AreEqual(100, factory2.NumEmployess);
            Assert.AreEqual(50000, factory2.AvarageSalary);
        }

        [TestMethod]
        public void ShallowCopy_ReturnsShallowCopy()
        {
            // Arrange
            var factory1 = new Factory("Factory1", "Address1", 100, 50000);

            // Act
            var factory2 = (Factory)factory1.ShallowCopy();

            // Modify factory1
            factory1.AvarageSalary = 60000;
            factory1.Name = "Factory2";

            // Assert
            Assert.AreEqual("Factory1", factory2.Name);
            Assert.AreEqual("Address1", factory2.Address);
            Assert.AreEqual(100, factory2.NumEmployess);
            Assert.AreEqual(50000, factory2.AvarageSalary);
        }
    }
}