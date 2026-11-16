using cw8_form1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw8_form1.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            // if (Request.Query != null)
            // {
            //     int n = Convert.ToInt32(Request.Query["N"]);

            // }
        }
        public void OnPost()
        {
            if (Request.Form.Count>0)
            {
                int n = Convert.ToInt32(Request.Form["N"]); 
                ViewData["result"] = Factorial.Run(n); 
            }           
        }
    }
}
