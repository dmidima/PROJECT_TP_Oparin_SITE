using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SITE.Data.Identity;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SITE.Data;
using Microsoft.Extensions.Logging;
using System.Web.Mvc;
using System.Linq;
using Humanizer;
using System.Reflection.Metadata;

namespace SITE.Pages
{

    public class DetaliRoute : PageModel
    {
        private readonly ILogger<DetaliRoute> _logger;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationIdentityUser> userManager;

        public List<int> AvailableSeats { get; set; }

        private readonly ApplicationDbContext _context;

        public DetaliRoute(ApplicationDbContext context)
        {
            this._context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string? from { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? sostoania { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? to { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? taken { get; set; }

        public Booking Booking { get; set; }

        public List<Booking> ReservedSeats { get; set; }

        public DetailsRoute Infa { get; private set; }

        public DetailsRoute InfaDist { get; private set; }

        public string[] times;

        public void OnGet()
        {

            Infa = _context.DetailsRoutes.ToList().Where(i => i.Name.Contains(to)).ToList()[0];
            times = Infa.DepartureTime.Split(" ");
            taken = 0;

        }

        public IActionResult OnPostAsync(Booking booking)
        {
            if (ModelState.IsValid)
            {
                ReservedSeats = _context.Bookings.ToList().Where(
                             i => i.kyda.Contains(to) &&
                                  i.otkyda.Contains(from) &&
                                  i.TimeBook.Contains(booking.TimeBook) &&
                                  i.DateBook == booking.DateBook &&
                                  i.Seat == booking.Seat &&
                                  i.sostoania != "отмена"

                                ).ToList();
                
                //SeatNumber;
                if (ReservedSeats.Count != 0)
                {
                    Infa = _context.DetailsRoutes.ToList().Where(i => i.Name.Contains(to)).ToList()[0];
                    times = Infa.DepartureTime.Split(" ");
                    taken = 1;
                    return Page();
                }
                else
                {
                    //писать строчку в ReservedSeats с купленным билетом
                    ReservedSeat seat = new ReservedSeat { Date = booking.DateBook, SeatNumber = booking.Seat, NameRoute=from+"-"+to, DataTimeRoute= booking.TimeBook };
                    _context.ReservedSeats.Add(seat);

                    //писать забронированный сам букинг
                    _context.Bookings.Add(booking);
                    _context.SaveChanges();
                    return RedirectToPage("./prob");
                }

               
            }
            return Page();
        }
    }
}
