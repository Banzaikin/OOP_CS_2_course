using lab10lib_Shalnev;

namespace lab_10_tests
{
    [TestClass]
    public class ShipTest
    {
        [TestMethod]
        public void Ship_Constructor_WithValidParameters()
        {
            // Arrange
            string name = "TestShip";
            double length = 100.0;
            double tonnage = 5000.0;

            // Act
            var ship = new Ship(name, length, tonnage);

            // Assert
            Assert.AreEqual(name, ship.Name);
            Assert.AreEqual(length, ship.Length);
            Assert.AreEqual(tonnage, ship.Tonnage);
        }

        [TestMethod]
        public void Ship_DefaultConstructor_ShouldInitializeCorrectly()
        {
            // Act
            var ship = new Ship();

            // Assert
            Assert.IsNotNull(ship.Name);
            Assert.IsTrue(ship.Length >= 0);
            Assert.IsTrue(ship.Tonnage >= 0);
        }

        [TestMethod]
        public void Ship_Length_Setter_WithInvalidValue_ShouldPrintErrorMessage()
        {
            // Arrange
            var ship = new Ship();

            // Act
            using (ConsoleOutputInterceptor consoleInterceptor = new ConsoleOutputInterceptor())
            {
                ship.Length = -10.0;

                // Assert
                Assert.IsTrue(consoleInterceptor.Output.Contains("Длина не может быть меньше 0!"));
            }
        }

        [TestMethod]
        public void Ship_Tonnage_Setter_WithInvalidValue_ShouldPrintErrorMessage()
        {
            // Arrange
            var ship = new Ship();

            // Act
            using (ConsoleOutputInterceptor consoleInterceptor = new ConsoleOutputInterceptor())
            {
                ship.Tonnage = -500.0;

                // Assert
                Assert.IsTrue(consoleInterceptor.Output.Contains("Водоизмещение не может быть меньше 0!"));
            }
        }

        [TestMethod]
        public void Ship_GetString_ShouldReturnFormattedString()
        {
            // Arrange
            var ship = new Ship("TestShip", 100.0, 5000.0);

            // Act
            string result = ship.GetString();

            // Assert
            Assert.IsTrue(result.Contains("Название корабля: TestShip"));
            Assert.IsTrue(result.Contains("Длина: 100"));
            Assert.IsTrue(result.Contains("Водоизмещение: 5000"));
        }

        [TestMethod]
        public void Init_ShouldInitializeShipProperties()
        {
            // Arrange
            var ship = new Ship();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                string input = "ShipName\n25,5\n150,5\n";
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);

                    // Act
                    ship.Init();
                }

                // Assert
                Assert.AreEqual("ShipName", ship.Name);
                Assert.AreEqual(25.5, ship.Length);
                Assert.AreEqual(150.5, ship.Tonnage);

