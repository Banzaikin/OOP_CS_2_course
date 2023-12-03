using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_9.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void CalculationS_ValidTriangle_ReturnsCorrectArea()
        {
            // Arrange
            Triangle triangle = new Triangle(3, 4, 5);
            double expectedArea = 6;

            // Act
            double actualArea = triangle.CalculationS(triangle);

            // Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod]
        public void CalculationS_InvalidTriangle_ReturnsNegativeArea()
        {
            // Arrange
            Triangle triangle = new Triangle(1, 2, 3);
            double expectedArea = -1;

            // Act
            double actualArea = Triangle.CalculationS(1, 2, 3);

            // Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod]
        public void Triangle_CountObjects_ShouldReturnCorrectCount()
        {
            // Arrange
            int initialCount = Triangle.Count();

            // Act
            Triangle Triangle1 = new Triangle();
            Triangle Triangle2 = new Triangle();

            // Assert
            Assert.AreEqual(initialCount + 2, Triangle.Count());
        }

        [TestMethod]
        public void Triangle_DisplayTriangle_ShouldReadCorrectly()
        {
            // Arrange
            Triangle triangle = new Triangle(3, 4, 5);

            // Act
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                triangle.Read();

                // Assert
                string expectedOutput = $"¬ведите 1 сторону: ¬ведите 2 сторону: ¬ведите 3 сторону: ";
                Assert.AreEqual(expectedOutput, consoleOutput.ToString());
            }
        }

        [TestMethod]
        public void OperatorPlusPlus_IncreasesAllSidesByOne()
        {
            // Arrange
            Triangle triangle = new Triangle(2, 3, 4);
            Triangle expectedTriangle = new Triangle(3, 4, 5);

            // Act
            Triangle actualTriangle = ++triangle;

            // Assert
            Assert.AreEqual(expectedTriangle.A, actualTriangle.A);
            Assert.AreEqual(expectedTriangle.B, actualTriangle.B);
            Assert.AreEqual(expectedTriangle.C, actualTriangle.C);
        }

        [TestMethod]
        public void OperatorMinusMinus_DecreasesAllSidesByOne()
        {
            // Arrange
            Triangle triangle = new Triangle(3, 4, 5);
            Triangle expectedTriangle = new Triangle(2, 3, 4);

            // Act
            Triangle actualTriangle = --triangle;

            // Assert
            Assert.AreEqual(expectedTriangle.A, actualTriangle.A);
            Assert.AreEqual(expectedTriangle.B, actualTriangle.B);
            Assert.AreEqual(expectedTriangle.C, actualTriangle.C);
        }
        [TestMethod]
        public void ExplicitOperatorTest()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);
            double expectedDouble = 6;

            // Act
            double actualDouble = (double)triangle;

            // Assert
            Assert.AreEqual(expectedDouble, actualDouble);
        }

        [TestMethod]
        public void ImplicitOperatorTest()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);
            bool expectedBool = true;

            // Act
            bool actualBool = triangle;

            // Assert
            Assert.AreEqual(expectedBool, actualBool);
        }
        [TestMethod]
        public void OperatorLessThanOrEqual_TwoTrianglesWithEqualAreas_ReturnsTrue()
        {
            // Arrange
            Triangle triangle1 = new Triangle(3, 4, 5);
            Triangle triangle2 = new Triangle(6, 8, 10);

            // Act
            bool actualResult = triangle1 <= triangle2;

            // Assert
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void OperatorGreaterThanOrEqual_TwoTrianglesWithEqualAreas_ReturnsTrue()
        {
            // Arrange
            Triangle triangle1 = new Triangle(3, 4, 5);
            Triangle triangle2 = new Triangle(6, 8, 10);

            // Act
            bool actualResult = triangle1 >= triangle2;

            // Assert
            Assert.IsFalse(actualResult);
        }

    }
}
