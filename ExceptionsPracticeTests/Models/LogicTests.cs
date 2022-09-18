using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ExceptionsPractice.Exceptions;

namespace ExceptionsPractice.Models.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FirstMethodTest()
        {
            //Arrange

            //Act
            Logic.FirstMethod();

            //Assert is handled by the ExpectedException

        }

        [TestMethod()]
        [ExpectedException(typeof(CustomMessageException))]
        public void ThrowMyExceptionTest()
        {
            //Arrange

            //Act
            Logic.ThrowMyException();

            //Assert is handled by the ExpectedException

        }


    }
}