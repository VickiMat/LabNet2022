using Practica.EF.Entities;
using Practica.EF.Logic;
using Practica.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica.EF.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesLogic categLogic = new CategoriesLogic();

        // GET: Categories
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

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoriesView categoriesView)
        {
            try
            {
                Categories category = new Categories { CategoryName = categoriesView.Name, Description = categoriesView.Description };

                categLogic.Add(category);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}