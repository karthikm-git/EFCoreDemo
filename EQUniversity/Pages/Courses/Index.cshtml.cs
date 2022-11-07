using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EQUniversity.Data;
using EQUniversity.Models;

namespace EQUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly EQUniversity.Data.UniversityContext _context;

        public IndexModel(EQUniversity.Data.UniversityContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Courses = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department).ToListAsync();
            }
        }
    }
}
