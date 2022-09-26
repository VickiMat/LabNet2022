using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    internal class ProductsLogic : BaseLogic<Products>
    {
        public override void Add(Products newT)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Products FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Products> GetAll()
        {
            try
            {
                return _ctx.Products.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public  override void Update(Products newT)
        {
            throw new NotImplementedException();
        }

        internal void UpdateCategoryId(Products newProd)
        {
            newProd.CategoryID = null;
            _ctx.SaveChanges();        
        }
    }
}
