using Microsoft.AspNetCore.Identity;

namespace JupiterInv.Core.Entities
{
    public class Role: IdentityRole<Guid>
    {
        public Guid TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}
