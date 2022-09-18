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
    }
}