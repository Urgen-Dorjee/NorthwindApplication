using Common.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Northwind.Web.Pages
{
    public class SuppliersModel : PageModel
    {
        private readonly NorthwindContext _dbContext;
        public IEnumerable<Supplier>? Suppliers { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Suppliers";
            Suppliers = _dbContext.Suppliers.OrderBy(c => c.Country)
                .ThenBy(c => c.CompanyName);
        }

        public SuppliersModel(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty] 
        public Supplier? Supplier { get; set; }

        public IActionResult OnPost()
        {
            if (Supplier is not null && ModelState.IsValid)
            {
                _dbContext.Suppliers.Add(Supplier);
                _dbContext.SaveChanges();
                return RedirectToPage("/Suppliers");
            }
            else
            {
                return Page();
            }
        }
    }
}
