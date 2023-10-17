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
    public class IndexModel : PageModel
    {
        private readonly CollegeWebsite.Data.AppDbContext _context;

        public IndexModel(CollegeWebsite.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<StudentModel> StudentModel { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.StudentModel != null)
            {
                StudentModel = await _context.StudentModel.ToListAsync();
            }
        }
    }
}
