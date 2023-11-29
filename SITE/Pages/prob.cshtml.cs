
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SITE.Data.Identity;
using SITE.Data;
using Microsoft.EntityFrameworkCore;

namespace SITE.Pages
{
    public class probModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public probModel(ILogger<PrivacyModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        


        private readonly ApplicationDbContext _context;

        

        public List<Booking> UserBookings { get; set; }

        public async Task OnGetAsync()
        {
            UserBookings = await _context.Bookings.ToListAsync();
        }

    }

}