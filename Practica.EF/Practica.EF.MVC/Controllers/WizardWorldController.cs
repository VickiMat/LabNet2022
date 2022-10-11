using Practica.EF.Logic.WizardWorld;
using Practica.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Practica.EF.MVC.Controllers
{
    public class WizardWorldController : Controller
    {
        private HousesLogic _housesLogic;
        public HousesLogic HousesLogic
        {
            get
            {
                if (_housesLogic == null)
                {
                    _housesLogic = new HousesLogic();
                }
                return _housesLogic;
            }
        }

        // GET: WizardWorld

        public async Task<ActionResult> Houses()
        {
            try
            {
                var houses = await HousesLogic.GetAllHousesDto();
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
    }
}