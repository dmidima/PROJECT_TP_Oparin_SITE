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
    public class IndexModel : PageModel
    {
        private readonly SITE.Data.ApplicationDbContext _context;

        public IndexModel(SITE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Personal> Personal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Personals != null)
            {
                Personal = await _context.Personals.ToListAsync();
            }
        }
    }
}
