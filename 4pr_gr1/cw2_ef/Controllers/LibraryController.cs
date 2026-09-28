using cw2_ef.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw2_ef.Controllers
{
    public class LibraryController : Controller
    {
        private readonly BooksDbContext _context;
        
        public LibraryController(BooksDbContext context)
        {
            _context = context;
        }

        // GET: LibraryController
        public ActionResult List()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

    }
}
