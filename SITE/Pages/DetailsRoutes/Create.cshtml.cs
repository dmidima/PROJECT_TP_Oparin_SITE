using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SITE.Data;
using SITE.Data.Identity;

namespace SITE.Pages.DetailsRoutes
{
    public class CreateModel : PageModel
    {
        private readonly SITE.Data.ApplicationDbContext _context;

        public CreateModel(SITE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DetailsRoute DetailsRoute { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.DetailsRoutes == null || DetailsRoute == null)
            {
                return Page();
            }

            _context.DetailsRoutes.Add(DetailsRoute);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
