using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_OOP_10;

namespace Lab_OOP_10.Tests
{
    [TestClass]
    public class ShipBuildingCompanyTests
    {
        [TestMethod]
        public void NumShip_SetNegativeValue_ShouldSetToZero()
        {
            // Arrange
            var company = new ShipBuildingCompany();

            // Act
            company.NumShip = 0;

            // Assert
            Assert.AreEqual(0, company.NumShip);
        }

        [TestMethod]
        public void GetString_ReturnsCorrectString()
        {
            // Arrange
            var company = new ShipBuildingCompany("Company", "Address", 10, 1000, 5);

            // Act
            var result = company.GetString();

            // Assert
            Assert.AreEqual("Название: Company\nАдрес: Address\nКол-во сотрудников: 10\nЦена страховки: 1000\nКол-во кораблей: 5\n", result);
        }

        [TestMethod]
        public void Clone_ReturnsDeepCopy()
        {
            // Arrange
            var company1 = new ShipBuildingCompany("Company", "Address", 10, 1000, 5);

            // Act
            var company2 = (ShipBuildingCompany)company1.Clone();

            // Assert
            Assert.AreNotSame(company1, company2);
            Assert.AreEqual(company1.Name, company2.Name);
            Assert.AreEqual(company1.Address, company2.Address);
            Assert.AreEqual(company1.NumEmployess, company2.NumEmployess);
            Assert.AreEqual(company1.Price, company2.Price);
            Assert.AreEqual(company1.NumShip, company2.NumShip);
            Assert.AreNotSame(company1.Tags, company2.Tags);
            Assert.AreEqual(company1.Tags.Count, company2.Tags.Count);
            for (int i = 0; i < company1.Tags.Count; i++)
            {
                Assert.AreEqual(company1.Tags[i], company2.Tags[i]);
            }
        }

        [TestMethod]
        public void ShallowCopy_ReturnsShallowCopy()
        {
            // Arrange
            var company1 = new ShipBuildingCompany("Company", "Address", 10, 1000, 5);

            // Act
            var company2 = (ShipBuildingCompany)company1.ShallowCopy();

            // Assert
            Assert.AreNotSame(company1, company2);
            Assert.AreEqual(company1.Name, company2.Name);
            Assert.AreEqual(company1.Address, company2.Address);
            Assert.AreEqual(company1.NumEmployess, company2.NumEmployess);
            Assert.AreEqual(company1.Price, company2.Price);
            Assert.AreEqual(company1.NumShip, company2.NumShip);
            Assert.AreSame(company1.Tags, company2.Tags);
        }
    }
}