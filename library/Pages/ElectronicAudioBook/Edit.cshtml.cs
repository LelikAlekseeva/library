using library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using library.Data;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Pages.ElectronicAudioBook
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        //private readonly IHubContext<BookHub> _hubContext;

       // public EditModel(ApplicationDbContext context, IHubContext<BookHub> hubContext)
       // {
         //   _context = context;
         //   _hubContext = hubContext;
       // }

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
            if (!ModelState.IsValid)
                return Page();

            _context.ElectronicAudioBook.Update(ElectronicAudioBook);
            _context.SaveChanges();

            // Отправляем обновление всем клиентам
            //_hubContext.Clients.All.SendAsync("BookUpdated", Book);

            return RedirectToPage("Index");
        }
    }
}
