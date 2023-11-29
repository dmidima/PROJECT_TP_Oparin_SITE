using Microsoft.AspNetCore.Identity;

namespace SITE.Data.Identity
{
    public class ApplicationIdentityUser: IdentityUser
    {
        public long ApplicationId { get; set; }
    }
}
