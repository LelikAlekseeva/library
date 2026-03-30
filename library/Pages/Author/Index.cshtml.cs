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
    public class IndexModel : PageModel
    {
        private readonly library.Data.ApplicationDbContext _context;

        public IndexModel(library.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<library.Models.Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Authors.ToListAsync();
        }
    }
}
