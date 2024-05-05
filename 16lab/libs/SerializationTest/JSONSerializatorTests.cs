
using Lab16.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SerializationTest
{
    [TestClass]
    public class JSONSerializatorTests
    {
        private JSONSerializator<int> _serializer;
        private readonly string _testFilePath = "testFile.json";

        [TestInitialize]
        public void Setup()
        {
            _serializer = new JSONSerializator<int>();
        }

        [TestMethod]
        public void SaveAndLoad_Int_Success()
        {
            // Arrange
            int numberToSave = 42;

            // Act
            _serializer.Save(numberToSave, _testFilePath);
            int loadedNumber = _serializer.Load(_testFilePath);

            // Assert
            Assert.AreEqual(numberToSave, loadedNumber);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean up the test file after each test
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }
    }
}