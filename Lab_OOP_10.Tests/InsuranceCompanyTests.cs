using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static System.IO.StringWriter;

namespace Lab_OOP_10.Tests
{
    [TestClass]
    public class InsuranceCompanyTests
    {
        [TestMethod]
        public void Price_SetNegativeValue_ShouldSetPositiveValue()
        {
            // Arrange
            int expectedPrice = 1000;
            InsuranceCompany insuranceCompany = new InsuranceCompany();

            // Act
            insuranceCompany.Price = 1000;

            // Assert
            Assert.AreEqual(expectedPrice, insuranceCompany.Price);
        }

        [TestMethod]
        public void GetString_ReturnsCorrectString()
        {
            // Arrange
            string expectedString = "Название: ACME Insurance\nАдрес: 123 Main St\nКол-во сотрудников: 100\nЦена страховки: 500\n";
            InsuranceCompany insuranceCompany = new InsuranceCompany("ACME Insurance", "123 Main St", 100, 500);

            // Act
            string result = insuranceCompany.GetString();

            // Assert
            Assert.AreEqual(expectedString, result);
        }

        [TestMethod]
        public void OrgShow_DisplaysCorrectOutput()
        {
            // Arrange
            InsuranceCompany insuranceCompany = new InsuranceCompany("ACME Insurance", "123 Main St", 100, 5000);

            // Act
            string result = insuranceCompany.ToString();

            // Assert
            string expectedOutput = "Название: ACME Insurance\nАдрес: 123 Main St\nКол-во сотрудников: 100\nЦена страховки: 5000\n";
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void Clone_ReturnsDeepCopy()
        {
            // Arrange
            InsuranceCompany company1 = new InsuranceCompany("ACME Insurance", "123 Main St", 100, 5000);

            // Act
            InsuranceCompany company2 = (InsuranceCompany)company1.Clone();

            // Assert
            Assert.AreNotSame(company1, company2);
            Assert.AreEqual(company1.Name, company2.Name);
            Assert.AreEqual(company1.Address, company2.Address);
            Assert.AreEqual(company1.NumEmployess, company2.NumEmployess);
            Assert.AreEqual(company1.Price, company2.Price);
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
            InsuranceCompany company1 = new InsuranceCompany("ACME Insurance", "123 Main St", 100, 5000);

            // Act
            InsuranceCompany company2 = (InsuranceCompany)company1.ShallowCopy();

            // Assert
            Assert.AreNotSame(company1, company2);
            Assert.AreEqual(company1.Name, company2.Name);
            Assert.AreEqual(company1.Address, company2.Address);
            Assert.AreEqual(company1.NumEmployess, company2.NumEmployess);
            Assert.AreEqual(company1.Price, company2.Price);
            Assert.AreSame(company1.Tags, company2.Tags);
        }
    }
}