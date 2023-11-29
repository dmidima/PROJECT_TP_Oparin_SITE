using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SITE.Data;
using SITE.Data.Identity;
using Microsoft.Extensions.Logging;



namespace SITE.Pages
{
    //[Authorize(Roles = "Professor, Teacther")]
    //[Authorize(Policy = "Managers")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationIdentityUser> userManager;


        private readonly ApplicationDbContext _context;

        public Booking Booking { get; set; }

        public IndexModel(

            ILogger<IndexModel> logger,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationIdentityUser> userManager,
            ApplicationDbContext context)

        {
            _logger = logger;
            this.roleManager = roleManager;
            this.userManager = userManager;
            _context = context;
        }

        public void OnGet()
        {

        }

        public async Task OnPostNewRole(RoleModel model)
        {

            string roleName = model.RoleName.Trim();
            if (!string.IsNullOrEmpty(roleName))
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole
                    {
                        Name = roleName,
                        NormalizedName = roleName
                    });
                }
            }
        }

        public async Task OnPostAddRole(RoleModel model)
        {
            string roleName = model.RoleName.Trim();
            if (!string.IsNullOrEmpty(roleName))
            {
                var usr = await userManager.GetUserAsync(this.User);
                await userManager.AddToRoleAsync(usr, roleName);
            }
        }

        public async Task OnPostRemoveRole(RoleModel model)
        {
            string roleName = model.RoleName.Trim();
            if (!string.IsNullOrEmpty(roleName))
            {
                var usr = await userManager.GetUserAsync(this.User);
                await userManager.RemoveFromRoleAsync(usr, roleName);
            }
        }

        public IActionResult OnPostAsync(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}