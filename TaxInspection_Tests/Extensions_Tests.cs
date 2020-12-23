
namespace TaxInspection_Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TaxInspection.Extensions;

    [TestClass]
    public class Extensions_Tests
    {
        [TestMethod]
        public void Test_TextContainsOnlyNumbers_12119_ReturnsTrue()
        {
            // Arrange
            string textToCheck = "12119";
            bool expectedRezult = true;

            // Act
            bool actualRezult = !Tools.TextContainsOnlyNumbers(textToCheck);

            // Assert
            Assert.AreEqual(expectedRezult, actualRezult);
        }

        [TestMethod]
        public void Test_ConvertDayTimeToSqlDate()
        {
            // Arrange
            DateTime date = new DateTime(2010, 12, 11);
            string expectedRezult = "2010-12-11";

            // Act
            string actualRezult = Tools.ConvertDayTimeToSqlDate(date);

            // Assert
            Assert.AreEqual(expectedRezult, actualRezult);
        }
    }
}
