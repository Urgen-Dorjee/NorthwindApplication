using Microsoft.AspNetCore.Mvc.RazorPages;
using Common.Shared;

namespace Northwind.Razor.Employees.Areas.CommonFeatures.Pages
{
    public class EmployeesModel : PageModel
    {
        private readonly NorthwindContext _dbContext;

        public Employee[] Employees { get; set; } = null!;
        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Employee";
            Employees = _dbContext.Employees.OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName).ToArray();
        }

        public EmployeesModel(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
