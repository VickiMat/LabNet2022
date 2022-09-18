using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExceptionsPractice.Models.Tests
{
    [TestClass()]
    public class ZeroDivisorTests
    {
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionTest()
        {
            //Arrange
            decimal divisorNumber = 84;
            int number0 = 0;

            //Act
            ZeroDivisor.Division(divisorNumber, number0);

            //Assert is handled by the ExpectedException
            
        }
    }
}