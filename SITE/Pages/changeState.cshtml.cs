using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using SITE.Data.Identity;
using SITE.Data;

namespace SITE.Pages
{
    public class changeState : PageModel
    {
        private ApplicationDbContext _context;

        public changeState(ApplicationDbContext context)
        {
            this._context = context;
        }

        
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? newState { get; set; }

        public Booking update;



        public IActionResult OnGet()
        {

            update = (Booking)_context.Bookings.ToList().Where(i => i.Id == id).First();
            update.sostoania = newState;
            //_context.Bookings.Add(update);
            _context.SaveChanges();
            return RedirectToPage("./dispet");
        }



    }
}
