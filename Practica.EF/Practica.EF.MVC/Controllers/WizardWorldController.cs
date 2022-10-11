using Practica.EF.MVC.Models;
using Practica.EF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Practica.EF.MVC.Controllers
{
    public class WizardWorldController : Controller
    {
        private HousesService _housesService;
        public HousesService HousesService
        {
            get
            {
                if (_housesService == null)
                {
                    _housesService = new HousesService();
                }
                return _housesService;
            }
        }

        // GET: WizardWorld
        public async Task<ActionResult> Houses()
        {
            try
            {
                var houses = await HousesService.ListHouses();
                List<WizardWorldView> listView = houses.Select(h => new WizardWorldView
                {
                    Id = h.id,
                    Name = h.name,
                    HouseColours = h.houseColours,
                    Founder = h.founder,
                    Animal = h.animal,
                    Element = h.element
                }).ToList();

                return View(listView);

            }
            catch (Exception ex)
            {
                ViewBag.Message(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Home()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}