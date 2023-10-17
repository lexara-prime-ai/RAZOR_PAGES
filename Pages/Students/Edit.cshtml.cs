using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeWebsite.Data;
using CollegeWebsite.Models;

namespace CollegeWebsite.Pages_Students
{
    public class EditModel : PageModel
    {
        private readonly CollegeWebsite.Data.AppDbContext _context;

        public EditModel(CollegeWebsite.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentModel StudentModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudentModel == null)
            {
                return NotFound();
            }

            var studentmodel = await _context.StudentModel.FirstOrDefaultAsync(m => m.Id == id);
            if (studentmodel == null)
            {
                return NotFound();
            }
            StudentModel = studentmodel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(StudentModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentModelExists(int id)
        {
            return (_context.StudentModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
