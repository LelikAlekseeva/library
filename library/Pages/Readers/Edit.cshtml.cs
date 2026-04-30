using library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Readers
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public library.Models.Readers Readers { get; set; }

        public IActionResult OnGet(int id)
        {
            Readers = _context.Readers.Find(id);

            if (Readers == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Readers.Update(Readers);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
