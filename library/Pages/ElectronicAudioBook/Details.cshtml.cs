using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using library.Data;
using library.Models;

namespace library.Pages.ElectronicAudioBook
{
    public class DetailsModel : PageModel
    {
        private readonly library.Data.ApplicationDbContext _context;

        public DetailsModel(library.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public library.Models.ElectronicAudioBook ElectronicAudioBook { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electronicaudiobook = await _context.ElectronicAudioBooks.FirstOrDefaultAsync(m => m.Id == id);

            if (electronicaudiobook is not null)
            {
                ElectronicAudioBook = electronicaudiobook;

                return Page();
            }

            return NotFound();
        }
    }
}
