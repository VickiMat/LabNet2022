using Common.ValidationAPI;
using FluentValidation;
using Practica.EF.Entities;
using Practica.EF.Logic;
using System;
using System.Collections.Generic;

namespace Practica.EF.Service
{
    public class CategoriesService : ICategoriesService
    {
        private CategoriesLogic _categoriesLogic;

        public CategoriesLogic CategoriesLogic
        {
            get 
            {
                if(_categoriesLogic == null)
                {
                    _categoriesLogic = new CategoriesLogic();
                }
                return _categoriesLogic; 
            }
            set
            {
                _categoriesLogic = value;
            }
        }


        public void AddCategory(Categories category)
        {
            try
            {
                ValidationCategory(category);
                CategoriesLogic.Add(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                CategoriesLogic.Delete(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<Categories> GetCategories()
        {
            try
            {
                return CategoriesLogic.GetAll();
            }
            catch(Exception)
            {
                throw new Exception("An error has occurred while trying to get the categories.");
            }
        }

        public Categories GetCategoryById(int id)
        {
            try
            {
                return CategoriesLogic.FindById(id);
            }
            catch (Exception)
            {
                throw new Exception($"An error has occurred while trying to get the category with id {id}.");
            }
        }

        public void UpdateCategory(Categories category)
        {
            try
            {
                ValidationCategory(category);
                CategoriesLogic.Update(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void ValidationCategory(Categories category)
        {
            var validation = new ValidationCategories();
            validation.ValidateAndThrow(category);
        }
    }
}
