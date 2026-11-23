using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw10_form1.Pages
{
    public class InsertModel : PageModel
    {
        public List<string> Divisions { get; set; }
        public InsertModel()
        {
            Divisions = new()
            {
                "1A","1B","1C","1PR","1L"
            };
        }
        public void OnGet()
        {
            
        }
        public void OnPost()
        {           
           ViewData["firstname"] = Request.Form["Firstname"];
           ViewData["lastname"] = Request.Form["Lastname"];
           ViewData["division"] = Request.Form["Division"];
        }
    }
}
