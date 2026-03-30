using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using library.Data;
using library.Models;

namespace library.Pages.ElectronicAudioBook
{
    public class EditModel : PageModel
    {
        private readonly library.Data.ApplicationDbContext _context;

        public EditModel(library.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public library.Models.ElectronicAudioBook ElectronicAudioBook { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electronicaudiobook =  await _context.ElectronicAudioBooks.FirstOrDefaultAsync(m => m.Id == id);
            if (electronicaudiobook == null)
            {
                return NotFound();
            }
            ElectronicAudioBook = electronicaudiobook;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ElectronicAudioBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectronicAudioBookExists(ElectronicAudioBook.Id))
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

        private bool ElectronicAudioBookExists(int id)
        {
            return _context.ElectronicAudioBooks.Any(e => e.Id == id);
        }
    }
}
