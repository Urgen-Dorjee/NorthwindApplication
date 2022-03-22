using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Northwind.Web.Pages
{
    public class IndexModel : PageModel
    {

        public string? DayName { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B";
            DayName = DateTime.Now.ToString("dddd");
        }
    }
}
