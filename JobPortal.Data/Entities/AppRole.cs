using Microsoft.AspNetCore.Identity;

namespace JobPortal.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}