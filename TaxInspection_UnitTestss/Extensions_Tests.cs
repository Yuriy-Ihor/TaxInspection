
namespace TaxInspection_UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TaxInspection.Extensions;

    [TestClass]
    public class Extensions_Tests
    {
        [TestMethod]
        public void Test_TextContainsOnlyNumbers_AAAA9_ReturnsFalse()
        {
            // Arrange
            string textToCheck = "AAAA9";
            bool expectedRezult = false;

            // Act
            bool actualRezult = Tools.TextContainsOnlyNumbers(textToCheck);

            // Assert
            Assert.AreEqual(expectedRezult, actualRezult);
        }

        [TestMethod]
        public void ConvertDayTimeToSqlDate()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public void GetDateTimeFromSql()
        {

        }
    }
}
