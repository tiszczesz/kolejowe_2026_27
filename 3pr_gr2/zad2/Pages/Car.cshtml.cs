using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zad2.Pages
{
    public class CarModel : PageModel
    {
        public void OnGet()
        {
            ViewData["cars"] = new string[] { "ala", "bela", "cela" };
            ViewData["info"] = "ala ma kota";
        }
    }
}
