using lab10lib_Shalnev;

namespace lab_10_tests
{
    [TestClass]
    public class CorvetteTest
    {
        [TestClass]
        public class CorvetteTests
        {
            [TestMethod]
            public void Corvette_Constructor_WithValidParameters()
            {
                // Arrange
                string name = "TestCorvette";
                double length = 80.0;
                double tonnage = 5000.0;
                int gunsCount = 20;
                string shipClass = "Frigate";

                // Act
                var corvette = new Corvette(name, length, tonnage, gunsCount, shipClass);

                // Assert
                Assert.AreEqual(name, corvette.Name);
                Assert.AreEqual(length, corvette.Length);
                Assert.AreEqual(tonnage, corvette.Tonnage);
                Assert.AreEqual(gunsCount, corvette.GunsCount);
                Assert.AreEqual(shipClass, corvette.ShipClass);
            }

            [TestMethod]
            public void Corvette_DefaultConstructor_ShouldInitializeCorrectly()
            {
                // Act
                var corvette = new Corvette();

                // Assert
                Assert.IsNotNull(corvette.Name);
                Assert.IsTrue(corvette.Length >= 0);
                Assert.IsTrue(corvette.Tonnage >= 0);
                Assert.IsTrue(corvette.GunsCount >= 0);
                Assert.IsNotNull(corvette.ShipClass);
            }

            [TestMethod]
            public void Corvette_GetString_ShouldReturnFormattedString()
            {
                // Arrange
                var corvette = new Corvette("TestCorvette", 80.0, 5000.0, 20, "Frigate");

                // Act
                string result = corvette.GetString();

                // Assert
                Assert.IsTrue(result.Contains("Название корабля: TestCorvette"));
                Assert.IsTrue(result.Contains("Длина: 80"));
                Assert.IsTrue(result.Contains("Водоизмещение: 5000"));
                Assert.IsTrue(result.Contains("Количество пушек: 20"));
                Assert.IsTrue(result.Contains("Класс корвета: Frigate"));
            }

            [TestMethod]
            public void Corvette_Show_ShouldCallConsoleWriteLine()
            {
                // Arrange
                var corvette = new Corvette("TestCorvette", 80.0, 5000.0, 20, "Frigate");

                // Act
                using (ConsoleOutputInterceptor consoleInterceptor = new ConsoleOutputInterceptor())
                {
                    corvette.Show();

                    // Assert
                    Assert.IsTrue(consoleInterceptor.Output.Contains("Название корабля: TestCorvette"));
                    Assert.IsTrue(consoleInterceptor.Output.Contains("Длина: 80"));
                    Assert.IsTrue(consoleInterceptor.Output.Contains("Водоизмещение: 5000"));
                    Assert.IsTrue(consoleInterceptor.Output.Contains("Количество пушек: 20"));
                    Assert.IsTrue(consoleInterceptor.Output.Contains("Класс корвета: Frigate"));
                }
            }

            [TestMethod]
            public void Corvette_SelfShow_ShouldCallConsoleWriteLine()
            {
                // Arrange
                var corvette = new Corvette("TestCorvette", 80.0, 5000.0, 20, "Frigate");

                // Act
                using (ConsoleOutputInterceptor consoleInterceptor = new ConsoleOutputInterceptor())
                {
                    corvette.SelfShow();

                    // Assert
                    Assert.IsTrue(consoleInterceptor.Output.Contains("Название корабля: TestCorvette"));
                    Assert.IsTrue(consoleInterceptor.Output.Contains("Длина: 80"));
                    Assert.IsTrue(consoleInterceptor.Output.Contains("Водоизмещение: 5000"));
                    Assert.IsTrue(consoleInterceptor.Output.Contains("Количество пушек: 20"));
                    Assert.IsTrue(consoleInterceptor.Output.Contains("Класс корвета: Frigate"));
                }
            }

            [TestMethod]
            public void Init_ShouldInitializeCorvetteProperties()
            {
                // Arrange
                var corvette = new Corvette();

                using (var sw = new StringWriter())
                {
                    Console.SetOut(sw);

                    string input = "ShipName\n25,5\n150,5\n20\nFregat\n";
                    using (var sr = new StringReader(input))
                    {
                        Console.SetIn(sr);

                        // Act
                        corvette.Init();
                    }

                    // Assert
                    Assert.AreEqual("ShipName", corvette.Name);
                    Assert.AreEqual(25.5, corvette.Length);
                    Assert.AreEqual(150.5, corvette.Tonnage);
                    Assert.AreEqual(20, corvette.GunsCount);
                    Assert.AreEqual("Fregat", corvette.ShipClass);

                    Assert.IsTrue(sw.ToString().Contains("Введите название корабля: "));
                    Assert.IsTrue(sw.ToString().Contains("Введите длину корабля: "));
                    Assert.IsTrue(sw.ToString().Contains("Введите водоизмещение корабля: "));

                    Assert.IsTrue(sw.ToString().Contains("Введите количество пушек: "));
                    Assert.IsTrue(sw.ToString().Contains("Введите класс корвета: "));
                }
            }

            [TestMethod]
            public void Corvette_RandomInit_ShouldInitializeProperties()
            {
                // Arrange
                var corvette = new Corvette();

                // Act
                corvette.RandomInit();

                // Assert
                Assert.IsNotNull(corvette.Name);
                Assert.IsTrue(corvette.Length >= 0);
                Assert.IsTrue(corvette.Tonnage >= 0);
                Assert.IsTrue(corvette.GunsCount >= 0);
                Assert.IsNotNull(corvette.ShipClass);
            }

            [TestMethod]
            public void Corvette_Clone_ShouldCreateDeepCopy()
            {
                // Arrange
                var corvette = new Corvette("TestCorvette", 80.0, 5000.0, 20, "Frigate");
                corvette.Features.Add("Feature1");
                corvette.Features.Add("Feature2");

                // Act
                var clonedCorvette = (Corvette)corvette.Clone();

                // Assert
                Assert.AreNotSame(corvette, clonedCorvette);
                Assert.AreEqual(corvette.Name, clonedCorvette.Name);
                Assert.AreEqual(corvette.Length, clonedCorvette.Length);
                Assert.AreEqual(corvette.Tonnage, clonedCorvette.Tonnage);
                Assert.AreEqual(corvette.GunsCount, clonedCorvette.GunsCount);
                Assert.AreEqual(corvette.ShipClass, clonedCorvette.ShipClass);
                CollectionAssert.AreEqual(corvette.Features, clonedCorvette.Features);
            }

            [TestMethod]
            public void Corvette_ShallowCopy_ShouldCreateShallowCopy()
            {
                // Arrange
                var corvette = new Corvette("TestCorvette", 80.0, 5000.0, 20, "Frigate");
                corvette.Features.Add("Feature1");
                corvette.Features.Add("Feature2");

                // Act
                var shallowCopy = corvette.ShallowCopy();

                // Assert
                Assert.AreNotSame(corvette, shallowCopy);
                Assert.AreEqual(corvette.Name, shallowCopy.Name);
                Assert.AreEqual(corvette.Length, shallowCopy.Length);
                Assert.AreEqual(corvette.Tonnage, shallowCopy.Tonnage);
                Assert.AreEqual(corvette.GunsCount, shallowCopy.GunsCount);
                Assert.AreEqual(corvette.ShipClass, shallowCopy.ShipClass);
                Assert.AreSame(corvette.Features, shallowCopy.Features);
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
}