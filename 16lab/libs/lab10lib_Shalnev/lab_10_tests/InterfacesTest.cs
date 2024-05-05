using lab10lib_Shalnev;
using System.Collections;

namespace lab_10_tests
{
    [TestClass]
    public class InterfacesTest
    {
        [TestMethod]
        public void SortByLength_Compare_WhenFirstShipIsLonger_ShouldReturnPositive()
        {
            // Arrange
            var sortByLength = new SortByLength();
            var ship1 = new Ship("Ship1", 100.0, 5000.0);
            var ship2 = new Ship("Ship2", 80.0, 4000.0);

            // Act
            int result = ((IComparer)sortByLength).Compare(ship1, ship2);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void SortByLength_Compare_WhenFirstShipIsShorter_ShouldReturnNegative()
        {
            // Arrange
            var sortByLength = new SortByLength();
            var ship1 = new Ship("Ship1", 80.0, 4000.0);
            var ship2 = new Ship("Ship2", 100.0, 5000.0);

            // Act
            int result = ((IComparer)sortByLength).Compare(ship1, ship2);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void SortByLength_Compare_WhenShipsHaveEqualLength_ShouldReturnZero()
        {
            // Arrange
            var sortByLength = new SortByLength();
            var ship1 = new Ship("Ship1", 100.0, 5000.0);
            var ship2 = new Ship("Ship2", 100.0, 4000.0);

            // Act
            int result = ((IComparer)sortByLength).Compare(ship1, ship2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SortByLength_Compare_WhenOneShipIsNull_ShouldReturnPositive()
        {
            // Arrange
            var sortByLength = new SortByLength();
            var ship1 = new Ship("Ship1", 100.0, 5000.0);
            Ship? ship2 = null;

            // Act
            int result = ((IComparer)sortByLength).Compare(ship1, ship2);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void SortByLength_Compare_WhenBothShipsAreNull_ShouldReturnZero()
        {
            // Arrange
            var sortByLength = new SortByLength();
            Ship? ship1 = null;
            Ship? ship2 = null;

            // Act
            int result = ((IComparer)sortByLength).Compare(ship1, ship2);

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}