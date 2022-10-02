using Common.Exceptions;
using Practica.EF.Data;
using Practica.EF.Entities;
using Practica.EF.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica.EF.Logic
{
    public class CategoriesLogic : BaseLogic<Categories>
    {
        public CategoriesLogic() { }

        public CategoriesLogic(NorthwindContext ctx)
        {
            _ctx = ctx;
        }

        //Query 11 - Exercise 11
        public IQueryable<CategoriesProductsDto> CategoriesAssociateProducts()
        {
            var categories = _ctx.Categories;
            var products = _ctx.Products;

            return from c in categories
                   join p in products
                   on c.CategoryID equals p.CategoryID
                   group c by new
                   {
                       CategoryID = c.CategoryID,
                       CategoryName = c.CategoryName
                   }
                   into cp
                   select new CategoriesProductsDto
                   {
                       CategoryID = cp.Key.CategoryID,
                       CategoryName = cp.Key.CategoryName
                   };
        }

        public override List<Categories> GetAll()
        {
            try
            {
                return _ctx.Categories.ToList();
            }
            catch(Exception)
            {
                throw new Exception();
            }  
        }

        public override void Add(Categories newCat)
        {
            try
            {
                _ctx.Categories.Add(newCat);

                _ctx.SaveChanges();
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        public override void Update(Categories categ)
        {
            try
            {
                var categForUpdate = FindById(categ.CategoryID);

                categForUpdate.CategoryName = categ.CategoryName;
                categForUpdate.Description = categ.Description;

                _ctx.SaveChanges();
            }
            catch (NotFoundIDException)
            {
                throw new NotFoundIDException(categ.CategoryID);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public override Categories FindById(int id)
        {
            try
            {
                var categById = _ctx.Categories.Find(id);
                if (categById == null) { throw new NotFoundIDException(id); }
                else
                {
                    return categById;
                }
            }
            catch (NotFoundIDException)
            {
                throw new NotFoundIDException(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var categForDelete = FindById(id);

                CategoryWithProducts(id);

                _ctx.Categories.Remove(categForDelete);

                _ctx.SaveChanges();
            }
            catch (NotFoundIDException)
            {
                throw new NotFoundIDException(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        //This method evaluates if there is any product that depends on any category.
        //If it finds it, it calls a method to solve the foreign key restriction.
        internal void CategoryWithProducts(int id)
        {
            ProductsLogic products = new ProductsLogic();

            foreach(Products item in products.GetAll())
            {
                if(item.CategoryID == id)
                {
                    products.UpdateCategoryId(item);
                }
            }
        }
    }






}
