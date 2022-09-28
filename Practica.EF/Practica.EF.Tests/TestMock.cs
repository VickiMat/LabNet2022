using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Practica.EF.Data;
using Practica.EF.Entities;
using Practica.EF.Logic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Practica.EF.Tests
{
    [TestClass]
    public class TestMock
    {
        [TestMethod]

        public void Add_from_logic_calls_Add_and_SaveChanges_from_Context()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Categories>>();

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            CategoriesLogic categoriesLogic = new CategoriesLogic(mockContext.Object);

            //Act
            categoriesLogic.Add(new Categories
            {
                CategoryID = 000,
                CategoryName = "TestConMock",
                Description = "Description Test con Mock"
            });

            //Assert
            mockSet.Verify(m => m.Add(It.IsAny<Categories>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void GetAll_returns_more_than_one_element()
        {
            //Arrange
            var data = new List<Categories>
            {
                new Categories { CategoryName = "First Categ" },
                new Categories { CategoryName = "Second Categ" },
                new Categories { CategoryName = "Third Categ" },
                new Categories { CategoryName = "Fourth Categ" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Categories>>();
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            //Act
            var service = new CategoriesLogic(mockContext.Object);
            var listCateg = service.GetAll();

            //Assert
            Assert.AreEqual(4, listCateg.Count);
            Assert.AreEqual("First Categ", listCateg[0].CategoryName);
            Assert.AreEqual("Second Categ", listCateg[1].CategoryName);
            Assert.AreEqual("Third Categ", listCateg[2].CategoryName);
            Assert.AreEqual("Fourth Categ", listCateg[3].CategoryName);
        }


        [TestMethod]
        public void Update_from_logic_and_SaveChanges_from_context()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Categories>>();

            var mockContext = new Mock<NorthwindContext>();

            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(new Categories { CategoryID = 2, CategoryName = "Test", Description = "descrip test" });

            ILogic<Categories> categoriesLogic = new CategoriesLogic(mockContext.Object);

            var categLogic = new CategoriesLogic(mockContext.Object);
            

            // Act 
            categLogic.Update(new Categories { CategoryID = 2, CategoryName = "update" });

            // Verify
            //mockSet.Verify(c => c.Add(It.IsAny<Categories>()), Times.Once());
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }
    }

}
