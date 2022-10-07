using Common.Exceptions;
using Practica.EF.Entities;
using Practica.EF.Logic;
using Practica.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Practica.EF.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesLogic categLogic = new CategoriesLogic();

        // GET: Suppliers
        public ActionResult Index()
        {
            List<Categories> categories = categLogic.GetAll();

            List<CategoriesView> categoriesView = categories.Select(c => new CategoriesView
            {
                Id = c.CategoryID,
                Name = c.CategoryName,
                Description = c.Description,
            }).ToList();

            return View(categoriesView);
        }

        public ActionResult InsertUpdate(int id)
        {
            if (id != 0)
            {
                var data = categLogic.FindById(id);

                CategoriesView cat = new CategoriesView();

                if (data != null)
                {
                    cat.Id = data.CategoryID;
                    cat.Name = data.CategoryName;
                    cat.Description = data.Description;
                }
                return View(cat);
            }
            else return View();
        }

        [HttpPost]
        public ActionResult InsertUpdate(CategoriesView categoriesView)
        {
            try
            { 
                if (ModelState.IsValid)
                {
                    Categories category = new Categories { CategoryID = categoriesView.Id, CategoryName = categoriesView.Name, Description = categoriesView.Description };
                    if (categoriesView.Id == 0)
                    {
                        categLogic.Add(category);
                    }
                    else
                    {
                        categLogic.Update(category);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        
        public ActionResult Delete(int id)
        {        
                categLogic.Delete(id);
                return RedirectToAction("Index");   
        }
    }
}