using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica.EF.Logic
{
    public class ProductsLogic : BaseLogic<Products>
    {

        public IQueryable<Products> ProductsWithoutStock()
        {
            var products = _ctx.Products;

            var query2 = products.Where(p => p.UnitsInStock == 0);
                              
            return query2;
        }

        public IQueryable<Products> ProductsWithStockAndPriceOver3()
        {
            var products = _ctx.Products;

            var query3 = from product in products
                         where product.UnitsInStock != 0 &&
                               product.UnitPrice > 3
                         select product;

            return query3;
        }

        public Products ProductWithID_789_OrNull()
        {
            var products = _ctx.Products;

            var query5 = from product in products
                         where product.ProductID == 789
                         select product;
            if (query5 == null)
            {
                return null;
            }
            else return query5.First();
        }

        public IEnumerable<Products> ProductsOrderBy_Name()
        {
            var products = _ctx.Products;

            var query9 = from product in products
                         orderby product.ProductName
                         select product;

            return query9;
        }

        public IEnumerable<Products> ProductsOrderBy_UnitsInStock()
        {
            var products = _ctx.Products;

            var query10 = products.OrderByDescending(p => p.UnitsInStock);
            
            return query10;
        }

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
