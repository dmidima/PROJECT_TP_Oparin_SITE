using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SITE.Data;
using SITE.Data.Identity;

namespace SITE.Pages.Transports
{
    public class EditModel : PageModel
    {
        private readonly SITE.Data.ApplicationDbContext _context;

        public EditModel(SITE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Transport Transport { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Transports == null)
            {
                return NotFound();
            }

            var transport =  await _context.Transports.FirstOrDefaultAsync(m => m.Id == id);
            if (transport == null)
            {
                return NotFound();
            }
            Transport = transport;
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

            _context.Attach(Transport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportExists(Transport.Id))
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

        private bool TransportExists(int id)
        {
          return (_context.Transports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
