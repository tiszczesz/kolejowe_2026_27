using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw9_razor.Pages
{
    
    public class IndexModel : PageModel
    {
        public List<string>? MyColors { get; set; }
        public void OnGet()
        {
            MyColors = new List<string>
            {
              "White","Green","Red","Blue","Yellow"  
            };
        }
    }
}
