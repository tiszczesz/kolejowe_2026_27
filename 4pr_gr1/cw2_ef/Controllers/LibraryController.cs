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
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            _context.Books.Add(book);
            //_context.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);

            _context.SaveChanges();

            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id); // Pobranie książki z bazy danych na podstawie id do edycji

            if (book == null)
            {
                return NotFound();
            }
            //wysłanie książki do widoku Edit.cshtml
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(book);
            }
            // Aktualizacja książki w bazie danych
            _context.Books.Update(book);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

    }
}
