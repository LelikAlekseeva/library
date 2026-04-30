using library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using library.Data;
using library.Models;


namespace library.Pages.Readers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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
            var student = _context.Readers.Find(Readers.Id);

            if (student != null)
            {
                _context.Readers.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
