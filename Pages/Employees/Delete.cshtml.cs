using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CollegeWebsite.Data;
using CollegeWebsite.Models;

namespace CollegeWebsite.Pages_Employees
{
    public class DeleteModel : PageModel
    {
        private readonly CollegeWebsite.Data.AppDbContext _context;

        public DeleteModel(CollegeWebsite.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeeModel EmployeeModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EmployeeModel == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.EmployeeModel.FirstOrDefaultAsync(m => m.Id == id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            else
            {
                EmployeeModel = employeeModel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EmployeeModel == null)
            {
                return NotFound();
            }
            var employeemodel = await _context.EmployeeModel.FindAsync(id);

            if (employeemodel != null)
            {
                EmployeeModel = employeemodel;
                _context.EmployeeModel.Remove(EmployeeModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
