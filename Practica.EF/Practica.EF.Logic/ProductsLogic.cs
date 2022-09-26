using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    internal class ProductsLogic : BaseLogic, ILogic<Products>
    {
        public void Add(Products newT)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Products FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetAll()
        {
            try
            {
                return ctx.Products.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void Update(Products newT)
        {
            throw new NotImplementedException();
        }

        internal void UpdateCategoryId(Products newProd)
        {
            newProd.CategoryID = null;
            ctx.SaveChanges();        
        }
    }
}
