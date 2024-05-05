using lab10lib_Shalnev;

namespace lab_10_tests
{
    [TestClass]
    public class SailboatTest
    {
        [TestMethod]
        public void Sailboat_Constructor_WithValidParameters()
        {
            // Arrange
            string name = "TestSailboat";
            double length = 50.0;
            double tonnage = 3000.0;
            double mastHeight = 15.0;
            string sailMaterial = "Canvas";

            // Act
            var sailboat = new Sailboat(name, length, tonnage, mastHeight, sailMaterial);

            // Assert
            Assert.AreEqual(name, sailboat.Name);
            Assert.AreEqual(length, sailboat.Length);
            Assert.AreEqual(tonnage, sailboat.Tonnage);
            Assert.AreEqual(mastHeight, sailboat.MastHeight);
            Assert.AreEqual(sailMaterial, sailboat.SailMaterial);
        }

        [TestMethod]
        public void Sailboat_DefaultConstructor_ShouldInitializeCorrectly()
        {
            // Act
            var sailboat = new Sailboat();

            // Assert
            Assert.IsNotNull(sailboat.Name);
            Assert.IsTrue(sailboat.Length >= 0);
            Assert.IsTrue(sailboat.Tonnage >= 0);
            Assert.IsTrue(sailboat.MastHeight >= 0);
            Assert.IsNotNull(sailboat.SailMaterial);
        }

        [TestMethod]
        public void Sailboat_GetString_ShouldReturnFormattedString()
        {
            // Arrange
            var sailboat = new Sailboat("TestSailboat", 50.0, 3000.0, 15.0, "Canvas");

            // Act
            string result = sailboat.GetString();

            // Assert
            Assert.IsTrue(result.Contains("Название корабля: TestSailboat"));
            Assert.IsTrue(result.Contains("Длина: 50"));
            Assert.IsTrue(result.Contains("Водоизмещение: 3000"));
            Assert.IsTrue(result.Contains("Высота мачты: 15"));
            Assert.IsTrue(result.Contains("Материал паруса: Canvas"));
        }

        [TestMethod]
        public void Sailboat_Show_ShouldCallConsoleWriteLine()
        {
            // Arrange
            var sailboat = new Sailboat("TestSailboat", 50.0, 3000.0, 15.0, "Canvas");

            // Act
            using (ConsoleOutputInterceptor consoleInterceptor = new ConsoleOutputInterceptor())
            {
                sailboat.Show();

                // Assert
                Assert.IsTrue(consoleInterceptor.Output.Contains("Название корабля: TestSailboat"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Длина: 50"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Водоизмещение: 3000"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Высота мачты: 15"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Материал паруса: Canvas"));
            }
        }

        [TestMethod]
        public void Sailboat_SelfShow_ShouldCallConsoleWriteLine()
        {
            // Arrange
            var sailboat = new Sailboat("TestSailboat", 50.0, 3000.0, 15.0, "Canvas");

            // Act
            using (ConsoleOutputInterceptor consoleInterceptor = new ConsoleOutputInterceptor())
            {
                sailboat.SelfShow();

                // Assert
                Assert.IsTrue(consoleInterceptor.Output.Contains("Название корабля: TestSailboat"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Длина: 50"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Водоизмещение: 3000"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Высота мачты: 15"));
                Assert.IsTrue(consoleInterceptor.Output.Contains("Материал паруса: Canvas"));
            }
        }

        [TestMethod]
        public void Init_ShouldInitializeSailboatpProperties()
        {
            // Arrange
            var sailboat = new Sailboat();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                string input = "ShipName\n25,5\n150,5\n20,2\nNeylon\n";
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);

                    // Act
                    sailboat.Init();
                }

                // Assert
                Assert.AreEqual("ShipName", sailboat.Name);
                Assert.AreEqual(25.5, sailboat.Length);
                Assert.AreEqual(150.5, sailboat.Tonnage);
                Assert.AreEqual(20.2, sailboat.MastHeight);
                Assert.AreEqual("Neylon", sailboat.SailMaterial);

                Assert.IsTrue(sw.ToString().Contains("Введите название корабля: "));
                Assert.IsTrue(sw.ToString().Contains("Введите длину корабля: "));
                Assert.IsTrue(sw.ToString().Contains("Введите водоизмещение корабля: "));

                Assert.IsTrue(sw.ToString().Contains("Введите высоту мачты: "));
                Assert.IsTrue(sw.ToString().Contains("Введите материал паруса: "));
            }
        }

        [TestMethod]
        public void Sailboat_RandomInit_ShouldInitializeProperties()
        {
            // Arrange
            var sailboat = new Sailboat();

            // Act
            sailboat.RandomInit();

            // Assert
            Assert.IsNotNull(sailboat.Name);
            Assert.IsTrue(sailboat.Length >= 0);
            Assert.IsTrue(sailboat.Tonnage >= 0);
            Assert.IsTrue(sailboat.MastHeight >= 0);
            Assert.IsNotNull(sailboat.SailMaterial);
        }

        [TestMethod]
        public void Sailboat_Clone_ShouldCreateDeepCopy()
        {
            // Arrange
            var sailboat = new Sailboat("TestSailboat", 50.0, 3000.0, 15.0, "Canvas");
            sailboat.Features.Add("Feature1");
            sailboat.Features.Add("Feature2");

            // Act
            var clonedSailboat = (Sailboat)sailboat.Clone();

            // Assert
            Assert.AreNotSame(sailboat, clonedSailboat);
            Assert.AreEqual(sailboat.Name, clonedSailboat.Name);
            Assert.AreEqual(sailboat.Length, clonedSailboat.Length);
            Assert.AreEqual(sailboat.Tonnage, clonedSailboat.Tonnage);
            Assert.AreEqual(sailboat.MastHeight, clonedSailboat.MastHeight);
            Assert.AreEqual(sailboat.SailMaterial, clonedSailboat.SailMaterial);
            CollectionAssert.AreEqual(sailboat.Features, clonedSailboat.Features);
        }

        [TestMethod]
        public void Sailboat_ShallowCopy_ShouldCreateShallowCopy()
        {
            // Arrange
            var sailboat = new Sailboat("TestSailboat", 50.0, 3000.0, 15.0, "Canvas");
            sailboat.Features.Add("Feature1");
            sailboat.Features.Add("Feature2");

            // Act
            var shallowCopy = sailboat.ShallowCopy();

            // Assert
            Assert.AreNotSame(sailboat, shallowCopy);
            Assert.AreEqual(sailboat.Name, shallowCopy.Name);
            Assert.AreEqual(sailboat.Length, shallowCopy.Length);
            Assert.AreEqual(sailboat.Tonnage, shallowCopy.Tonnage);
            Assert.AreEqual(sailboat.MastHeight, shallowCopy.MastHeight);
            Assert.AreEqual(sailboat.SailMaterial, shallowCopy.SailMaterial);
            Assert.AreSame(sailboat.Features, shallowCopy.Features);
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