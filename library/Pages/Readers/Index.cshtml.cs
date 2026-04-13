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

        public List<library.Models.Readers> Students { get; set; }
        public void OnGet()
        {
            Students = _context.Readers.ToList();
        }
    }
}
