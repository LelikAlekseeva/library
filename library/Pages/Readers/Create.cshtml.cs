
using library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using library.Data;
using library.Models;

namespace library.Pages.Readers
{
    public class CreateModel : PageModel
    {
       
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public library.Models.Readers Readers { get; set; }
        public void OnGet() { }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Readers.Add(Readers);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }

    }
}

