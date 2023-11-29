using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SITE.Data;
using SITE.Data.Identity;

namespace SITE.Pages.DetailsRoutes
{
    [Authorize(Policy = "Managers")]
    public class EditModel : PageModel
    {
        private readonly SITE.Data.ApplicationDbContext _context;

        public EditModel(SITE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DetailsRoute DetailsRoute { get; set; } = default!;

        [Authorize(Policy = "Managers")]
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DetailsRoutes == null)
            {
                return NotFound();
            }

            var detailsroute =  await _context.DetailsRoutes.FirstOrDefaultAsync(m => m.Id == id);
            if (detailsroute == null)
            {
                return NotFound();
            }
            DetailsRoute = detailsroute;
            return Page();
        }






        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DetailsRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailsRouteExists(DetailsRoute.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DetailsRouteExists(int id)
        {
          return (_context.DetailsRoutes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }




}
