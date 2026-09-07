using Microsoft.AspNetCore.Mvc;

namespace cw1.controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Rental()
        {
            return View();
        }   

    }
}
