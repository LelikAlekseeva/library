using library.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Readers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<library.Models.Readers> Readers { get; set; }
        public void OnGet()
        {
            Readers = _context.Readers.ToList();
        }
    }
}
