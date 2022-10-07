using Practica.EF.Entities;
using Practica.EF.MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Practica.EF.MVC.Common
{
    public static class SupplierMapper
    {
        public static List<SuppliersView> MapSupplier(List<Suppliers> sup)
        {
            return sup.Select(s => new SuppliersView
            {
                Id = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                City = s.City,
                Country = s.Country
            }).ToList(); 
        }

        public static List<Suppliers> MapSupplierView(List<SuppliersView> supView)
        {
            return supView.Select(s => new Suppliers
            {
                SupplierID = s.Id,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                City = s.City,
                Country = s.Country
            }).ToList();
        }
    }
}