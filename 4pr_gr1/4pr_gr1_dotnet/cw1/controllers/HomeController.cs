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

    }
}
