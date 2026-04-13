using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using library.Data;
using library.Models;

namespace library.Pages.ElectronicAudioBook
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public library.Models.ElectronicAudioBook ElectronicAudioBook { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.ElectronicAudioBook.Add(ElectronicAudioBook);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
