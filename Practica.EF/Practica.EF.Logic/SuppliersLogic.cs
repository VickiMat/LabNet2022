using Common.Exceptions;
using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica.EF.Logic
{
    public class SuppliersLogic : BaseLogic<Suppliers>, ISuppliersLogic<Suppliers>
    {
        public override void Add(Suppliers newSup)
        {
            try
            {
                _ctx.Suppliers.Add(newSup);

                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var suppForDelete = FindById(id);

                SupplierWithProducts(id);

                _ctx.Suppliers.Remove(suppForDelete);

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

        //This method evaluates if there is any product that depends on any supplier.
        //If it finds it, it calls a method to solve the foreign key restriction.
        internal void SupplierWithProducts(int id)
        {
            ProductsLogic products = new ProductsLogic();

            foreach (Products item in products.GetAll())
            {
                if (item.SupplierID == id)
                {
                    products.UpdateSupplierId(item);
                }
            }
        }

        public override Suppliers FindById(int id)
        {
            try
            {
                var suppById = _ctx.Suppliers.Find(id);
                if(suppById == null)
                {
                    throw new NotFoundIDException(id);
                }
                else
                {
                    return suppById;
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

        public override List<Suppliers> GetAll()
        {
            try
            {
                return _ctx.Suppliers.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(Suppliers supp)
        {
            try
            {
                var suppForUpdate = FindById(supp.SupplierID);

                suppForUpdate.CompanyName = supp.CompanyName;
                suppForUpdate.ContactName = supp.ContactName;
                suppForUpdate.City = supp.City;
                suppForUpdate.Country = supp.Country;

                _ctx.SaveChanges();
            }
            catch (NotFoundIDException)
            {
                throw new NotFoundIDException(supp.SupplierID);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<Suppliers> FindSuppliersByCity(string cityName)
        {
            try
            {
                List<Suppliers> listSupByCity = new List<Suppliers>();

                foreach (var supplier in GetAll())
                {
                    if (supplier.City.ToLower() == cityName.ToLower())
                    {
                        listSupByCity.Add(supplier);
                    }
                }
                return listSupByCity;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
