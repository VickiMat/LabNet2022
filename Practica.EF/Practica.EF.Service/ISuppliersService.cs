using Practica.EF.Entities;
using System.Collections.Generic;

namespace Practica.EF.Service
{
    public interface ISuppliersService
    {
        List<Suppliers> GetSuppliers();

        Suppliers GetSuppliersById(int id);

        List<Suppliers> GetSuppliersByCity(string city);

        void AddSupplier(Suppliers supplier);

        void UpdateSupplier(Suppliers supplier);

        void DeleteSupplier(int id);
    }
}
