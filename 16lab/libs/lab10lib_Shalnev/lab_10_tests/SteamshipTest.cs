using lab10lib_Shalnev;
using Microsoft.VisualStudio.CodeCoverage;
using System.Globalization;

namespace lab_10_tests
{
    [TestClass]
    public class SteamshipTest
    {
        [TestMethod]
        public void Steamship_Constructor_WithValidParameters()
        {
            // Arrange
            string name = "TestSteamship";
            double length = 100.0;
            double tonnage = 5000.0;
            double enginePower = 2000.0;
            int passengerCapacity = 500;

            // Act
            var steamship = new Steamship(name, length, tonnage, enginePower, passengerCapacity);

            // Assert
            Assert.AreEqual(name, steamship.Name);
            Assert.AreEqual(length, steamship.Length);
            Assert.AreEqual(tonnage, steamship.Tonnage);
            Assert.AreEqual(enginePower, steamship.EnginePower);
            Assert.AreEqual(passengerCapacity, steamship.PassengerCapacity);
        }

        [TestMethod]
        public void Steamship_DefaultConstructor_ShouldInitializeCorrectly()
        {
            // Act
            var steamship = new Steamship();

            // Assert
            Assert.IsNotNull(steamship.Name);
            Assert.IsTrue(steamship.Length >= 0);
            Assert.IsTrue(steamship.Tonnage >= 0);
            Assert.IsTrue(steamship.EnginePower >= 0);
            Assert.IsTrue(steamship.PassengerCapacity >= 0);
        }

        [TestMethod]
        public void Steamship_GetString_ShouldReturnFormattedString()
        {
            // Arrange
            var steamship = new Steamship("TestSteamship", 100.0, 5000.0, 2000.0, 500);

            // Act
            string result = steamship.GetString();

            // Assert
            Assert.IsTrue(result.Contains("Название корабля: TestSteamship"));
            Assert.IsTrue(result.Contains("Длина: 100"));
            Assert.IsTrue(result.Contains("Водоизмещение: 5000"));
            Assert.IsTrue(result.Contains("Мощность двигателя: 2000"));
            Assert.IsTrue(result.Contains("Пассажирская вместимость: 500"));
        }

        [TestMethod]
        public void Steamship_Show_ShouldCallConsoleWriteLine()
        {
            // Arrange
            var steamship = new Steamship("TestSteamship", 100.0, 5000.0, 2000.0, 500);

            // Act
            using (ConsoleOutputInterceptor consoleInterceptor = new ConsoleOutputInterceptor())
            {
                steamship.Show();

                // Assert
                Assert.IsTrue(consoleInterceptor.Output.Contains("Название корабля: TestSteamship"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Длина: 100"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Водоизмещение: 5000"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Мощность двигателя: 2000"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Пассажирская вместимость: 500"));
            }
        }

        [TestMethod]
        public void Steamship_SelfShow_ShouldCallConsoleWriteLine()
        {
            // Arrange
            var steamship = new Steamship("TestSteamship", 100.0, 5000.0, 2000.0, 500);

            // Act
            using (ConsoleOutputInterceptor consoleInterceptor = new ConsoleOutputInterceptor())
            {
                steamship.SelfShow();

                // Assert
                Assert.IsTrue(consoleInterceptor.Output.Contains("Название корабля: TestSteamship"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Длина: 100"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Водоизмещение: 5000"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Мощность двигателя: 2000"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Пассажирская вместимость: 500"));
            }
        }

        [TestMethod]
        public void Init_ShouldInitializeSteamshipProperties()
        {
            // Arrange
            var steamship = new Steamship();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                string input = "ShipName\n25,5\n150,5\n1000,75\n200\n";
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);

                    // Act
                    steamship.Init();
                }

                // Assert
                Assert.AreEqual("ShipName", steamship.Name);
                Assert.AreEqual(25.5, steamship.Length);
                Assert.AreEqual(150.5, steamship.Tonnage);
                Assert.AreEqual(1000.75, steamship.EnginePower);
                Assert.AreEqual(200, steamship.PassengerCapacity);

                Assert.IsTrue(sw.ToString().Contains("Введите название корабля: "));
                Assert.IsTrue(sw.ToString().Contains("Введите длину корабля: "));
                Assert.IsTrue(sw.ToString().Contains("Введите водоизмещение корабля: "));

                Assert.IsTrue(sw.ToString().Contains("Введите мощность двигателя: "));
                Assert.IsTrue(sw.ToString().Contains("Введите пассажирскую вместимость: "));
            }
        }

        [TestMethod]
        public void Steamship_RandomInit_ShouldInitializeProperties()
        {
            // Arrange
            var steamship = new Steamship();

            // Act
            steamship.RandomInit();

            // Assert
            Assert.IsNotNull(steamship.Name);
            Assert.IsTrue(steamship.Length >= 0);
            Assert.IsTrue(steamship.Tonnage >= 0);
            Assert.IsTrue(steamship.EnginePower >= 0);
            Assert.IsTrue(steamship.PassengerCapacity >= 0);
        }

        [TestMethod]
        public void Steamship_Clone_ShouldCreateDeepCopy()
        {
            // Arrange
            var steamship = new Steamship("TestSteamship", 100.0, 5000.0, 2000.0, 500);
            steamship.Features.Add("Feature1");
            steamship.Features.Add("Feature2");

            // Act
            var clonedSteamship = (Steamship)steamship.Clone();

            // Assert
            Assert.AreNotSame(steamship, clonedSteamship);
            Assert.AreEqual(steamship.Name, clonedSteamship.Name);
            Assert.AreEqual(steamship.Length, clonedSteamship.Length);
            Assert.AreEqual(steamship.Tonnage, clonedSteamship.Tonnage);
            Assert.AreEqual(steamship.EnginePower, clonedSteamship.EnginePower);
            Assert.AreEqual(steamship.PassengerCapacity, clonedSteamship.PassengerCapacity);
            CollectionAssert.AreEqual(steamship.Features, clonedSteamship.Features);
        }

        [TestMethod]
        public void Steamship_ShallowCopy_ShouldCreateShallowCopy()
        {
            // Arrange
            var steamship = new Steamship("TestSteamship", 100.0, 5000.0, 2000.0, 500);
            steamship.Features.Add("Feature1");
            steamship.Features.Add("Feature2");

            // Act
            var shallowCopy = steamship.ShallowCopy();

            // Assert
            Assert.AreNotSame(steamship, shallowCopy);
            Assert.AreEqual(steamship.Name, shallowCopy.Name);
            Assert.AreEqual(steamship.Length, shallowCopy.Length);
            Assert.AreEqual(steamship.Tonnage, shallowCopy.Tonnage);
            Assert.AreEqual(steamship.EnginePower, shallowCopy.EnginePower);
            Assert.AreEqual(steamship.PassengerCapacity, shallowCopy.PassengerCapacity);
            Assert.AreSame(steamship.Features, shallowCopy.Features);
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