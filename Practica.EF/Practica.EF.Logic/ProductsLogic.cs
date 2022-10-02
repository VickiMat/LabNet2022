using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica.EF.Logic
{
    public class ProductsLogic : BaseLogic<Products>
    {
        //Query 2 - Exercise 2
        public IQueryable<Products> ProductsWithoutStock()
        {
            var products = _ctx.Products;

            return products.Where(p => p.UnitsInStock == 0);
        }

        //Query 3 - Exercise 3
        public IQueryable<Products> ProductsWithStockAndPriceOver3()
        {
            var products = _ctx.Products;

            return from product in products
                   where product.UnitsInStock != 0 &&
                         product.UnitPrice > 3
                   orderby product.UnitPrice
                   select product;
        }

        //Query 5- Exercise 5
        public override Products FindById(int id)
        {
            var products = _ctx.Products;

            return (from product in products
                    where product.ProductID == id
                    select product).FirstOrDefault();
        }

        //Query 9 - Exercise 9
        public IEnumerable<Products> ProductsOrderBy_Name()
        {
            var products = _ctx.Products;

            return from product in products
                   orderby product.ProductName
                   select product;
        }

        //Query 10 - Exercise 10
        public IEnumerable<Products> ProductsOrderBy_UnitsInStock()
        {
            var products = _ctx.Products;

            return products.OrderByDescending(p => p.UnitsInStock);
        }

        //Query 12 - Exercise 12
        public Products GetFirstProduct()
        {
            var products = _ctx.Products;

            return products.First();    
        }

        public override void Add(Products newT)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
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
