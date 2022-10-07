using Practica.EF.Entities;
using Practica.EF.Logic;
using Practica.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica.EF.MVC.Controllers
{
    public class SuppliersController : Controller
    {
        SuppliersLogic supLogic = new SuppliersLogic();

        public ActionResult Index(string search)
        {
            if(search == null)
            {
                List<Suppliers> supplier = supLogic.GetAll();
                List<SuppliersView> supview = supplier.Select(s => new SuppliersView
                {
                    Id = s.SupplierID,
                    CompanyName = s.CompanyName,
                    ContactName = s.ContactName,
                    City = s.City,
                    Country = s.Country
                }).ToList();

                return View(supview);
            }
            else
            {
                var supplier = supLogic.FindSuppliersByCity(search);

                List<SuppliersView> supview = supplier.Select(s => new SuppliersView
                {
                    Id = s.SupplierID,
                    CompanyName = s.CompanyName,
                    ContactName = s.ContactName,
                    City = s.City,
                    Country = s.Country
                }).ToList();

                return View(supview);
            }   
        }
       
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(SuppliersView sup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Suppliers supplier = new Suppliers 
                    { 
                        CompanyName = sup.CompanyName,
                        ContactName = sup.ContactName,
                        City= sup.City,
                        Country= sup.Country    
                    };

                    supLogic.Add(supplier);
                }
                string message = "The supplier was inserted succesfully";
                ViewBag.Message = message;
                return View();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                supLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
        

        public ActionResult Update(int id)
        {
            var data = supLogic.FindById(id);

            SuppliersView sup = new SuppliersView();
            if(data != null)
            {
                sup.Id = data.SupplierID;
                sup.CompanyName = data.CompanyName;
                sup.ContactName = data.ContactName;
                sup.City = data.City;
                sup.Country = data.Country;
            }

            return View(sup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, SuppliersView sup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = supLogic.FindById(id);

                    if (data != null)
                    {
                        Suppliers supplier = new Suppliers
                        {
                            SupplierID = sup.Id,
                            CompanyName = sup.CompanyName,
                            ContactName = sup.ContactName,
                            City = sup.City,
                            Country = sup.Country
                        };

                        supLogic.Update(supplier);
                        return RedirectToAction("Index");
                    }
                    else return View();
                }
                else return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
