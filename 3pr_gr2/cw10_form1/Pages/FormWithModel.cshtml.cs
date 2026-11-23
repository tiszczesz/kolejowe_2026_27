using cw10_form1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw10_form1.Pages
{
    public class FormWithModelModel : PageModel
    {
        public Table MyTable { get; set; } = new();
        public void OnGet()
        {
        }
          public void OnPost()
        {
        }
    }
}
