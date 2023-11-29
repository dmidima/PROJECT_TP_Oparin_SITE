using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SITE.Data;
using SITE.Data.Identity;

namespace SITE.Pages.DetailsRoutes
{
    public class DeleteModel : PageModel
    {
        private readonly SITE.Data.ApplicationDbContext _context;

        public DeleteModel(SITE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DetailsRoute DetailsRoute { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DetailsRoutes == null)
            {
                return NotFound();
            }

            var detailsroute = await _context.DetailsRoutes.FirstOrDefaultAsync(m => m.Id == id);

            if (detailsroute == null)
            {
                return NotFound();
            }
            else 
            {
                DetailsRoute = detailsroute;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DetailsRoutes == null)
            {
                return NotFound();
            }
            var detailsroute = await _context.DetailsRoutes.FindAsync(id);

            if (detailsroute != null)
            {
                DetailsRoute = detailsroute;
                _context.DetailsRoutes.Remove(DetailsRoute);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
