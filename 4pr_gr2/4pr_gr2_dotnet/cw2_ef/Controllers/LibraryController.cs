using cw2_ef.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw2_ef.Controllers
{
    public class LibraryController : Controller
    {
        private readonly AppDbContext _context;
        public LibraryController(AppDbContext context)
        {
            _context = context;
        }
        // GET: LibraryController
        public ActionResult List()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                // _context.Movies.Remove(movie);
                // _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(movie);
        }


    }
}
