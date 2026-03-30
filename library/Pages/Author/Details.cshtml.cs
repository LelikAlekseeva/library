using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using library.Data;
using library.Models;

namespace library.Pages.Author
{
    public class DetailsModel : PageModel
    {
        private readonly library.Data.ApplicationDbContext _context;

        public DetailsModel(library.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public library.Models.Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);

            if (author is not null)
            {
                Author = author;

                return Page();
            }

            return NotFound();
        }
    }
}
