using BinaryTree;
using lab10lib_Shalnev;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _12lab_Shalnev_Tests
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void Add_AddingAnItem_IncreasesCount()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void Add_AddingMultipleItems_IncreasesCount()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(15);
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void Add_AddingDuplicateItem_ThrowsException()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            Assert.ThrowsException<InvalidOperationException>(() => tree.Add(5));
        }

        [TestMethod]
        public void Clear_ClearingTree_ResetsCountToZero()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Clear();
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void Contains_FindingExistingItem_ReturnsTrue()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            Assert.IsTrue(tree.Contains(5));
        }

        [TestMethod]
        public void Contains_FindingNonExistingItem_ReturnsFalse()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            Assert.IsFalse(tree.Contains(10));
        }

        [TestMethod]
        public void Remove_RemovingExistingItem_DecreasesCount()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Remove(5);
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void Remove_RemovingNonExistingItem_DoesNotDecreaseCount()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Remove(10);
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void Remove_RemovingItemFromEmptyTree_ReturnsFalse()
        {
            var tree = new BinaryTree<int>();
            Assert.IsFalse(tree.Remove(5));
        }

        [TestMethod]
        public void Find_FindingExistingItem_ReturnsItem()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            Assert.AreEqual(5, tree.Find(5));
        }

        [TestMethod]
        public void Find_FindingNonExistingItem_ReturnsDefault()
        {
            var tree = new BinaryTree<int>();
            Assert.AreEqual(default(int), tree.Find(10));
        }

        [TestMethod]
        public void CopyTo_CopiesItemsToArray()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(15);

            int[] array = new int[3];
            tree.CopyTo(array, 0);

            CollectionAssert.AreEqual(new int[] { 5, 10, 15 }, array);
        }

        [TestMethod]
        public void Clone_CreatesDeepCopyOfTree()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(15);

            var clonedTree = (BinaryTree<int>)tree.Clone();

            Assert.AreEqual(tree.Count, clonedTree.Count);
            CollectionAssert.AreEqual(tree.ToArray(), clonedTree.ToArray());
        }

        [TestMethod]
        public void ShallowCopy_CreatesShallowCopyOfTree()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(15);

            var shallowCopy = (BinaryTree<int>)tree.ShallowCopy();

            Assert.AreEqual(tree.Count, shallowCopy.Count);
        }
        [TestMethod]
        public void Find_InEmptyTree_ReturnsDefault()
        {
            // Arrange
            var tree = new BinaryTree<int>();

            // Act
            var result = tree.Find(5);

            // Assert
            Assert.AreEqual(default(int), result);
        }

        [TestMethod]
        public void Find_InNonEmptyTree_ReturnsFoundItem()
        {
            // Arrange
            var tree = new BinaryTree<int>(new[] { 3, 6, 2, 8, 1 });

            // Act
            var result = tree.Find(6);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Find_InNonEmptyTree_ReturnsDefaultIfNotFound()
        {
            // Arrange
            var tree = new BinaryTree<int>(new[] { 3, 6, 2, 8, 1 });

            // Act
            var result = tree.Find(10);

            // Assert
            Assert.AreEqual(default(int), result);
        }

        [TestMethod]
        public void GetEnumerator_ReturnsInOrderTraversal()
        {
            // Arrange
            var tree = new BinaryTree<int>(new[] { 1, 2, 3, 6, 8 });
            var expected = new List<int> { 1, 2, 3, 6, 8 };

            // Act
            var result = new List<int>(tree);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        public void RemoveItem_RootIsNull_ReturnsNull()
        {
            // Arrange
            var tree = new BinaryTree<int>();

            // Act
            var result = tree.Remove(5);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveItem_ItemNotInTree_CountDoesNotChange()
        {
            // Arrange
            var tree = new BinaryTree<int>(new[] { 3, 6, 2, 8, 1 });
            var initialCount = tree.Count;

            // Act
            tree.Remove(10);

            // Assert
            Assert.AreEqual(initialCount, tree.Count);
        }

        [TestMethod]
        public void RemoveItem_ItemInTreeWithNoChildren_CountDecreases()
        {
            // Arrange
            var tree = new BinaryTree<int>(new[] { 3, 6, 2, 8, 1 });
            var initialCount = tree.Count;

            // Act
            tree.Remove(6);

            // Assert
            Assert.AreEqual(initialCount - 1, tree.Count);
        }

        [TestMethod]
        public void RemoveItem_ItemInTreeWithOneChild_CountDecreases()
        {
            // Arrange
            var tree = new BinaryTree<int>(new[] { 3, 6, 2, 8, 1 });
            var initialCount = tree.Count;

            // Act
            tree.Remove(8);

            // Assert
            Assert.AreEqual(initialCount - 1, tree.Count);
        }

        [TestMethod]
        public void RemoveItem_ItemInTreeWithTwoChildren_CountDecreases()
        {
            // Arrange
            var tree = new BinaryTree<int>(new[] { 3, 6, 2, 8, 1, 4, 7, 9 });
            var initialCount = tree.Count;

            // Act
            tree.Remove(6);

            // Assert
            Assert.AreEqual(initialCount - 1, tree.Count);
        }
        [TestMethod]
        public void GetEnumerator_ReturnsExpectedSequence()
        {
            // Arrange
            var tree = new BinaryTree<int>(new int[] { 5, 3, 7, 2, 4, 6, 8 });

            // Act
            var enumerator = tree.GetEnumerator();
            List<int> result = new List<int>();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }

            // Assert
            CollectionAssert.AreEqual(new int[] { 2, 3, 4, 5, 6, 7, 8 }, result);
        }

        [TestMethod]
        public void InOrderTraversal_ReturnsExpectedSequence()
        {
            // Arrange
            var tree = new BinaryTree<int>(new int[] { 5, 3, 7, 2, 4, 6, 8 });

            // Act
            List<int> result = new List<int>();
            foreach (var item in tree.LNR())
            {
                result.Add(item);
            }

            // Assert
            CollectionAssert.AreEqual(new int[] { 2, 3, 4, 5, 6, 7, 8 }, result);
        }

        [TestMethod]
        public void RemoveItem_RightChildIsNull_DecrementsCountAndReturnsLeftChild()
        {
            // Arrange
            var tree = new BinaryTree<int>(new int[] { 5, 3 });
            tree.Remove(5);

            // Assert
            Assert.AreEqual(1, tree.Count);
            Assert.IsTrue(tree.Contains(3));
        }
        [TestMethod]
        public void ContainsItem_ComparisonResultIsNegative_RecursivelySearchesInLeftSubtree()
        {
            // Arrange
            var tree = new BinaryTree<int>(new int[] { 1, 2, 3 });

            // Act
            bool result = tree.Contains(1);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ContainsItem_ComparisonResultIsZero_ReturnsTrue()
        {
            // Arrange
            var tree = new BinaryTree<int>(new int[] { 1, 2, 3 });

            // Act
            bool result = tree.Contains(2);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetEnumerator_ReturnsCorrectOrder()
        {
            // Arrange
            var tree = new BinaryTree<int>(new int[] { 5, 3, 7, 2, 4, 6, 8 });
            var expected = new List<int> { 2, 3, 4, 5, 6, 7, 8 };

            // Act
            var enumerator = tree.GetEnumerator();
            var actual = new List<int>();
            while (enumerator.MoveNext())
            {
                actual.Add(enumerator.Current);
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Compare_Ship1Longer_Returns1()
        {
            // Arrange
            var ship1 = new Ship { Length = 100 };
            var ship2 = new Ship { Length = 50 };
            var comparer = new Comparer();

            // Act
            var result = comparer.Compare(ship1, ship2);

            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Compare_Ship2Longer_ReturnsMinus1()
        {
            // Arrange
            var ship1 = new Ship { Length = 50 };
            var ship2 = new Ship { Length = 100 };
            var comparer = new Comparer();

            // Act
            var result = comparer.Compare(ship1, ship2);

            // Assert
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void Compare_SameLength_Returns0()
        {
            // Arrange
            var ship1 = new Ship { Length = 50 };
            var ship2 = new Ship { Length = 50 };
            var comparer = new Comparer();

            // Act
            var result = comparer.Compare(ship1, ship2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Compare_NullShip1_Returns0()
        {
            // Arrange
            Ship ship1 = null;
            var ship2 = new Ship { Length = 50 };
            var comparer = new Comparer();

            // Act
            var result = comparer.Compare(ship1, ship2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Compare_NullShip2_Returns0()
        {
            // Arrange
            var ship1 = new Ship { Length = 50 };
            Ship ship2 = null;
            var comparer = new Comparer();

            // Act
            var result = comparer.Compare(ship1, ship2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Compare_BothNull_Returns0()
        {
            // Arrange
            Ship ship1 = null;
            Ship ship2 = null;
            var comparer = new Comparer();

            // Act
            var result = comparer.Compare(ship1, ship2);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}