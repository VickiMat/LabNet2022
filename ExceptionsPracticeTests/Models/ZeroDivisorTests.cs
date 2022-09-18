using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionsPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            decimal divisorNumber = 54;
            int number0 = 0;

            //Act
            ZeroDivisor.Division(divisorNumber, number0);

            //Assert is handled by the ExpectedException
            
        }
    }
}