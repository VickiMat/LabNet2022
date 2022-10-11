using Practica.EF.Entities;
using Practica.EF.Logic;
using Common.ValidationAPI;
using FluentValidation;
using System;
using System.Collections.Generic;
using Common.Exceptions;

namespace Practica.EF.Service
{
    public class SuppliersService : ISuppliersService
    {
        private SuppliersLogic _supLogic;

        public SuppliersLogic SupLogic
        {
            get
            {
                if (_supLogic == null)
                {
                    _supLogic = new SuppliersLogic();
                }
                return _supLogic;
            }
        }

        public void AddSupplier(Suppliers supplier)
        {
            try
            {
                ValidationSuppliers(supplier);
                SupLogic.Add(supplier);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSupplier(int id)
        {
            try
            {
                if (id == 0) { throw new NotFoundIDException(id); }
                SupLogic.Delete(id);
            }
            catch(NotFoundIDException nex)
            {
                throw nex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Suppliers> GetSuppliers()
        {
            try
            {
                return SupLogic.GetAll();
            }
            catch (Exception)
            {
                throw new Exception("An error has occurred while trying to get the suppliers.");
            }
        }

        public List<Suppliers> GetSuppliersByCity(string city)
        {
            try
            {
                if(city != null)
                {
                    return SupLogic.FindSuppliersByCity(city);
                }
                throw new Exception("The city entered doesn´t exist.");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Suppliers GetSuppliersById(int id)
        {
            try
            {
                return SupLogic.FindById(id);
            }
            catch (Exception)
            {
                throw new Exception($"An error has occurred while trying to get the supplier with id {id}.");
            }
        }

        public void UpdateSupplier(Suppliers supplier)
        {
            try
            {
                ValidationSuppliers(supplier);
                SupLogic.Update(supplier);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void ValidationSuppliers(Suppliers supplier)
        {
            var validation = new ValidationSuppliers();
            validation.ValidateAndThrow(supplier);
        }
    }
}
