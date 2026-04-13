using library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using library.Data;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Pages.ElectronicAudioBook
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public library.Models.ElectronicAudioBook? ElectronicAudioBook { get; set; }

        public IActionResult OnGet(int id)
        {
            ElectronicAudioBook = _context.ElectronicAudioBook
                        .Where(c => c.Id == id)
                        .Include(b => b.Author)
                        .FirstOrDefault();

            if (ElectronicAudioBook == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var book = _context.ElectronicAudioBook.Find(ElectronicAudioBook.Id);

            if (book != null)
            {
                _context.ElectronicAudioBook.Remove(book);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
