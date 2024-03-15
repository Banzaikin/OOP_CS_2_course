using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_10;
using Lab_OOP_12;
using Lab_OOP_14;

namespace Lab_OOP_14.Tests
{
    [TestClass]
    public class ExtencionMethodsTests
    {
        [TestMethod]
        public void SelectOrgTest()
        {
            var tree = new BinarySearchTree<Organization>();
            // добавляем элементы в дерево tree
            tree = Program.CreateTreeRandom(5);
            IEnumerable<Organization> result = tree.SelectOrg(org => org is Factory);
            IEnumerable<Organization> subset = tree.Where(org => org is Factory);

            // проверка результата
            Assert.AreEqual(result.Count(), subset.Count());
        }

        [TestMethod]
        public void CountOrgTest()
        {
            var tree = new BinarySearchTree<Organization>();
            // добавляем элементы в дерево tree

            int count = tree.CountOrg(org => org.NumEmployess > 0);
            int subset = tree.Where(org => org.NumEmployess > 0).Count();

            // проверка результата
            Assert.AreEqual(subset, count);
        }

        [TestMethod]
        public void SortOrgTest()
        {
            var tree = new BinarySearchTree<Organization>();
            // добавляем элементы в дерево tree
            tree = Program.CreateTreeRandom(5);
            BinarySearchTree<Organization> sortedTree = tree.SortOrg(org => org.NumEmployess);

            // проверка результата
            Assert.IsTrue(tree.Count() == sortedTree.Count());
        }

        [TestMethod]
        public void GroupOrgTest()
        {
            var tree = new BinarySearchTree<Organization>();
            // добавляем элементы в дерево tree
            tree = Program.CreateTreeRandom(5);

            var groups = tree.GroupOrg(org => org.Name);

            // проверка результата
            Assert.IsTrue(groups.Count() > 0);
        }
        [TestMethod]
        public void CreateOrganizationRandomTest()
        {
            // Arrange
            SortedDictionary<int, Queue<Organization>> cities = Program.CreateOrganizationRandom(3, 3);
            
            //проверка результата
            Assert.IsTrue(cities.Count() == 3);
        }
    }
}