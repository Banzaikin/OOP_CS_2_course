using lab10lib_Shalnev;

namespace lab_10_tests
{
    [TestClass]
    public class NonHierarchicalClass
    {
        [TestClass]
        public class NonHierarchicalClassTests
        {
            [TestMethod]
            public void NonHierarchicalClass_Init_ShouldSetId()
            {
                // Arrange
                var nonHierarchicalClass = new lab10lib_Shalnev.NonHierarchicalClass();

                // Act
                nonHierarchicalClass.Init();

                // Assert
                Assert.IsNotNull(nonHierarchicalClass.Id);
            }

            [TestMethod]
            public void NonHierarchicalClass_RandomInit_ShouldSetRandomId()
            {
                // Arrange
                var nonHierarchicalClass = new lab10lib_Shalnev.NonHierarchicalClass();

                // Act
                nonHierarchicalClass.RandomInit();

                // Assert
                Assert.IsNotNull(nonHierarchicalClass.Id);
                Assert.IsTrue(nonHierarchicalClass.Id.StartsWith("Random_"));
            }

            // Add more tests to cover other scenarios

            [TestMethod]
            public void NonHierarchicalClass_Init_ShouldSetUniqueId()
            {
                // Arrange
                var nonHierarchicalClass1 = new lab10lib_Shalnev.NonHierarchicalClass();
                var nonHierarchicalClass2 = new lab10lib_Shalnev.NonHierarchicalClass();

                // Act
                nonHierarchicalClass1.Init();
                nonHierarchicalClass2.Init();

                // Assert
                Assert.IsNotNull(nonHierarchicalClass1.Id);
                Assert.IsNotNull(nonHierarchicalClass2.Id);
                Assert.AreNotEqual(nonHierarchicalClass1.Id, nonHierarchicalClass2.Id);
            }
        }
    }
}