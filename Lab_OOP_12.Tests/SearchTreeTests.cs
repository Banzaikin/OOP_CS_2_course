using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_10;
using Lab_OOP_12;

namespace Lab_OOP_12.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void AddNode_ToEmptyTree_IncrementsCount()
        {
            // Arrange
            BinarySearchTree<Organization> tree = new BinarySearchTree<Organization>(new CustomComparer());
            Organization[] organizations = new Organization[2];
            for (int i = 0; i < 2; i++)
                organizations[i] = new Organization();
            // Act
            tree.AddRange(organizations);

            // Assert
            Assert.AreEqual(2, tree.Count);
        }

        [TestMethod]
        public void RemoveNode_FromTree_DecreasesCount()
        {
            // Arrange
            BinarySearchTree<Organization> tree = new BinarySearchTree<Organization>(new CustomComparer());
            Organization[] organizations = new Organization[2];
            organizations[0] = new Organization("Организация_1", "ул. Пушкина, д. 1", 1); 
            organizations[1] = new Organization();
            tree.AddRange(organizations);

            BinarySearchTree<Organization> newTree = new BinarySearchTree<Organization>(new CustomComparer());
            Organization[] org = new Organization[1];
            org[0] = new Organization("Организация_1", "ул. Пушкина, д. 1", 1);
            newTree.AddRange(org);

            // Act
            foreach (var item in newTree)
                tree.Remove(item);

            // Assert
            Assert.AreEqual(1, newTree.Count);
        }

        [TestMethod]
        public void RemoveNode_ThatIsNotOrganizationree_ReturnsFalse()
        {
            // Arrange
            BinarySearchTree<Organization> tree = new BinarySearchTree<Organization>(new CustomComparer());
            Organization[] organizations = new Organization[2];
            organizations[0] = new Organization();
            organizations[1] = new Organization();
            tree.AddRange(organizations);

            // Act
            bool result = tree.Remove(organizations[0]);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void MinValue_Returns_Minimum_Value_In_Tree()
        {
            // Arrange
            var tree = new BinarySearchTree<Organization>(new CustomComparer());
            Organization[] organizations = new Organization[1];
            organizations[0] = new Organization();
            organizations[0].Name = "Организация_1";
            organizations[0].Address = "ул. Пушкина, д. 1";
            organizations[0].NumEmployess = 1;
            tree.AddRange(organizations);
            Organization org = new Organization("Организация_1", "ул. Пушкина, д. 1", 1);
            var output = ($"Название: Организация_1\nАдрес: ул. Пушкина, д. 1\nКол-во сотрудников: 1\n");

            // Act
            Organization minValue = tree.MinValue(tree.RootNode);

            // Assert
            Assert.AreEqual(output.Length, minValue.ToString().Length);
        }

        [TestMethod]
        public void Find_Returns_Item_If_Found()
        {
            // Arrange
            var tree = new BinarySearchTree<Organization>(new CustomComparer());
            Organization[] organizations = new Organization[1];
            organizations[0] = new Organization();
            organizations[0].Name = "Организация_1";
            organizations[0].Address = "ул. Пушкина, д. 1";
            organizations[0].NumEmployess = 1;
            tree.AddRange(organizations);
            Organization org = new Organization("Организация_1", "ул. Пушкина, д. 1", 1);
            var output = ($"Название: Организация_1\nАдрес: ул. Пушкина, д. 1\nКол-во сотрудников: 1\n");
            // Act
            var foundItem = tree.Find(org);
            
            // Assert
            Assert.AreEqual(output.Length, foundItem.ToString().Length);
        }

        [TestMethod]
        public void Find_Returns_Default_If_Not_Found()
        {
            // Arrange
            var tree = new BinarySearchTree<Organization>(new CustomComparer());
            Organization[] organizations = new Organization[1];
            organizations[0] = new Organization();
            organizations[0].Name = "Организация_1";
            organizations[0].Address = "ул. Пушкина, д. 1";
            organizations[0].NumEmployess = 1;
            tree.AddRange(organizations);
            Organization org1 = new Organization("Организация_1", "ул. Пушкина, д. 1", 1);
            Organization org2 = new Organization();
            // Act
            Organization foundItem = tree.Find(org2);

            // Assert
            Assert.AreEqual(default(Organization), foundItem);
        }

        [TestMethod]
        public void Clear_RootNodeIsNull()
        {
            var tree = new BinarySearchTree<Organization>(new CustomComparer());
            tree.Clear();
            Assert.IsNull(tree.RootNode);
        }

        [TestMethod]
        public void Clear_CountIsZero()
        {
            var tree = new BinarySearchTree<Organization>(new CustomComparer());
            tree.Clear();
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void Clone_ReturnsNewInstance()
        {
            var tree = new BinarySearchTree<Organization>(new CustomComparer());
            var clonedTree = tree.Clone();
            Assert.AreNotSame(tree, clonedTree);
        }

        [TestMethod]
        public void ShallowCopy_ReturnsNewInstance()
        {
            var tree = new BinarySearchTree<Organization>(new CustomComparer());
            var shallowCopy = tree.ShallowCopy();
            Assert.AreNotSame(tree, shallowCopy);
        }
        
    }
}
