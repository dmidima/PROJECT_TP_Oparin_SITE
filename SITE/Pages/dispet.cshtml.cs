using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SITE.Data;
using SITE.Data.Identity;

namespace SITE.Pages
{
    public class dispet : PageModel
    {
        private ApplicationDbContext _context;

        public dispet(ApplicationDbContext context)
        {
            this._context = context;
        }

        public List<Booking> Infa { get; private set; }


        [BindProperty(SupportsGet = true)]
        public string? Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? newState { get; set; }



        [BindProperty(SupportsGet = true)]
        public string? sostoania { get; set; }




        public void OnGet()
        {

            Infa = _context.Bookings.ToList().Where(i => i.sostoania == "в обработке" || i.sostoania == "вобработке").ToList();
        }



    }
}
