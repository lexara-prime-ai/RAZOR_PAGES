using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CollegeWebsite.Data;
using CollegeWebsite.Models;

namespace CollegeWebsite.Pages_Students
{
    public class DetailsModel : PageModel
    {
        private readonly CollegeWebsite.Data.AppDbContext _context;

        public DetailsModel(CollegeWebsite.Data.AppDbContext context)
        {
            _context = context;
        }

        public StudentModel StudentModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudentModel == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel.FirstOrDefaultAsync(m => m.Id == id);
            if (studentModel == null)
            {
                return NotFound();
            }
            else
            {
                StudentModel = studentModel;
            }
            return Page();
        }
    }
}
