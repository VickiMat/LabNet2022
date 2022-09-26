using Practica.EF.Entities;
using Practica.EF.Logic.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica.EF.Logic
{
    public class CategoriesLogic : BaseLogic, ILogic<Categories>
    {
        public List<Categories> GetAll()
        {
            try
            {
                return ctx.Categories.ToList();
            }
            catch(Exception)
            {
                throw new Exception();
            }  
        }

        public void Add(Categories newCat)
        {
            try
            {
                ctx.Categories.Add(newCat);

                ctx.SaveChanges();
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }



        public void Update(Categories categ)
        {
            try
            {
                var categForUpdate = FindById(categ.CategoryID);

                categForUpdate.CategoryName = categ.CategoryName;
                categForUpdate.Description = categ.Description;

                ctx.SaveChanges();
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

        public Categories FindById(int id)
        {
            try
            {
                var categById = ctx.Categories.Find(id);
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

        public void Delete(int id)
        {
            try
            {
                var categForDelete = FindById(id);

                CategoryWithProducts(id);

                ctx.Categories.Remove(categForDelete);

                ctx.SaveChanges();
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
