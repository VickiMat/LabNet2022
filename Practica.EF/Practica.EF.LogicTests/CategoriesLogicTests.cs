using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica.EF.Entities;

namespace Practica.EF.Logic.Tests
{
    [TestClass()]
    public class CategoriesLogicTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            ILogic<Categories> cl = new CategoriesLogic();

            //Act
            var listCateg = cl.GetAll();

            //Assert
          
        }
    }
}