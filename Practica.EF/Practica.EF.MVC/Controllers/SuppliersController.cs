using Common.Exceptions;
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

        // GET: Suppliers
        public ActionResult Index()
        {
            List<Suppliers> sup = supLogic.GetAll();

            List<SuppliersView> supView = sup.Select(s => new SuppliersView
            {
                Id = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                City = s.City,
                Country = s.Country
            }).ToList();

            return View(supView);
        }


        //POST: Suppliers

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






        //public ActionResult Update(int id, SuppliersView suppliersView)
        //{
        //    try
        //    {
        //        var sup = supLogic.FindById(id);

        //        if (sup != null)
        //        {
        //            Suppliers supplier = new Suppliers
        //            {
        //                SupplierID = suppliersView.Id,
        //                CompanyName = suppliersView.CompanyName,
        //                ContactName = suppliersView.ContactName,
        //                City = suppliersView.City,
        //                Country = suppliersView.Country
        //            };
        //            supLogic.Update(supplier);
        //            return RedirectToAction("Index");
        //        }
        //        else throw new NotFoundIDException(id);
        //    }
        //    catch(Exception ex)
        //    {
        //        return RedirectToAction("Index", "Error");
        //    }
        //}

    }


}
