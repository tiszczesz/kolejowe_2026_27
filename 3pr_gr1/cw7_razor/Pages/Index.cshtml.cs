using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw7_razor.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> Colors { get; set; }
        public void OnGet()
        {
            Colors = new List<string>
            {
                "white","green","blue","red","yellow"
            };
        }
    }
}
