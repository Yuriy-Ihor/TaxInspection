
namespace TaxInspection_Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TaxInspection;

    [TestClass]
    public class MainWindow_Test
    {
        [TestMethod]
        public void MainWindow_TestHeight()
        {
            // Arrange
            int expectedHeight = 450;

            // Act
            MainWindow window = new MainWindow();
            
            // Assert
            Assert.AreEqual(expectedHeight, window.Height);
        }
    }
}
