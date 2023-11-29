using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SITE.Data;
using SITE.Data.Identity;

namespace SITE.Pages.Transports
{
    public class DeleteModel : PageModel
    {
        private readonly SITE.Data.ApplicationDbContext _context;

        public DeleteModel(SITE.Data.ApplicationDbContext context)
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

            var transport = await _context.Transports.FirstOrDefaultAsync(m => m.Id == id);

            if (transport == null)
            {
                return NotFound();
            }
            else 
            {
                Transport = transport;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Transports == null)
            {
                return NotFound();
            }
            var transport = await _context.Transports.FindAsync(id);

            if (transport != null)
            {
                Transport = transport;
                _context.Transports.Remove(Transport);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
