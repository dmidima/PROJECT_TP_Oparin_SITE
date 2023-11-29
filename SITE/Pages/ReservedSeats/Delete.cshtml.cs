using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SITE.Data;
using SITE.Data.Identity;

namespace SITE.Pages.ReservedSeats
{
    public class DeleteModel : PageModel
    {
        private readonly SITE.Data.ApplicationDbContext _context;

        public DeleteModel(SITE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ReservedSeat ReservedSeat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ReservedSeats == null)
            {
                return NotFound();
            }

            var reservedseat = await _context.ReservedSeats.FirstOrDefaultAsync(m => m.Id == id);

            if (reservedseat == null)
            {
                return NotFound();
            }
            else 
            {
                ReservedSeat = reservedseat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ReservedSeats == null)
            {
                return NotFound();
            }
            var reservedseat = await _context.ReservedSeats.FindAsync(id);

            if (reservedseat != null)
            {
                ReservedSeat = reservedseat;
                _context.ReservedSeats.Remove(ReservedSeat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
