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
    public class IndexModel : PageModel
    {
        private readonly SITE.Data.ApplicationDbContext _context;

        public IndexModel(SITE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DetailsRoute> DetailsRoute { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DetailsRoutes != null)
            {
                DetailsRoute = await _context.DetailsRoutes.ToListAsync();
            }
        }
    }
}
