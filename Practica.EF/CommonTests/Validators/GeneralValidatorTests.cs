using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Validators.Tests
{
    [TestClass()]
    public class GeneralValidatorTests
    {
        [TestMethod()]
        public void ValidateNumberMenuTest_Success()
        {
            //Arrange
            string enterNumber = "2";
            int expectedResult = 2;

            //Act
            var result= GeneralValidator.ValidateNumberMenu(enterNumber);

            //Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod()]
        public void ValidateNumberMenuTest_Fail()
        {
            //Arrange
            string enterNumber = "-2";
            int expectedResult = 2;

            //Act
            var result = GeneralValidator.ValidateNumberMenu(enterNumber);

            //Assert
            Assert.AreEqual(result, expectedResult);
        }
    }

}