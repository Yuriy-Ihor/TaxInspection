
namespace TaxInspection_UnitTestss
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TaxInspection.Extensions;

    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void Test_TextContainsOnlyNumbers_AAAAA99_ReturnFalse()
        {
            // Arrange
            string textToCheck = "AAAAA99";
            bool expectedRezult = false;

            // Act
            bool actualRezult = Tools.TextContainsOnlyNumbers(textToCheck);

            //Assert
            Assert.AreEqual(expectedRezult, actualRezult);
        }

        public void Test_GetDateTimeFromSql()
        {
            // Arrange

            // Act

            // Assert

        }

        public void Test_ConvertDayTimeToSqlDate()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}
