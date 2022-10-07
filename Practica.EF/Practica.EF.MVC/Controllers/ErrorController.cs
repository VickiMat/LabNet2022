using System.Web.Mvc;

namespace Practica.EF.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BackHome()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}