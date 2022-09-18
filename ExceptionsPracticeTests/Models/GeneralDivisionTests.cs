using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExceptionsPractice.Models.Tests
{
    [TestClass()]
    public class GeneralDivisionTests
    {
        [TestMethod()]
        public void DivisionTest()
        {
            //Arrange 

            var number1 = 4;
            var number2 = 2;
            var resultExpected = 2;

            //Act 

            var result = GeneralDivision.Division(number1, number2);

            //Assert

            Assert.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionTest_DivisorZero_Exception()
        {
            //Arrange
            decimal divisorNumber = 54;
            int number0 = 0;

            //Act
            GeneralDivision.Division(divisorNumber, number0);

            //Assert is handled by the ExpectedException
        }
    }
}