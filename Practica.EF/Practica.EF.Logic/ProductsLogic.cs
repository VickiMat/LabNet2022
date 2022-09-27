using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //This method change the FK CategoryID to null. Allowing delete the asociate category.
        internal void UpdateCategoryId(Products newProd)
        {
            try
            {
                newProd.CategoryID = null;
                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }       
        }
        //This method change the FK SupplierID to null. Allowing delete the asociate supplier.
        internal void UpdateSupplierId(Products newProd)
        {
            try
            {
                newProd.SupplierID = null;
                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
