using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Lab_OOP_9.Tests
{
    [TestClass]
    public class TriangleArrayTests
    {
        [TestMethod]
        public void Constructor_DefaultSize_Zero()
        {
            // Arrange
            int expectedSize = 0;

            // Act
            TriangleArray array = new TriangleArray();

            // Assert
            Assert.AreEqual(expectedSize, array.Size);
        }

        [TestMethod]
        public void Constructor_PositiveSize_ArrayWithCorrectSize()
        {
            // Arrange
            int expectedSize = 5;

            // Act
            TriangleArray array = new TriangleArray(expectedSize);

            // Assert
            Assert.AreEqual(expectedSize, array.Size);
        }

        [TestMethod]
        public void TriangleArray_ConstructorWithSizeAndUserInput_ShouldCreateArrayWithUserInputValues()
        {
            // Arrange
            var input = new System.IO.StringReader("5\n3\n4\n5\n12\n13\n6\n15\n17\n");
            System.Console.SetIn(input);

            // Act
            TriangleArray triangleArray = new TriangleArray(3);

            // Assert
            Assert.AreEqual(3, triangleArray.Size);
        }

        [TestMethod]
        public void TriangleArray_Constructor_ParamsTriangle()
        {
            // Arrange
            var triangleArray = new TriangleArray(
                new Triangle(3, 4, 5),
                new Triangle(12, 13, 5),
                new Triangle(6, 8, 10)
            );

            // Act


            // Assert
            Assert.AreEqual(3, triangleArray.Size);
        }

        [TestMethod]
        public void TriangleArray_Indexer_GetElement_ShouldReturnCorrectValue()
        {
            // Arrange
            var TriangleArray = new TriangleArray(3);
            var expectedValue = new Triangle(5, 30, 12);
            TriangleArray[1] = expectedValue;

            // Act
            var actualValue = TriangleArray[1];

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TriangleArray_Indexer_GetElement_InvalidIndex_ShouldThrowException()
        {
            // Arrange
            var TriangleArray = new TriangleArray(3);

            // Act & Assert
            var value = TriangleArray[-1];
        }

        [TestMethod]
        public void TriangleArray_Indexer_SetElement_ShouldSetCorrectValue()
        {
            // Arrange
            var TriangleArray = new TriangleArray(3);
            var expectedValue = new Triangle(8, 45);

            // Act
            TriangleArray[1] = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, TriangleArray[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TriangleArray_Indexer_SetElement_InvalidIndex_ShouldThrowException()
        {
            // Arrange
            var TriangleArray = new TriangleArray(3);

            // Act & Assert
            TriangleArray[-1] = new Triangle(3, 50, 12);
        }

        [TestMethod]
        public void Display_EmptyArray_PrintsEmptyMessage()
        {
            // Arrange
            TriangleArray array = new TriangleArray();

            // Act
            string consoleOutput = CaptureConsoleOutput(() =>
            {
                array.Display();
            });

            // Assert
            Assert.AreEqual("Массив пуст.", consoleOutput.Trim());
        }

        private string CaptureConsoleOutput(Action action)
        {
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);
                action();
                return consoleOutput.ToString();
            }
        }
    }
}