using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw9_form_layout.Pages
{
    public class Form1Model : PageModel
    {
        public List<string> Genres { get; set; } = new()
        {
            "obyczajowy","komedia","wojenny","sensacyjny","scifi","dramat"
        };
        public void OnGet()
        {
        }
    }
}
