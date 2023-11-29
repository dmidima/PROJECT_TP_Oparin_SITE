using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SITE.Data;
using SITE.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace SITE.Pages.Students
{
    //[Authorize(Roles = "Professor, Teacther")]
    //[Authorize(Policy = "Managers")]
    public class IndexModel : PageModel
    {
        private readonly SITE.Data.ApplicationDbContext _context;

        public IndexModel(SITE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
            }


        }
    }
}
