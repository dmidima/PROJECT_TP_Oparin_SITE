using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SITE.Data;
using SITE.Data.Identity;

namespace SITE.Pages.Personals
{
    public class DeleteModel : PageModel
    {
        private readonly SITE.Data.ApplicationDbContext _context;

        public DeleteModel(SITE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Personal Personal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personals == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals.FirstOrDefaultAsync(m => m.Id == id);

            if (personal == null)
            {
                return NotFound();
            }
            else 
            {
                Personal = personal;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Personals == null)
            {
                return NotFound();
            }
            var personal = await _context.Personals.FindAsync(id);

            if (personal != null)
            {
                Personal = personal;
                _context.Personals.Remove(Personal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
