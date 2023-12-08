using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_10.Tests
{
    [TestClass]
    public class OrganizationTests
    {
        [TestMethod]
        public void GetString_ShouldReturnCorrectString()
        {
            // Arrange
            Organization organization = new Organization("Организация_1", "ул. Профессора Поздеева", 100);
            List<string> tags = new List<string> { "tag1", "tag2", "tag3" };
            organization.Tags = tags;

            // Act
            string result = organization.GetString();

            // Assert
            string expected = "Название: Организация_1\nАдрес: ул. Профессора Поздеева\nКол-во сотрудников: 100\n";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Organization_Random()
        {
            // Arrange && Act
            Organization organization = new Organization();
            List<string> tags = new List<string> { "tag1", "tag2", "tag3" };
            organization.Tags = tags;

            // Act
            string result = organization.GetString();

            // Assert
            string expected = $"Название: {organization.Name}\nАдрес: {organization.Address}\nКол-во сотрудников: {organization.NumEmployess}\n";
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void Equals_ShouldReturnTrueForEqualObjects()
        {
            // Arrange
            Organization organization1 = new Organization("Организация_1", "ул. Профессора Поздеева", 100);
            organization1.Tags = new List<string> { "tag1", "tag2", "tag3" };

            Organization organization2 = new Organization("Организация_1", "ул. Профессора Поздеева", 100);
            organization2.Tags = new List<string> { "tag1", "tag2", "tag3" };

            // Act
            bool result = organization1.Equals(organization2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetHashCodeIsNotNull()
        {
            // Arrange
            Organization organization = new Organization("Организация_1", "ул. Профессора Поздеева", 100);
            organization.Tags = new List<string> { "tag1", "tag2", "tag3" };

            // Act
            int hashCode = organization.GetHashCode();

            // Assert
            Assert.IsNotNull(hashCode);
        }

        [TestMethod]
        public void Clone_ShouldReturnClonedObjectWithSameValues()
        {
            // Arrange
            Organization organization = new Organization("Организация_1", "ул. Профессора Поздеева", 100);
            organization.Tags = new List<string> { "tag1", "tag2", "tag3" };

            // Act
            Organization clone = (Organization)organization.Clone();

            // Assert
            Assert.AreEqual(organization.Name, clone.Name);
            Assert.AreEqual(organization.Address, clone.Address);
            Assert.AreEqual(organization.NumEmployess, clone.NumEmployess);
            CollectionAssert.AreEqual(organization.Tags, clone.Tags);
        }

        [TestMethod]
        public void Clone_ShouldReturnShallowCopyObjectWithSameValues()
        {
            // Arrange
            Organization organization = new Organization("Организация_1", "ул. Профессора Поздеева", 100);
            organization.Tags = new List<string> { "tag1", "tag2", "tag3" };

            // Act
            Organization clone = (Organization)organization.ShallowCopy();

            // Assert
            Assert.AreEqual(organization.Name, clone.Name);
            Assert.AreEqual(organization.Address, clone.Address);
            Assert.AreEqual(organization.NumEmployess, clone.NumEmployess);
            CollectionAssert.AreEqual(organization.Tags, clone.Tags);
        }

        [TestMethod]
        public void CompareTo_ShouldReturnNegativeNumberWhenNameOfOtherObjectIsGreater()
        {
            // Arrange
            Organization organization1 = new Organization("AAA", "ул. Профессора Поздеева", 100);
            Organization organization2 = new Organization("BBB", "ул. Профессора Поздеева", 100);

            // Act
            int result = organization1.CompareTo(organization2);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void ToString_ShouldReturnStringWithOrganizationInfo()
        {
            // Arrange
            Organization organization = new Organization("Организация_1", "ул. Профессора Поздеева", 100);
            List<string> tags = new List<string> { "tag1", "tag2", "tag3" };
            organization.Tags = tags;

            // Act
            string result = organization.ToString();

            // Assert
            string expected = "Название: Организация_1\nАдрес: ул. Профессора Поздеева\nКол-во сотрудников: 100\n";
            Assert.AreEqual(expected, result);
        }
    }
}
