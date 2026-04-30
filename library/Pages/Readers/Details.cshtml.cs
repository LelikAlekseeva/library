using library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using library.Data;
using library.Models;


namespace library.Pages.Readers
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public library.Models.Readers Readers { get; set; }

        public IActionResult OnGet(int id)
        {
            Readers = _context.Readers.FirstOrDefault(s => s.Id == id);

            if (Readers == null)
                return NotFound();

            return Page();
        }
    }
}