                Assert.IsTrue(sw.ToString().Contains("Введите название корабля: "));
                Assert.IsTrue(sw.ToString().Contains("Введите длину корабля: "));
                Assert.IsTrue(sw.ToString().Contains("Введите водоизмещение корабля: "));
            }
        }

        [TestMethod]
        public void Ship_Show_ShouldCallConsoleWriteLine()
        {
            // Arrange
            var ship = new Ship("TestShip", 100.0, 5000.0);

            // Act
            using (ConsoleOutputInterceptor consoleInterceptor = new ConsoleOutputInterceptor())
            {
                ship.Show();

                // Assert
                Assert.IsTrue(consoleInterceptor.Output.Contains("Название корабля: TestShip"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Длина: 100"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Водоизмещение: 5000"));
            }
        }

        [TestMethod]
        public void Ship_SelfShow_ShouldCallConsoleWriteLine()
        {
            // Arrange
            var ship = new Ship("TestShip", 100.0, 5000.0);

            // Act
            using (ConsoleOutputInterceptor consoleInterceptor = new ConsoleOutputInterceptor())
            {
                ship.SelfShow();

                // Assert
                Assert.IsTrue(consoleInterceptor.Output.Contains("Название корабля: TestShip"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Длина: 100"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Водоизмещение: 5000"));
            }
        }

        [TestMethod]
        public void Ship_RandomInit_ShouldInitializeProperties()
        {
            // Arrange
            var ship = new Ship();

            // Act
            ship.RandomInit();

            // Assert
            Assert.IsNotNull(ship.Name);
            Assert.IsTrue(ship.Length >= 0);
            Assert.IsTrue(ship.Tonnage >= 0);
            Assert.IsNotNull(ship.Features);
        }

        [TestMethod]
        public void Ship_Equals_WithEqualObjects_ShouldReturnTrue()
        {
            // Arrange
            var ship1 = new Ship("TestShip", 100.0, 5000.0);
            var ship2 = new Ship("TestShip", 100.0, 5000.0);

            // Act
            bool result = ship1.Equals(ship2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Ship_Equals_WithDifferentObjects_ShouldReturnFalse()
        {
            // Arrange
            var ship1 = new Ship("TestShip1", 100.0, 5000.0);
            var ship2 = new Ship("TestShip2", 150.0, 7000.0);

            // Act
            bool result = ship1.Equals(ship2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Ship_Clone_ShouldCreateDeepCopy()
        {
            // Arrange
            var ship = new Ship("TestShip", 100.0, 5000.0);
            ship.Features.Add("Feature1");
            ship.Features.Add("Feature2");

            // Act
            var clonedShip = (Ship)ship.Clone();

            // Assert
            Assert.AreNotSame(ship, clonedShip);
            Assert.AreEqual(ship.Name, clonedShip.Name);
            Assert.AreEqual(ship.Length, clonedShip.Length);
            Assert.AreEqual(ship.Tonnage, clonedShip.Tonnage);
            CollectionAssert.AreEqual(ship.Features, clonedShip.Features);
        }

        [TestMethod]
        public void Ship_ShallowCopy_ShouldCreateShallowCopy()
        {
            // Arrange
            var ship = new Ship("TestShip", 100.0, 5000.0);
            ship.Features.Add("Feature1");
            ship.Features.Add("Feature2");

            // Act
            var shallowCopy = ship.ShallowCopy();

            // Assert
            Assert.AreNotSame(ship, shallowCopy);
            Assert.AreEqual(ship.Name, shallowCopy.Name);
            Assert.AreEqual(ship.Length, shallowCopy.Length);
            Assert.AreEqual(ship.Tonnage, shallowCopy.Tonnage);
            Assert.AreSame(ship.Features, shallowCopy.Features);
        }

        [TestMethod]
        public void Ship_CompareTo_WithNullObject_ShouldReturn1()
        {
            // Arrange
            var ship = new Ship("TestShip", 100.0, 5000.0);

            // Act
            int result = ship.CompareTo(null);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Ship_CompareTo_WithEqualObjects_ShouldReturn0()
        {
            // Arrange
            var ship1 = new Ship("TestShip", 100.0, 5000.0);
            var ship2 = new Ship("TestShip", 100.0, 5000.0);

            // Act
            int result = ship1.CompareTo(ship2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Ship_CompareTo_WithDifferentNames_ShouldReturnComparison()
        {
            // Arrange
            var ship1 = new Ship("TestShip1", 100.0, 5000.0);
            var ship2 = new Ship("TestShip2", 100.0, 5000.0);

            // Act
            int result = ship1.CompareTo(ship2);

            // Assert
            Assert.AreEqual(String.Compare(ship1.Name, ship2.Name), result);
        }

        [TestMethod]
        public void Ship_CompareTo_WithDifferentLengths_ShouldReturnComparison()
        {
            // Arrange
            var ship1 = new Ship("TestShip", 150.0, 5000.0);
            var ship2 = new Ship("TestShip", 100.0, 5000.0);

            // Act
            int result = ship1.CompareTo(ship2);

            // Assert
            Assert.AreEqual(ship1.Length.CompareTo(ship2.Length), result);
        }

        [TestMethod]
        public void Ship_CompareTo_WithDifferentTonnages_ShouldReturnComparison()
        {
            // Arrange
            var ship1 = new Ship("TestShip", 100.0, 7000.0);
            var ship2 = new Ship("TestShip", 100.0, 5000.0);

            // Act
            int result = ship1.CompareTo(ship2);

            // Assert
            Assert.AreEqual(ship1.Tonnage.CompareTo(ship2.Tonnage), result);
        }

        [TestMethod]
        public void Ship_ToString_ShouldReturnFormattedString()
        {
            // Arrange
            var ship = new Ship("TestShip", 100.0, 5000.0);

            // Act
            string result = ship.ToString();

            // Assert
            Assert.IsTrue(result.Contains("Название корабля: TestShip"));
            Assert.IsTrue(result.Contains("Длина: 100"));
            Assert.IsTrue(result.Contains("Водоизмещение: 5000"));
        }

        private class ConsoleOutputInterceptor : IDisposable
        {
            private readonly StringWriter stringWriter;
            private readonly TextWriter originalOutput;

            public ConsoleOutputInterceptor()
            {
                stringWriter = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public string Output => stringWriter.ToString();

            public void Dispose()
            {
                Console.SetOut(originalOutput);
                stringWriter.Dispose();
            }
        }
    }
}