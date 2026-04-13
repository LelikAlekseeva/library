using library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using library.Data;
using library.Models;
using Microsoft.EntityFrameworkCore;


namespace library.Pages.ElectronicAudioBook
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<library.Models.ElectronicAudioBook> ElectronicAudioBook { get; set; }

        public void OnGet()
        {
            ElectronicAudioBook = _context.ElectronicAudioBook
                .Include(b => b.Author)
                .ToList();
        }
    }
}
