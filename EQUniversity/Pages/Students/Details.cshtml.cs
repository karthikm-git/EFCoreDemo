using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EQUniversity.Data;
using EQUniversity.Models;

namespace EQUniversity.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly EQUniversity.Data.UniversityContext _context;

        public DetailsModel(EQUniversity.Data.UniversityContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                                .Include(i => i.Enrollments)
                                .ThenInclude(i => i.Course)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(m => m.ID == id);

            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }
            return Page();
        }
    }
}
