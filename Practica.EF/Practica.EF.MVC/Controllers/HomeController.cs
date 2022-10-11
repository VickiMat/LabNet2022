using System.Web.Mvc;

namespace Practica.EF.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return RedirectToAction("Index","Categories");
        }

        public ActionResult Suppliers()
        {
            return RedirectToAction("Index", "Suppliers");
        }

        public ActionResult Houses()
        {
            return RedirectToAction("Houses", "WizardWorld");
        }


    }
}